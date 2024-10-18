using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using LitMotion;
using LitMotion.Extensions;
using TMPro;
using gad20241013;

namespace gad20241013.SceneFader
{
    public class SceneFader: ISceneFader
    {
        Image SceneFadeImage;

        public SceneFader()
        {
            SceneFadeImage = GameObject.Find("SceneFadeImage").GetComponent<Image>();
        }

        public void SetSceneInitial()
        {
            Color c = SceneFadeImage.color;
            c.a = 1f;
            SceneFadeImage.color = c;
        }

        public async UniTask SceneStart()
        {
            await LMotion.Create(SceneFadeImage.color.a, 0f, 1f).
                BindToColorA(SceneFadeImage);
        }
        public async UniTask SceneEnd()
        {
            await LMotion.Create(SceneFadeImage.color.a, 1f, 1f).
                BindToColorA(SceneFadeImage);
        }
    }
}
