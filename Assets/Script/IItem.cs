using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gad20241013
{
    public interface IItem
    {
        public int Id { get; }
        string ProductName { get; }
        string DisplayName { get; }
        string Description { get; }
    }
}