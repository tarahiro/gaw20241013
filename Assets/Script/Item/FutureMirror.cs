using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gad20241013;
using UnityEditor;
using System.Runtime.CompilerServices;

namespace gad20241013.Item
{
    public class FutureMirror : IItem
    {
        int m_id;
        string m_productName;
        string m_displayName;
        string m_description;

        public int Id => m_id;
        public string ProductName => m_productName;
        public string DisplayName => m_displayName;
        public string Description => m_description;


        public FutureMirror()
        {
            m_id = 4;
            m_productName =  typeof(FutureMirror).Name;
            m_displayName = "�݂炢�̖���";
            m_description = "���͂܂����݂��Ȃ��f�ނō��ꂽ�A���͂̍��߂�ꂽ���B\n�ڂ̑O�̂��̖̂����̎p���f���o���B";
        }
    }
}
