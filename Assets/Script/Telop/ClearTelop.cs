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
            Debug.Log("�N���A���o�p�̃I�u�W�F�N�g������");
            TelopObject = GameObject.Find("TelopObject");
            TelopText = GameObject.Find("TelopText").GetComponent<TextMeshProUGUI>();
         }

        public async UniTask Enter()
        {
            //Telop�ɏ�����͂���
            Debug.Log("Telop�ɏ�����͂���");
            TelopObject.SetActive(true);
            TelopText.text = "�N���A�I";

            //Telop��҂�
            Debug.Log(" //Telop��҂�");
            await UniTask.WaitForSeconds(1f);

            //Telop���B��
            Debug.Log(" //Telop���B��");
            TelopObject.SetActive(false);
        }
    }
}