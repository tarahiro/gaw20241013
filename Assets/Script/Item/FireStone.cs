using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gad20241013;
using UnityEditor;
using System.Runtime.CompilerServices;

namespace gad20241013.Item
{
    public class FireStone : IItem
    {
        int m_id;
        string m_productName;
        string m_displayName;
        string m_description;

        public int Id => m_id;
        public string ProductName => m_productName;
        public string DisplayName => m_displayName;
        public string Description => m_description;


        public FireStone()
        {
            m_id = 0;
            m_productName =  typeof(FireStone).Name;
            m_displayName = "�ق̂��̐�";
            m_description = "�M�C����΁B�X�f��ł������B" +
                "\n���ꂪ����΁A�X�[�A�C��R�ł��������ɍςށB";
        }
    }
}
