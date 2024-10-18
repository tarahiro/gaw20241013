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
            //ToDo: Telop�̏������̎d��
            TelopObject = GameObject.Find("TelopObject");
            TelopText = GameObject.Find("TelopText").GetComponent<TextMeshProUGUI>();
            TelopObject.SetActive(false);
            
        }

        public async UniTask Enter()
        {
            //Telop�ɏ�����͂���
            Debug.Log("Telop�ɏ�����͂���");
            TelopObject.SetActive(true);
            TelopText.text = "The End!";

            //Telop��҂�
            Debug.Log(" //Telop��҂�");
            await UniTask.WaitForSeconds(2f);

            //Telop���B��
            Debug.Log(" //Telop���B��");
            TelopObject.SetActive(false);
        }
    }
}