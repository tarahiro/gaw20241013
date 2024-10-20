using System.Collections;
using UnityEngine;

namespace Tarahiro.MasterData
{
    public abstract class MasterDataProvider<DataType, InterfaceType>
        : IMasterDataProvider<InterfaceType>
        where InterfaceType : IIndexable, IIdentifiable
        where DataType : InterfaceType
    {
        protected MasterDataOrderedDictionary<DataType, InterfaceType> m_Dictionary;

        public MasterDataProvider(string pathName)
        {
            m_Dictionary = Resources.Load<MasterDataOrderedDictionary<DataType, InterfaceType>>(pathName);
        }

        public InterfaceType TryGetFromIndex(int index)
        {
            return m_Dictionary.TryGetFromIndex(index);
        }

        public InterfaceType TryGetFromId(string id)
        {
            return m_Dictionary.TryGetFromId(id);
        }

        public int Count { get { return m_Dictionary.Count; } }
    }
}