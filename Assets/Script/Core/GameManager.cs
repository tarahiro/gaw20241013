using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace gad20241013
{
    public class GameManager
    {
        const int cycleNumber = 3;

        IOpeningFactory m_openingFactory;
        ICycleFactory m_cycleFactory;
        IEndingFactory m_endingFactory;

        public GameManager(IOpeningFactory openingFactory, ICycleFactory cycleFactory, IEndingFactory endingFactory)
        {
            m_openingFactory = openingFactory;
            m_cycleFactory = cycleFactory;
            m_endingFactory = endingFactory;
        }

        public async UniTask Main()
        {
            while (true)
            {

                //オープニング再生
                SoundManager.PlayBGM("title", 0);
                await m_openingFactory.CreateOpening().Enter();

                //サイクル再生
                for (int i = 0; i < cycleNumber; i++)
                {
                    Debug.Log("サイクル再生");
                    await m_cycleFactory.
                            CreateCycle(i).
                            CycleTurn();
                }


                //エンディング再生
                await m_endingFactory.CreateEnding().Enter();

                //少し待って最初に戻る
                SoundManager.StopBGM(0);
                await UniTask.WaitForSeconds(2f);

            }
        }



        // Update is called once per frame
        void Update()
        {

        }
    }
}
