using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tarahiro.MasterData;

namespace gad20241013.Item
{
    public class ItemMasterDataProvider : MasterDataProvider<ItemMasterData.Record, IItemMasterDataRecord>
    {

        protected override string m_PathName => ItemMasterData.c_DataPath;
    }
}
