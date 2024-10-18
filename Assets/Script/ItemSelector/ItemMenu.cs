using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace gad20241013.ItemSelector
{
    public class ItemMenu : IItemMenu
    {
        const string ItemMenuItemPrefabPath = "ItemSelector/ItemMenuItem";
        const float merginX = 20f;

        GameObject ItemMenuObject;
        GameObject ItemMenuItemBgObject;
        GameObject ItemMenuItemInitialPosition;
        GameObject ItemMenuItemPrefab;
        TextMeshProUGUI ItemMenuDescriptionTmp;

        List<IItemMenuItem> m_itemMenuItems;

        List<IItem> m_items = null;
        int index = 0;
        bool isDecided = false;

        public ItemMenu()
        {
            ItemMenuObject = GameObject.Find("ItemMenuObject");
            ItemMenuItemBgObject = GameObject.Find("ItemMenuItemBgObject");
            ItemMenuItemInitialPosition = GameObject.Find("ItemMenuItemInitialPosition");
            ItemMenuDescriptionTmp = GameObject.Find("ItemMenuDescriptionTmp").GetComponent<TextMeshProUGUI>();

            ItemMenuObject.SetActive(false);

            m_itemMenuItems = new List<IItemMenuItem>();
        }

        public async UniTask Enter()
        {

            //メニュー表示
            isDecided = false;

            ItemMenuItemPrefab = Resources.Load<GameObject>(ItemMenuItemPrefabPath);
            ItemMenuObject.SetActive(true);
            for (int i = 0; i < m_items.Count; i++)
            {
                var obj = GameObject.Instantiate(ItemMenuItemPrefab, ItemMenuItemBgObject.transform);
                
                var itemMenuItem = obj.GetComponent<IItemMenuItem>();
                itemMenuItem.SetName(m_items[i].DisplayName);
                itemMenuItem.SetSprite(Resources.Load<Sprite>(ItemSelectorUtil.itemSpritePath + m_items[i].ProductName));
                itemMenuItem.SetPosition((Vector2)ItemMenuItemInitialPosition.GetComponent<RectTransform>().localPosition + new Vector2(i * (merginX + obj.GetComponent<RectTransform>().sizeDelta.x), 0));
                itemMenuItem.UnFocus();

                m_itemMenuItems.Add(itemMenuItem);
            }
            Focus(0);

            //決定か、左右キーの入力を待つ。決定したら終了
            do
            {
                await UniTask.WaitUntil(() => MenuInput());
            } while (!isDecided);


            //メニュー消去
            for (int i = 0; i < m_itemMenuItems.Count; i++)
            {
                m_itemMenuItems[i].Destroy();
            }
            m_itemMenuItems = new List<IItemMenuItem>();
            ItemMenuObject.SetActive(false);
        }

        public void SetItemList(List<IItem> items)
        {
            m_items = items;
        }


        void Focus(int pIndex)
        {
            m_itemMenuItems[index].UnFocus();
            index = pIndex;
            ItemMenuDescriptionTmp.text = m_items[index].Description;
            m_itemMenuItems[index].Focus();

        }

        bool MenuInput()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)){
                Focus((index + m_items.Count - 1) % m_items.Count);
                SoundManager.PlaySE(SoundManager.SELabel.Cursor);
                return true;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Focus((index + m_items.Count + 1) % m_items.Count);
                SoundManager.PlaySE(SoundManager.SELabel.Cursor);
                return true;
            }

            if (Input.GetKeyDown(KeyCode.Z)){
                Decide();
                Debug.Log("決定 " + index);
                return true;
            }

            return false;
        }

        void Decide()
        {
            SoundManager.PlaySE(SoundManager.SELabel.Enter);
            isDecided = true;
            decideSubject.OnNext(index);
        }

        Subject<int> decideSubject = new Subject<int>();

        public IObservable<int> Decided => decideSubject;
    }
}
