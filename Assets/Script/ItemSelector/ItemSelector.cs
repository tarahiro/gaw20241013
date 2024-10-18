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
            //�A�C�e�����V�[�o�u���o�^
            m_itemReceivable = receivable;

            //�A�C�e�����j���[�ɐݒ��n��
            m_itemMenu.SetItemList(m_item);
            m_itemMenu.Decided.Subscribe(SetSelectItem);

            //�A�C�e�����j���[�J�n
            await m_itemMenu.Enter();
        }

        void SetSelectItem(int itemIndex)
        {
            m_itemReceivable.RecieveItem(m_item[itemIndex]);

        }
    }

}
