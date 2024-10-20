using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gad20241013
{
    public interface ITalkCharacter
    {
        string Name { get; }

        Color NameColor { get; }
    }
}