
using Tarahiro;
using Tarahiro.MasterData;
using System;
using UnityEngine;
using System.Collections.Generic;

namespace gad20241013.Item
{
    public class ItemMasterData : MasterDataOrderedDictionary<ItemMasterData.Record, IItemMasterDataRecord>
    {
        public const string c_DataPath = "Data/Item";

        [Serializable]
        public class Record : IItemMasterDataRecord, IItemMaster
        {
            public Record(int index, string id)
            {
                m_Index = index;
                m_Id = id;
                m_IdInt = int.Parse(id);
            }

            [SerializeField] int m_Index;
            [SerializeField] string m_Id;
            [SerializeField] int m_IdInt;
            [SerializeField] string m_TitleName;
            [SerializeField] string m_GenreName;
            [SerializeField] string m_DescriptionName;
            [SerializeField] string m_IconPath;
            [SerializeField] string m_ScreenShotCenterPath;
            [SerializeField] string m_ScreenShotRightTopPath;
            [SerializeField] string m_ScreenShotRightButtomPath;

            public int Index => m_Index;
            public string Id => m_Id;
            int IItemMaster.Id => m_IdInt;
            public string TitleName => m_TitleName;
            public string GenreName => m_GenreName;
            public string DescriptionName => m_DescriptionName;
            public string IconPath => m_IconPath;
            public string ScreenShotCenterPath => m_ScreenShotCenterPath;
            public string ScreenShotRightTopPath => m_ScreenShotRightTopPath;
            public string ScreenShotRightButtonPath => m_ScreenShotRightButtomPath;

            public IItemMaster GetMaster() => this;

#if UNITY_EDITOR
            public string SettableTitleName { set => m_TitleName = value; }
            public string SettableGenreName { set => m_GenreName = value; }
            public string SettableDescriptionName { set => m_DescriptionName = value; }
            public string SettableIconPath { set => m_IconPath = value; }
            public string SettableScreenShotCenterPath { set => m_ScreenShotCenterPath = value; }
            public string SettableScreenShotRightTopPath { set => m_ScreenShotRightTopPath = value; }
            public string SettableScreenShotRightButtomPath { set => m_ScreenShotRightButtomPath = value; } 

#endif
        }
    }
}
