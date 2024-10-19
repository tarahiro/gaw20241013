using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace Tarahiro.MasterData
{
	/// <summary>
	/// リスト形式のマスターデータのScriptableObject基底クラスです。
	/// </summary>
	public class MasterDataList<T> 
		: ScriptableObject
		, IMasterDataList<T>
		where T : IIndexable
	{
		// データの実体
		[SerializeField] protected T[] m_List = null;

		// Indexからデータを取得
		public T TryGetFromIndex(int index)
		{
			if (index >= 0 && index < m_List.Length)
			{
				return m_List[index];
			}
			return default;
		}

		// データの数を取得
		public int Count => m_List.Length;

        // データをロードしてMasterDataProviderrに登録する
        protected static void InitializeImpl(IMasterDataProvider masterDataProvider, string dataPath)
		{
			var data = Resources.Load<MasterDataList<T>>(dataPath);
			Log.DebugAssert(data != null, $"ScriptableObjectの初期化に失敗しました。リソース：{dataPath} が存在しません。");
            masterDataProvider.Register<IMasterDataList<T>>(data);
		}

		// エディタ内でのデータ操作
#if UNITY_EDITOR
		public IReadOnlyList<T> SettableRecords { set { m_List = value.ToArray(); } }
#endif
	}
}
