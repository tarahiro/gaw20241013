using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gad20241013
{
    public interface IItem
    {
        string Id { get; }
        string DisplayName { get; }
        string Description { get; }
        string SpritePath { get; }
    }
}