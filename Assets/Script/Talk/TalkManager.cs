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
using gad20241013.Talk.Assets.Script.Talk;
using UnityEditor;

namespace gad20241013.Talk
{
    public class TalkManager : ITalkManager, ITalkCountRecieve
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
                Debug.LogAssertion("TalkBgがありません");
            }
            if (m_talkTmp == null)
            {
                Debug.LogAssertion("TalkTmpがありません");
            }
            ClearText();

        }

        public async UniTask Talk(TalkSource source)
        {
            //セリフ枠を表示
            m_talkBg.SetActive(true);
            m_talkNameTmp.text = source.talkCharacter.Name;
            m_TalkKeyObject.SetActive(false);


            //セリフの文字を一つずつ出す
            var t = new GameObject().AddComponent<TalkCounter>();
            t.StartTextCount(this, source.talkSentence);

            var cts = new CancellationTokenSource();

            RecieveSkipInput(t, cts.Token).Forget();
            await UniTask.WaitUntil(() => t.IsEndTextCount);
            cts.Cancel();
            GameObject.Destroy(t.gameObject);

            //決定キー押したらセリフ終了
            m_TalkKeyObject.SetActive(true);
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
            SoundManager.PlaySE(SoundManager.SELabel.Enter);
            ClearText();
        }

        void ClearText()
        {
            m_talkTmp.text = "";
            m_talkBg.SetActive(false);

        }

        public void SetText(string text)
        {
            m_talkTmp.text = text;
        }

        public void End()
        {

        }

        public async UniTask RecieveSkipInput(TalkCounter talkCounter, CancellationToken cancellationToken)
        {
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Z));
            talkCounter.SkipText();
        } 
    }
}