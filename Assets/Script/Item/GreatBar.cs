using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gad20241013;
using UnityEditor;
using System.Runtime.CompilerServices;

namespace gad20241013.Item
{
    public class GreatBar : IItem
    {
        int m_id;
        string m_productName;
        string m_displayName;
        string m_description;

        public int Id => m_id;
        public string ProductName => m_productName;
        public string DisplayName => m_displayName;
        public string Description => m_description;


        public GreatBar()
        {
            m_id = 5;
            m_productName =  typeof(GreatBar).Name;
            m_displayName = "グレートバール";
            m_description = "巨大なバール。刺さったものを何でも抜くことができる。" +
                "\nこれでスーパーソードを抜いてしまった勇者がいたとか。";
        }
    }
}
