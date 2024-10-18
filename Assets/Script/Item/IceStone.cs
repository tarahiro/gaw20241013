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
            m_displayName = "������̐�";
            m_description = "��C����΁B���f��ł������B" +
                "\n���ꂪ����΁A���C�t�@�[�R�̉Ό��T�����ւ������B";
        }
    }
}
