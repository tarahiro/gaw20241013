using System;
using System.Collections.Generic;
using UniRx;
using Tarahiro.MasterData;

namespace Tarahiro
{
    public class MasterDataProvider : IMasterDataProvider
    {
        /// <summary>
        /// w’è‚µ‚½Œ^‚ÌƒCƒ“ƒXƒ^ƒ“ƒX‚ğ“o˜^‚µ‚Ü‚·B
        /// “¯ˆê‚ÌŒ^‚ğ•¡”‰ñ“o˜^‚·‚é‚±‚Æ‚Í‚Å‚«‚Ü‚¹‚ñB
        /// i“o˜^‚ğ‰ğœ‚·‚éIDisposable‚ğ•Ô‚µ‚Ü‚·Bj
        /// </summary>
        public IDisposable Register<T>(T instance) where T : class
        {
            var unregisterable = TryRegister(out var registered, instance);
            if (!registered)
            {
                if (instance == null)
                {
                    Log.DebugWarning($"null‚ğ {typeof(T)} ‚Æ‚µ‚Ä“o˜^‚·‚é‚±‚Æ‚Í‚Å‚«‚Ü‚¹‚ñB");
                }
                else
                {
                    Log.DebugWarning($"w’è‚³‚ê‚½Œ^: {typeof(T)} ‚ÍŠù‚É“o˜^‚³‚ê‚Ä‚¢‚Ü‚·B");
                }
            }
            return unregisterable;
        }

        /// <summary>
        /// “o˜^‚³‚ê‚Ä‚¢‚é“à—e‚ğÁ‹‚µ‚Ü‚·B
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
        /// w’è‚µ‚½Œ^‚ÌƒCƒ“ƒXƒ^ƒ“ƒX‚ª“o˜^‚³‚ê‚Ä‚¢‚é‚©‚Ç‚¤‚©‚ğæ“¾‚µ‚Ü‚·B
        /// </summary>
        public bool IsRegistered<T>() where T : class
        {
            var instance = TryResolve<T>();
            return instance != null;
        }

        /// <summary>
        /// w’è‚µ‚½Œ^‚ÌƒCƒ“ƒXƒ^ƒ“ƒX‚ğæ“¾‚µ‚Ü‚·B
        /// </summary>
        public T Resolve<T>() where T : class
        {
            var instance = TryResolve<T>();
            Log.DebugWarning(instance != null, $"ServiceLocator‚ÉŒ^: {typeof(T)} ‚ª“o˜^‚³‚ê‚Ä‚¢‚Ü‚¹‚ñB");

            return instance;
        }

        /// <summary>
        /// w’è‚µ‚½Œ^‚ÌƒCƒ“ƒXƒ^ƒ“ƒX‚ğ1‰ñ‚¾‚¯æ“¾‚·‚éƒIƒuƒU[ƒo‚ğæ“¾‚µ‚Ü‚·B
        /// iŠù‚É“o˜^‚³‚ê‚Ä‚¢‚éê‡‘¦À‚É•Ô‚µ‚Ü‚·Bj
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
        /// w’è‚µ‚½Œ^‚ÌMasterDataList‚ğæ“¾‚·‚é•Ö—˜ŠÖ”‚Å‚·B
        /// </summary>
        public IMasterDataList<T> ResolveList<T>() where T : IIndexable
        {
            var instance = TryResolve<IMasterDataList<T>>();
            Log.DebugWarning(instance != null, $"ServiceLocator‚ÉŒ^: {typeof(T)} ‚ÌList‚ª“o˜^‚³‚ê‚Ä‚¢‚Ü‚¹‚ñB");

            return instance;
        }

        /// <summary>
        /// w’è‚µ‚½Œ^‚ÌMasterDataOrderedDictionary‚ğæ“¾‚·‚é•Ö—˜ŠÖ”‚Å‚·B
        /// </summary>
        public IMasterDataOrderedDictionary<T> ResolveOrderedDictionary<T>() where T : IIndexable, IIdentifiable
        {
            var instance = TryResolve<IMasterDataOrderedDictionary<T>>();
            Log.DebugWarning(instance != null, $"ServiceLocator‚ÉŒ^: {typeof(T)} ‚ÌOrderedDictionary‚ª“o˜^‚³‚ê‚Ä‚¢‚Ü‚¹‚ñB");

            return instance;
        }

        #region private

        // “o˜^‚³‚ê‚½ƒNƒ‰ƒX
        static class Cache<T>
        {
            public static T Instance { get; set; } = default;
            public static ISubject<Unit> Registered { get; } = new Subject<Unit>();
        }

        // “o˜^‚³‚ê‚½Œ^‚Ìî•ñiˆêŠ‡ƒNƒŠƒA“™‚Ég‚¤j
        HashSet<Type> s_RegisteredType = new HashSet<Type>();

        // “o˜^
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

            // “o˜^‚ğs‚¤
            s_RegisteredType.Add(typeof(T));
            Cache<T>.Instance = instance;
            Cache<T>.Registered.OnNext(default);

            registered = true;
            return Disposable.Create(() =>
            {
                // “o˜^‚ğ‰ğœ‚·‚é
                Cache<T>.Instance = default;
                s_RegisteredType.Remove(typeof(T));
            });
        }

        // æ“¾
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
