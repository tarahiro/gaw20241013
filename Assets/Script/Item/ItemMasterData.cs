
using Tarahiro;
using Tarahiro.MasterData;
using System;
using UnityEngine;
using System.Collections.Generic;

namespace gad20241013.Item
{
    public class ItemMasterData : MasterDataOrderedDictionary<ItemMasterData.Record, IMasterDataRecord<IItemMaster>> { 
        public const string c_DataPath = "Data/Item";

        [Serializable]
        public class Record : IMasterDataRecord<IItemMaster>, IItemMaster
        {
            public Record(int index, string id)
            {
                m_Index = index;
                m_Id = id;
            }

            [SerializeField] int m_Index;
            [SerializeField] string m_Id;
            [SerializeField] string m_DisplayName;
            [SerializeField] string m_Description;
            [SerializeField] string m_SpritePath;


            public int Index => m_Index;
            public string Id => m_Id;
            public string DisplayName => m_DisplayName;
            public string Description => m_Description;
            public string SpritePath => m_SpritePath;

            public IItemMaster GetMaster() => this;

#if UNITY_EDITOR
            public string SettableDisplayName { set => m_DisplayName = value; }
            public string SettableDescription { set => m_Description = value; }
            public string SettableSpritePath { set => m_SpritePath = value; }

#endif
        }
    }
}
