using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gad20241013
{
    public interface ISomethingProvider<T>
    {
        /// <summary>
        /// Index����f�[�^���擾���܂��B
        /// <para> * ���݂��Ȃ��ꍇ�AT��default��Ԃ��܂��B</para>
        /// </summary>
        T TryGetFromIndex(int index);

        /// <summary>
        /// ID����f�[�^���擾���܂��B
        /// <para> * ���݂��Ȃ��ꍇ�AT��default��Ԃ��܂��B</para>
        /// </summary>
        T TryGetFromId(string id);

        /// <summary>
        /// �f�[�^�̑������擾���܂��B
        /// </summary>
        int Count { get; }

    }
}
