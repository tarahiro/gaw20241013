using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tarahiro.MasterData;

namespace gad20241013.Item
{
    public class ItemMasterDataProvider : MasterDataProvider<ItemMasterData.Record, IItemMasterDataRecord>
    {

        const string c_PathName = "Data/Item";

        protected override string m_PathName => c_PathName;
    }
}
