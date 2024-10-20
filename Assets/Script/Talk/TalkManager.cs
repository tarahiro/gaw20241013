using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using TMPro;
using LitMotion;
using System.Threading;
using Tarahiro;

namespace gad20241013.Talk
{
    public class TalkManager : ITalkManager
    {
        GameObject m_talkBg;
        TextMeshProUGUI m_talkTmp;
        TextMeshProUGUI m_talkNameTmp;
        GameObject m_TalkKeyObject;

        public TalkManager()
        {
            m_talkBg = GameObject.Find("TalkBg");
            m_talkTmp = GameObject.Find("TalkTmp").GetComponent<TextMeshProUGUI>();
            m_talkNameTmp = GameObject.Find("TalkNameTmp").GetComponent<TextMeshProUGUI>();
            m_TalkKeyObject = GameObject.Find("TalkKeyObject");

            if (m_talkBg == null)
            {
                Debug.LogAssertion("TalkBg������܂���");
            }
            if (m_talkTmp == null)
            {
                Debug.LogAssertion("TalkTmp������܂���");
            }
            ClearText();

        }

        public async UniTask Talk(TalkSource source)
        {
            //�Z���t�g��\��
            m_talkBg.SetActive(true);
            m_talkNameTmp.text = source.talkCharacter.Name;
            m_TalkKeyObject.SetActive(false);


            //�Z���t�̕���������o��
            await TextUtil.DisplayTextByCharacter(source.talkSentence, m_talkTmp, "Text", KeyCode.Z);

            //����L�[��������Z���t�I��
            m_TalkKeyObject.SetActive(true);
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
            SoundManager.PlaySE("Enter");
            ClearText();
        }

        void ClearText()
        {
            m_talkTmp.text = "";
            m_talkBg.SetActive(false);

        }

    }
}