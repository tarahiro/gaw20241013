using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace gad20241013
{

    public class Opening
    {
        ITalkManager m_talkManager;
        ISceneFader m_sceneFader;

        List<TalkSource> m_talkSource;

        public Opening(ITalkManager talkManager, ISceneFader sceneFader, List<TalkSource> talkSource)
        {
            m_talkManager = talkManager;
            m_sceneFader = sceneFader;
            m_talkSource = talkSource;
        }

        public async UniTask Enter()
        {
            //画面を明るくフェードイン
            await m_sceneFader.SceneStart();

            //セリフを出す
            await Talk(m_talkSource);
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
