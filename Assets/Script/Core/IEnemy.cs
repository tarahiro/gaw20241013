using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace gad20241013
{
    public interface IEnemy : ITalkCharacter
    {
        UniTask EnterRoom();

        UniTask ExitRoom();
    }

}