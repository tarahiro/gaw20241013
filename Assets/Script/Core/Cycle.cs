using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace gad20241013
{
    public class Cycle : IItemReceivable
    {
        ITalkManager m_talkManager;
        IEnemy m_enemy;
        IItemSelector m_itemDialog;
        IItem m_correctItem;
        ITelop m_clearTelop;
        List<TalkSource> m_talkSourceBeforeSelectItem;
        List<TalkSource> m_talkSourceAfterSelectItem;
        List<TalkSource> m_talkSourceWhenCleared;
        List<TalkSource> m_talkSourceWhenFailed;

        IItem selectedItem = null;

        public Cycle(ITalkManager talkManager, IItemSelector itemDialog, IEnemy enemy, IItem correctItem, ITelop clearTelop,
            List<TalkSource> talkSourceBeforeSelectItem,
            List<TalkSource> talkSourceAfterSelectItem,
            List<TalkSource> talkSourceWhenCleared,
            List<TalkSource> talkSourceWhenFailed)
        {
            m_talkManager = talkManager;
            m_itemDialog = itemDialog;
            m_enemy = enemy;
            m_correctItem = correctItem;
            m_clearTelop = clearTelop;
            Debug.Log("�ړI�A�C�e����: " + m_correctItem.DisplayName);

            m_talkSourceBeforeSelectItem = talkSourceBeforeSelectItem;
            m_talkSourceAfterSelectItem = talkSourceAfterSelectItem;
            m_talkSourceWhenCleared = talkSourceWhenCleared;
            m_talkSourceWhenFailed = talkSourceWhenFailed;
        }

        public async UniTask CycleTurn()
        {
            //�����X�^�[�o��
            Debug.Log("�����X�^�[�o��");
            await m_enemy.EnterRoom();

            //�A�C�e���I��O�̉�b
            Debug.Log("�A�C�e���I��O�̉�b");
            await Talk(m_talkSourceBeforeSelectItem);
            
            //�A�C�e���I������щ�b
            await m_itemDialog.RunItemDialog(this);
            await Talk(m_talkSourceAfterSelectItem);

            //if �O�ꂽ�� �O�ꂽ�Ƃ��̉�b
            //�A�C�e���I���ɖ߂�
            if (selectedItem == null)
            {
                Debug.Log("�A�C�e�����I������Ă��܂���");
            }

            while (selectedItem != m_correctItem)
            {

                //���s����b
                await Talk(m_talkSourceWhenFailed);

                //�A�C�e���I������щ�b
                await m_itemDialog.RunItemDialog(this);
                await Talk(m_talkSourceAfterSelectItem);
            }

            //�N���A���̉�b
            await Talk(m_talkSourceWhenCleared);

            //�N���A���o
            Debug.Log("�N���A���o");
            await m_clearTelop.Enter("�N���A�I",1f);

            //�����X�^�[�A��
            Debug.Log("�����X�^�[�A��");
            await m_enemy.ExitRoom();
        }

        async UniTask Talk(List<TalkSource> talkSources)
        {
            for (int i = 0; i < talkSources.Count; i++)
            {
                await m_talkManager.Talk(talkSources[i]);
            }
        }


        public void RecieveItem(IItem item)
        {
            selectedItem = item;
        }

    }
}
