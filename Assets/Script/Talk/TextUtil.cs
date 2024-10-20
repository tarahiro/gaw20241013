using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cysharp.Threading.Tasks;
using Mono.Cecil;
using System.Threading;

namespace gad20241013.Talk
{
    public static class TextUtil
    {
        const float c_defaultTextIntervalTime = .1f;
        public static async UniTask DisplayTextByCharacter(string text, TextMeshProUGUI textMeshProUGUI, string SeLabel,KeyCode decide, float textIntervalTime = c_defaultTextIntervalTime)
        {
            var t = new GameObject().AddComponent<TalkCounter>();
            t.StartTextCount(text,textMeshProUGUI,SeLabel,decide,c_defaultTextIntervalTime);
            await UniTask.WaitUntil(() => t.IsEndTextCount);
            GameObject.Destroy(t.gameObject);
        }
    }
}