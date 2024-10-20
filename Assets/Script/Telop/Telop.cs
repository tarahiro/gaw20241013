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
            //ToDo: Telop�̏������̎d��
            TelopObject = GameObject.Find("TelopObject");
            TelopText = GameObject.Find("TelopText").GetComponent<TextMeshProUGUI>();
            TelopObject.SetActive(false);
            
        }

        public async UniTask Enter(string text, float waitTime)
        {
            //Telop�ɏ�����͂���
            Debug.Log("Telop�ɏ�����͂���");
            TelopObject.SetActive(true);
            TelopText.text = text;

            //Telop��҂�
            Debug.Log(" //Telop��҂�");
            await UniTask.WaitForSeconds(waitTime);

            //Telop���B��
            Debug.Log(" //Telop���B��");
            TelopObject.SetActive(false);
        }
    }
}