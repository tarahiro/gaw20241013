using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace gad20241013.ItemSelector
{
    public interface IItemMenuItem
    {

        void SetPosition(Vector2 vector2);

        void SetSprite(Sprite sprite);

        void SetName(string s);

        void Focus();

        void UnFocus();

        void Destroy();
    }
}
