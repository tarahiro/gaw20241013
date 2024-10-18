using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cysharp.Threading.Tasks;
using NUnit.Framework.Internal.Commands;

namespace gad20241013.ItemSelector
{
    public interface IItemMenu
    {
        UniTask Enter();

        IObservable<int> Decided { get; }

        //↓はIItemMenu特有
        void SetItemList(List<IItem> items);
    }
}
