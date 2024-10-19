using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Tarahiro
{
    public interface IMasterDataProvider
    {
        IDisposable Register<T>(T instance) where T : class;

        void Clear();

        bool IsRegistered<T>() where T : class;

        T Resolve<T>() where T : class;

        IObservable<T> ResolveAsync<T>() where T : class;

        IMasterDataList<T> ResolveList<T>() where T : IIndexable;

        IMasterDataOrderedDictionary<T> ResolveOrderedDictionary<T>() where T : IIndexable, IIdentifiable;
    }
}
