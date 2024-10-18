using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gad20241013
{
    public interface IItemProvider
    {
        IItem GetItem(int id);

        int MaxItemNumber();
    }
}
