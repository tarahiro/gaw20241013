using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gad20241013;
using UnityEditor;
using System.Runtime.CompilerServices;

namespace gad20241013.Item
{
    public class ParalysisCure : IItem
    {
        int m_id;
        string m_productName;
        string m_displayName;
        string m_description;

        public int Id => m_id;
        public string ProductName => m_productName;
        public string DisplayName => m_displayName;
        public string Description => m_description;


        public ParalysisCure()
        {
            m_id = 7;
            m_productName =  typeof(ParalysisCure).Name;
            m_displayName = "�܂Ђ���������";
            m_description = "���тꑐ�����ȋ��ɏ悹�ďĂ����Ƃłł����B" +
                "\n���݉߂���ƁA�̂��_�炩���Ȃ��Ĉꎞ�I�ɗ��ĂȂ��Ȃ�炵���B";
        }
    }
}
