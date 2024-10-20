using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cysharp.Threading.Tasks;

namespace gad20241013.Telop
{
    public class Telop : ITelop
    {
        GameObject TelopObject;
        TextMeshProUGUI TelopText;


        public Telop()
        {
            //ToDo: Telopの初期化の仕方
            TelopObject = GameObject.Find("TelopObject");
            TelopText = GameObject.Find("TelopText").GetComponent<TextMeshProUGUI>();
            TelopObject.SetActive(false);
            
        }

        public async UniTask Enter(string text, float waitTime)
        {
            //Telopに情報を入力する
            Debug.Log("Telopに情報を入力する");
            TelopObject.SetActive(true);
            TelopText.text = text;

            //Telopを待つ
            Debug.Log(" //Telopを待つ");
            await UniTask.WaitForSeconds(waitTime);

            //Telopを隠す
            Debug.Log(" //Telopを隠す");
            TelopObject.SetActive(false);
        }
    }
}