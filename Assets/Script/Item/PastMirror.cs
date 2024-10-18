using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gad20241013;
using UnityEditor;
using System.Runtime.CompilerServices;

namespace gad20241013.Item
{
    public class PastMirror : IItem
    {
        int m_id;
        string m_productName;
        string m_displayName;
        string m_description;

        public int Id => m_id;
        public string ProductName => m_productName;
        public string DisplayName => m_displayName;
        public string Description => m_description;


        public PastMirror()
        {
            m_id = 3;
            m_productName =  typeof(PastMirror).Name;
            m_displayName = "�ނ����̖���";
            m_description = "�ǂ����Â߂������A���͂̍��߂�ꂽ���B\n�ڂ̑O�̂��̂̐̂̎p���f���o���B";
        }
    }
}
