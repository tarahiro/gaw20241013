using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cysharp.Threading.Tasks;

namespace gad20241013
{
    public interface ITalkManager
    {
        UniTask Talk(TalkSource source);
    }
}
