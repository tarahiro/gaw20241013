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
            m_displayName = "まひけしぐすり";
            m_description = "しびれ草を特殊な鏡に乗せて焼くことでできる薬。" +
                "\n飲み過ぎると、体が柔らかくなって一時的に立てなくなるらしい。";
        }
    }
}
