using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gad20241013
{
    public interface ISomethingProvider<T>
    {
        /// <summary>
        /// Indexからデータを取得します。
        /// <para> * 存在しない場合、Tのdefaultを返します。</para>
        /// </summary>
        T TryGetFromIndex(int index);

        /// <summary>
        /// IDからデータを取得します。
        /// <para> * 存在しない場合、Tのdefaultを返します。</para>
        /// </summary>
        T TryGetFromId(string id);

        /// <summary>
        /// データの総数を取得します。
        /// </summary>
        int Count { get; }

    }
}
