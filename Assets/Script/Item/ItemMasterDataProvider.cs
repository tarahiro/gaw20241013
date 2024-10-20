using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tarahiro.MasterData;

namespace gad20241013.Item
{
    public class ItemMasterDataProvider : MasterDataProvider<ItemMasterData.Record, IMasterDataRecord<IItemMaster>>
    {
        public ItemMasterDataProvider(string pathName) : base (pathName) { 
        }
    }
}
