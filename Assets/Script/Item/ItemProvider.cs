using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using gad20241013;
using Tarahiro.MasterData;

namespace gad20241013.Item { 
    public class ItemProvider : ISomethingProvider<IItem>
    {
        List<IItem> itemList;

        public ItemProvider(IItemMasterDataProvider masterDataProvider)
        {
            itemList = new List<IItem>();

            for(int i = 0;i < masterDataProvider.Count; i++)
            {
                itemList.Add(new Item(masterDataProvider.TryGetFromIndex(i).GetMaster()));
            }
        }

        /// <summary>
        /// Indexからデータを取得します。
        /// </summary>
        public IItem TryGetFromIndex(int index)
        {
            return itemList[index];
        }

        /// <summary>
        /// IDからデータを取得します。
        /// </summary>
        public IItem TryGetFromId(string id)
        {
            return itemList.First(x => x.Id == id);
        }

        /// <summary>
        /// データの総数を取得します。
        /// </summary>
        public int Count => itemList.Count;
    }
}
