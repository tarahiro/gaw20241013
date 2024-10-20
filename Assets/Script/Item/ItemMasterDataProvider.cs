using System.Collections;
using UnityEngine;
using Tarahiro.MasterData;

namespace gad20241013.Item
{
    public class ItemMasterDataProvider :MasterDataProvider<ItemMasterData.Record, IMasterDataRecord <IItemMaster>>, IItemMasterDataProvider
    {
        protected override string m_pathName => "Data/Item";
    }
}