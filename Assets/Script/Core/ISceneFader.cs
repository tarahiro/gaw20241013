using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace gad20241013
{
    public interface ISceneFader
    {
        UniTask SceneStart();

        UniTask SceneEnd();
    }
}
