using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gad20241013;
using UnityEditor;

namespace gad20241013.Item
{
    public class WindStone : IItem
    {
        int m_id;
        string m_productName;
        string m_displayName;
        string m_description;

        public int Id => m_id;
        public string ProductName => m_productName;
        public string DisplayName => m_displayName;
        public string Description => m_description;


        public WindStone()
        {
            m_id = 2;
            m_productName = typeof(WindStone).Name;
            m_displayName = "かぜの石";
            m_description = "周囲で空気が渦巻く石。足元に置けば、少しの間とぶことができる。" +
                "\nハイノの塔は、この石がないと登れないらしい。";
        }
    }
}
