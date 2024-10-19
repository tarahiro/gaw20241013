using System;
using System.Collections.Generic;
using UniRx;
using Tarahiro.MasterData;

namespace Tarahiro
{
    public class MasterDataProvider : IMasterDataProvider
    {
        /// <summary>
        /// �w�肵���^�̃C���X�^���X��o�^���܂��B
        /// ����̌^�𕡐���o�^���邱�Ƃ͂ł��܂���B
        /// �i�o�^����������IDisposable��Ԃ��܂��B�j
        /// </summary>
        public IDisposable Register<T>(T instance) where T : class
        {
            var unregisterable = TryRegister(out var registered, instance);
            if (!registered)
            {
                if (instance == null)
                {
                    Log.DebugWarning($"null�� {typeof(T)} �Ƃ��ēo�^���邱�Ƃ͂ł��܂���B");
                }
                else
                {
                    Log.DebugWarning($"�w�肳�ꂽ�^: {typeof(T)} �͊��ɓo�^����Ă��܂��B");
                }
            }
            return unregisterable;
        }

        /// <summary>
        /// �o�^����Ă�����e���������܂��B
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
        /// �w�肵���^�̃C���X�^���X���o�^����Ă��邩�ǂ������擾���܂��B
        /// </summary>
        public bool IsRegistered<T>() where T : class
        {
            var instance = TryResolve<T>();
            return instance != null;
        }

        /// <summary>
        /// �w�肵���^�̃C���X�^���X���擾���܂��B
        /// </summary>
        public T Resolve<T>() where T : class
        {
            var instance = TryResolve<T>();
            Log.DebugWarning(instance != null, $"ServiceLocator�Ɍ^: {typeof(T)} ���o�^����Ă��܂���B");

            return instance;
        }

        /// <summary>
        /// �w�肵���^�̃C���X�^���X��1�񂾂��擾����I�u�U�[�o���擾���܂��B
        /// �i���ɓo�^����Ă���ꍇ�����ɕԂ��܂��B�j
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
        /// �w�肵���^��MasterDataList���擾����֗��֐��ł��B
        /// </summary>
        public IMasterDataList<T> ResolveList<T>() where T : IIndexable
        {
            var instance = TryResolve<IMasterDataList<T>>();
            Log.DebugWarning(instance != null, $"ServiceLocator�Ɍ^: {typeof(T)} ��List���o�^����Ă��܂���B");

            return instance;
        }

        /// <summary>
        /// �w�肵���^��MasterDataOrderedDictionary���擾����֗��֐��ł��B
        /// </summary>
        public IMasterDataOrderedDictionary<T> ResolveOrderedDictionary<T>() where T : IIndexable, IIdentifiable
        {
            var instance = TryResolve<IMasterDataOrderedDictionary<T>>();
            Log.DebugWarning(instance != null, $"ServiceLocator�Ɍ^: {typeof(T)} ��OrderedDictionary���o�^����Ă��܂���B");

            return instance;
        }

        #region private

        // �o�^���ꂽ�N���X
        static class Cache<T>
        {
            public static T Instance { get; set; } = default;
            public static ISubject<Unit> Registered { get; } = new Subject<Unit>();
        }

        // �o�^���ꂽ�^�̏��i�ꊇ�N���A���Ɏg���j
        HashSet<Type> s_RegisteredType = new HashSet<Type>();

        // �o�^
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

            // �o�^���s��
            s_RegisteredType.Add(typeof(T));
            Cache<T>.Instance = instance;
            Cache<T>.Registered.OnNext(default);

            registered = true;
            return Disposable.Create(() =>
            {
                // �o�^����������
                Cache<T>.Instance = default;
                s_RegisteredType.Remove(typeof(T));
            });
        }

        // �擾
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
