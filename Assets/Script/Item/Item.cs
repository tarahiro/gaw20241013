using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gad20241013;

namespace gad20241013.Item
{
    public class Item:IItem
    {
        string m_Id;
        string m_DisplayName;
        string m_Description;
        string m_SpritePath;

        public Item(IItemMaster itemMaster)
        {
            m_Id = itemMaster.Id;
            m_DisplayName = itemMaster.DisplayName;
            m_Description = itemMaster.Description;
            m_SpritePath = itemMaster.SpritePath;
        }

        public string Id => m_Id;
        public string DisplayName => m_DisplayName;
        public string Description => m_Description;
        public string SpritePath => m_SpritePath;
    }
}
