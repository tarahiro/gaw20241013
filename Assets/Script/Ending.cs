using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace gad20241013
{

    public class Ending
    {
        ITalkManager m_talkManager;
        ISceneFader m_sceneFader;
        ITelop m_endingTelop;

        List<TalkSource> m_talkSource;

        public Ending(ITalkManager talkManager, ISceneFader sceneFader, ITelop endingTelop,List<TalkSource> talkSources)
        {
            m_talkManager = talkManager;
            m_sceneFader = sceneFader;
            m_endingTelop = endingTelop;
            m_talkSource = talkSources;
        }

        public async UniTask Enter()
        {
            //セリフを出す
            await Talk(m_talkSource);

            //テロップ表示
            await m_endingTelop.Enter();

            //画面をフェードアウト
            await m_sceneFader.SceneEnd();
        }


        //Utilityにまとめたい
        async UniTask Talk(List<TalkSource> talkSources)
        {
            for (int i = 0; i < talkSources.Count; i++)
            {
                await m_talkManager.Talk(talkSources[i]);
            }
        }
    }
}
