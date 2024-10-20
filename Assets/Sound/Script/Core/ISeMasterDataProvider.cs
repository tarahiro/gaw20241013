using System.Collections;
using UnityEngine;

namespace Tarahiro.Sound
{
    public interface ISeMasterDataProvider
    {
        ISeMaster TryGetValueFromId(string id);
    }
}