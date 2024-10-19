using System;
using System.Collections.Generic;
using UniRx;
using Tarahiro.MasterData;

namespace Tarahiro
{
    public class MasterDataProvider : IMasterDataProvider
    {
        /// <summary>
        /// 指定した型のインスタンスを登録します。
        /// 同一の型を複数回登録することはできません。
        /// （登録を解除するIDisposableを返します。）
        /// </summary>
        public IDisposable Register<T>(T instance) where T : class
        {
            var unregisterable = TryRegister(out var registered, instance);
            if (!registered)
            {
                if (instance == null)
                {
                    Log.DebugWarning($"nullを {typeof(T)} として登録することはできません。");
                }
                else
                {
                    Log.DebugWarning($"指定された型: {typeof(T)} は既に登録されています。");
                }
            }
            return unregisterable;
        }

        /// <summary>
        /// 登録されている内容を消去します。
        /// </summary>
        public void Clear()
        {
            foreach (var type in s_RegisteredType)
            {
                var cacheType = typeof(Cache<>).MakeGenericType(type);
                cacheType.GetProperty("Instance").SetValue(cacheType, default, null);
            }

            s_RegisteredType.Clear();
        }

        /// <summary>
        /// 指定した型のインスタンスが登録されているかどうかを取得します。
        /// </summary>
        public bool IsRegistered<T>() where T : class
        {
            var instance = TryResolve<T>();
            return instance != null;
        }

        /// <summary>
        /// 指定した型のインスタンスを取得します。
        /// </summary>
        public T Resolve<T>() where T : class
        {
            var instance = TryResolve<T>();
            Log.DebugWarning(instance != null, $"ServiceLocatorに型: {typeof(T)} が登録されていません。");

            return instance;
        }

        /// <summary>
        /// 指定した型のインスタンスを1回だけ取得するオブザーバを取得します。
        /// （既に登録されている場合即座に返します。）
        /// </summary>
        public IObservable<T> ResolveAsync<T>() where T : class
        {
            var instance = TryResolve<T>();
            if (instance != null)
            {
                return Observable.Return(instance);
            }

            return Cache<T>.Registered.First().Select(_ => TryResolve<T>());
        }

        /// <summary>
        /// 指定した型のMasterDataListを取得する便利関数です。
        /// </summary>
        public IMasterDataList<T> ResolveList<T>() where T : IIndexable
        {
            var instance = TryResolve<IMasterDataList<T>>();
            Log.DebugWarning(instance != null, $"ServiceLocatorに型: {typeof(T)} のListが登録されていません。");

            return instance;
        }

        /// <summary>
        /// 指定した型のMasterDataOrderedDictionaryを取得する便利関数です。
        /// </summary>
        public IMasterDataOrderedDictionary<T> ResolveOrderedDictionary<T>() where T : IIndexable, IIdentifiable
        {
            var instance = TryResolve<IMasterDataOrderedDictionary<T>>();
            Log.DebugWarning(instance != null, $"ServiceLocatorに型: {typeof(T)} のOrderedDictionaryが登録されていません。");

            return instance;
        }

        #region private

        // 登録されたクラス
        static class Cache<T>
        {
            public static T Instance { get; set; } = default;
            public static ISubject<Unit> Registered { get; } = new Subject<Unit>();
        }

        // 登録された型の情報（一括クリア等に使う）
        HashSet<Type> s_RegisteredType = new HashSet<Type>();

        // 登録
        IDisposable TryRegister<T>(out bool registered, T instance)
        {
            if (instance == null)
            {
                registered = false;
                return Disposable.Empty;
            }

            if (s_RegisteredType.Contains(typeof(T)))
            {
                registered = false;
                return Disposable.Empty;
            }

            // 登録を行う
            s_RegisteredType.Add(typeof(T));
            Cache<T>.Instance = instance;
            Cache<T>.Registered.OnNext(default);

            registered = true;
            return Disposable.Create(() =>
            {
                // 登録を解除する
                Cache<T>.Instance = default;
                s_RegisteredType.Remove(typeof(T));
            });
        }

        // 取得
        T TryResolve<T>() where T : class
        {
            if (s_RegisteredType.Contains(typeof(T)))
            {
                return Cache<T>.Instance;
            }

            return null;
        }

        #endregion
    }
}
