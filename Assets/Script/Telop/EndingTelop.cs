using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cysharp.Threading.Tasks;

namespace gad20241013.Telop
{
    public class EndingTelop : ITelop
    {
        GameObject TelopObject;
        TextMeshProUGUI TelopText;


        public EndingTelop()
        {
            //ToDo: Telop‚Ì‰Šú‰»‚Ìd•û
            TelopObject = GameObject.Find("TelopObject");
            TelopText = GameObject.Find("TelopText").GetComponent<TextMeshProUGUI>();
            TelopObject.SetActive(false);
            
        }

        public async UniTask Enter()
        {
            //Telop‚Éî•ñ‚ğ“ü—Í‚·‚é
            Debug.Log("Telop‚Éî•ñ‚ğ“ü—Í‚·‚é");
            TelopObject.SetActive(true);
            TelopText.text = "The End!";

            //Telop‚ğ‘Ò‚Â
            Debug.Log(" //Telop‚ğ‘Ò‚Â");
            await UniTask.WaitForSeconds(2f);

            //Telop‚ğ‰B‚·
            Debug.Log(" //Telop‚ğ‰B‚·");
            TelopObject.SetActive(false);
        }
    }
}