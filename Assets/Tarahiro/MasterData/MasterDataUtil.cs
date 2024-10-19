using System;

namespace Tarahiro
{
    public static class MasterDataUtil
    {
        public static IDisposable Register<CollectionType>(IMasterDataProvider masterDataProvider, CollectionType data) where CollectionType : class
        {
            return masterDataProvider.Register<CollectionType>(data);
        }
    }
}
