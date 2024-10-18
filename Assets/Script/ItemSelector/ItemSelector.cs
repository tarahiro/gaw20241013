using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gad20241013;
using Cysharp.Threading.Tasks;
using System.Threading;
using UniRx;

namespace gad20241013.ItemSelector
{
    public class ItemSelector : IItemSelector
    {
        List<IItem> m_item;

        IItemMenu m_itemMenu;
        IItemReceivable m_itemReceivable;

        public ItemSelector(IItemMenu itemMenu, List<IItem> items)
        {
            m_item = items;
            m_itemMenu = itemMenu;
        }

        public async UniTask RunItemDialog(IItemReceivable receivable)
        {
            //アイテムレシーバブル登録
            m_itemReceivable = receivable;

            //アイテムメニューに設定を渡す
            m_itemMenu.SetItemList(m_item);
            m_itemMenu.Decided.Subscribe(SetSelectItem);

            //アイテムメニュー開始
            await m_itemMenu.Enter();
        }

        void SetSelectItem(int itemIndex)
        {
            m_itemReceivable.RecieveItem(m_item[itemIndex]);

        }
    }

}
