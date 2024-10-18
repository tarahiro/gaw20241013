using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gad20241013;
using UnityEditor;

namespace gad20241013.Item
{
    public class IceStone : IItem
    {
        int m_id;
        string m_productName;
        string m_displayName;
        string m_description;

        public int Id => m_id;
        public string ProductName => m_productName;
        public string DisplayName => m_displayName;
        public string Description => m_description;



        public IceStone()
        {
            m_id = 1;
            m_productName = typeof(IceStone).Name;
            m_displayName = "こおりの石";
            m_description = "冷気を放つ石。炎素を打ち消す。" +
                "\nこれがあれば、ヤイファー山の火口探索もへっちゃら。";
        }
    }
}
