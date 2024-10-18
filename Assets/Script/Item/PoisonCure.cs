using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gad20241013;
using UnityEditor;
using System.Runtime.CompilerServices;

namespace gad20241013.Item
{
    public class PoisonCure : IItem
    {
        int m_id;
        string m_productName;
        string m_displayName;
        string m_description;

        public int Id => m_id;
        public string ProductName => m_productName;
        public string DisplayName => m_displayName;
        public string Description => m_description;


        public PoisonCure()
        {
            m_id = 6;
            m_productName =  typeof(PoisonCure).Name;
            m_displayName = "�ǂ�����������";
            m_description = "�ǂ�������������č������B" +
                "\n����𓊂��邾���ŁA��_���[�W���󂯂郂���X�^�[������炵���B";
        }
    }
}
