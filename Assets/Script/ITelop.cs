using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using gad20241013;

namespace gad20241013
{
    public interface ITelop
    {
        UniTask Enter();
    }
}
