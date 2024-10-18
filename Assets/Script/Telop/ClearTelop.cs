using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cysharp.Threading.Tasks;

namespace gad20241013.Telop
{
    public class ClearTelop : ITelop
    {
        GameObject TelopObject;
        TextMeshProUGUI TelopText;


        public ClearTelop()
        {
            Debug.Log("クリア演出用のオブジェクト初期化");
            TelopObject = GameObject.Find("TelopObject");
            TelopText = GameObject.Find("TelopText").GetComponent<TextMeshProUGUI>();
         }

        public async UniTask Enter()
        {
            //Telopに情報を入力する
            Debug.Log("Telopに情報を入力する");
            TelopObject.SetActive(true);
            TelopText.text = "クリア！";

            //Telopを待つ
            Debug.Log(" //Telopを待つ");
            await UniTask.WaitForSeconds(1f);

            //Telopを隠す
            Debug.Log(" //Telopを隠す");
            TelopObject.SetActive(false);
        }
    }
}