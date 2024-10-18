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
            Debug.Log("目的アイテム名: " + m_correctItem.DisplayName);

            m_talkSourceBeforeSelectItem = talkSourceBeforeSelectItem;
            m_talkSourceAfterSelectItem = talkSourceAfterSelectItem;
            m_talkSourceWhenCleared = talkSourceWhenCleared;
            m_talkSourceWhenFailed = talkSourceWhenFailed;
        }

        public async UniTask CycleTurn()
        {
            //モンスター登場
            Debug.Log("モンスター登場");
            await m_enemy.EnterRoom();

            //アイテム選択前の会話
            Debug.Log("アイテム選択前の会話");
            await Talk(m_talkSourceBeforeSelectItem);
            
            //アイテム選択および会話
            await m_itemDialog.RunItemDialog(this);
            await Talk(m_talkSourceAfterSelectItem);

            //if 外れたら 外れたときの会話
            //アイテム選択に戻る
            if (selectedItem == null)
            {
                Debug.Log("アイテムが選択されていません");
            }

            while (selectedItem != m_correctItem)
            {

                //失敗時会話
                await Talk(m_talkSourceWhenFailed);

                //アイテム選択および会話
                await m_itemDialog.RunItemDialog(this);
                await Talk(m_talkSourceAfterSelectItem);
            }

            //クリア時の会話
            await Talk(m_talkSourceWhenCleared);

            //クリア演出
            Debug.Log("クリア演出");
            await m_clearTelop.Enter();

            //モンスター帰る
            Debug.Log("モンスター帰る");
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
