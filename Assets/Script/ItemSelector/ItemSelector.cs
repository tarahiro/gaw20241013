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
        ISomethingProvider<IItem> m_itemProvider;

        List<IItem> m_itemList;

        IItemMenu m_itemMenu;
        IItemReceivable m_itemReceivable;

        public ItemSelector(IItemMenu itemMenu, ISomethingProvider<IItem> itemProvider)
        {
            m_itemProvider = itemProvider;
            m_itemMenu = itemMenu;

            m_itemList = new List<IItem>();

            for(int i = 0; i < itemProvider.Count; i++)
            {
                m_itemList.Add(itemProvider.TryGetFromIndex(i));
            }
        }

        public async UniTask RunItemDialog(IItemReceivable receivable)
        {
            //�A�C�e�����V�[�o�u���o�^
            m_itemReceivable = receivable;

            //�A�C�e�����j���[�ɐݒ��n��
            m_itemMenu.SetItemList(m_itemList);
            m_itemMenu.Decided.Subscribe(SetSelectItem);

            //�A�C�e�����j���[�J�n
            await m_itemMenu.Enter();
        }

        void SetSelectItem(int itemIndex)
        {
            m_itemReceivable.RecieveItem(m_itemList[itemIndex]);

        }
    }

}
