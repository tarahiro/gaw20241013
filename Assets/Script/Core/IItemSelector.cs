using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace gad20241013
{
    public interface IItemSelector
    {
        UniTask RunItemDialog(IItemReceivable itemReceivable);
    }
}