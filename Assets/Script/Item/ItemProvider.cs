using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using gad20241013;

namespace gad20241013.Item { 
    public class ItemProvider : IItemProvider
    {
        List<IItem> itemMaster;

        public ItemProvider()
        {
            itemMaster = new List<IItem>();
            itemMaster.Add(new FireStone());
            itemMaster.Add(new IceStone());
            itemMaster.Add(new WindStone());
            itemMaster.Add(new PastMirror());
            itemMaster.Add(new FutureMirror());
            itemMaster.Add(new GreatBar());
            itemMaster.Add(new PoisonCure());
            itemMaster.Add(new ParalysisCure());

            //マスターデータチェック
            for (int i = 0; i < itemMaster.Count; i++)
            {
                for (int j = i + 1; j < itemMaster.Count; j++)
                {
                    if (itemMaster[i].Id == itemMaster[j].Id)
                    {
                        Debug.Log(itemMaster[i].ProductName + "と" +  itemMaster[j].ProductName + "のIdが重複しています");
                    }
                    if (itemMaster[i].ProductName == itemMaster[j].ProductName)
                    {
                        Debug.Log(itemMaster[i].Id + "のアイテムと" + itemMaster[j].Id + "のアイテムのProductNameが重複しています");
                    }
                }
            }
        }

        public IItem GetItem(int id)
        {
            if (id < 0 || id >= itemMaster.Count)
            {
                Debug.Log("不正な値です");
                return null;
            }

            return itemMaster[id];
        }

        public int MaxItemNumber()
        {
            return itemMaster.Count;
        }
    }
}
