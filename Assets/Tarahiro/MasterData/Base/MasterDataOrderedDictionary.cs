﻿using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Tarahiro.MasterData
{
	/// <summary>
	/// 辞書形式のマスターデータのScriptableObject基底クラスです。
	/// </summary>
	public class MasterDataOrderedDictionary<DataType, InterfaceType>
		: ScriptableObject
		, ISerializationCallbackReceiver
		, IMasterDataOrderedDictionary<InterfaceType>
        where InterfaceType : IIndexable, IIdentifiable
		where DataType : InterfaceType
	{	
		//Dictionaryの実体

		// データの実体
		[SerializeField] protected DataType[] m_List = null;
		[SerializeField] protected Dictionary<string, int> m_Dictionary = null;

		// Indexからデータを取得
		public InterfaceType TryGetFromIndex(int index)
		{
			if (index >= 0 && index < m_List.Length)
			{
				return m_List[index];
			}
			return default;
		}

		// Idからデータを取得
		public InterfaceType TryGetFromId(string id)
		{
			if (m_Dictionary.ContainsKey(id))
			{
				return m_List[m_Dictionary[id]];
			}
			return default;
		}

		// データの数を取得
		public int Count => m_List.Length;

		// データの列挙子を取得
		public IEnumerable<InterfaceType> Enumerable => m_List.Select<DataType, InterfaceType>(data => data);

        // データをロードしてMasterDataProviderに登録する
        protected void InitializeImpl(string dataPath)
		{
			var data = Resources.Load<MasterDataOrderedDictionary<DataType, InterfaceType>>(dataPath);
			m_List = data.m_List;
            m_Dictionary = data.m_Dictionary;
			Log.DebugAssert(data != null, $"ScriptableObjectの初期化に失敗しました。リソース：{dataPath} が存在しません。");
			// masterDataProvider.Register<IMasterDataOrderedDictionary<InterfaceType>>(data);
		}

		// エディタ内でのデータ操作
#if UNITY_EDITOR
		public IReadOnlyList<DataType> SettableRecords
		{
			set
			{
				m_List = value.ToArray();
			}
		}
#endif

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
			m_Dictionary = new Dictionary<string, int>();
			foreach (var data in m_List)
			{
				m_Dictionary.Add(data.Id, data.Index);
			}
		}
	}
}
