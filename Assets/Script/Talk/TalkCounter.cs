using gad20241013.Talk.Assets.Script.Talk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace gad20241013.Talk
{
    public class TalkCounter : MonoBehaviour
    {
        bool isStart = false;
        string m_text = "";
        string m_currentText;
        int textCount = 0;
        float m_Tick = 0;
        const float defaultTextIntervalTime = .1f;
        float m_textIntervalTime;
        ITalkCountRecieve m_talkCountRecieve;

        public void StartTextCount(ITalkCountRecieve talkCountRecieve, string text, float textIntervalTime = defaultTextIntervalTime)
        {
            m_talkCountRecieve = talkCountRecieve;
            isStart = true;
            m_text = text;
            textCount = 0;
            m_Tick = 0;
            m_textIntervalTime = textIntervalTime;
            m_currentText = "";
            SoundManager.PlaySEWithLoop(SoundManager.SELabel.Text);

        }
        private void Update()
        {
            if (isStart && !IsEndTextCount)
            {
                m_Tick += Time.deltaTime;
                if(m_Tick > m_textIntervalTime)
                {
                    m_currentText += m_text[textCount];
                    m_talkCountRecieve.SetText(m_currentText);

                    m_Tick = 0;
                    textCount++;

                    if(textCount >= m_text.Length)
                    {
                        End();
                    }
                }
            }
            
        }

        public void SkipText()
        {
            m_talkCountRecieve.SetText(m_text);
            End();
        }

        public bool IsEndTextCount { get; private set; } = false;

        void End()
        {
            m_talkCountRecieve.End();
            SoundManager.StopLoopSE();
            IsEndTextCount = true;
        }

    }
}
