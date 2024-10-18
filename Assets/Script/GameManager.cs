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

                //�I�[�v�j���O�Đ�
                SoundManager.PlayBGM("title", 0);
                await m_openingFactory.CreateOpening().Enter();

                //�T�C�N���Đ�
                for (int i = 0; i < cycleNumber; i++)
                {
                    Debug.Log("�T�C�N���Đ�");
                    await m_cycleFactory.
                            CreateCycle(i).
                            CycleTurn();
                }


                //�G���f�B���O�Đ�
                await m_endingFactory.CreateEnding().Enter();

                //�����҂��čŏ��ɖ߂�
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
