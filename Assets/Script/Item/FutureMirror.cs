using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gad20241013;
using UnityEditor;
using System.Runtime.CompilerServices;

namespace gad20241013.Item
{
    public class FutureMirror : IItem
    {
        int m_id;
        string m_productName;
        string m_displayName;
        string m_description;

        public int Id => m_id;
        public string ProductName => m_productName;
        public string DisplayName => m_displayName;
        public string Description => m_description;


        public FutureMirror()
        {
            m_id = 4;
            m_productName =  typeof(FutureMirror).Name;
            m_displayName = "みらいの魔鏡";
            m_description = "今はまだ存在しない素材で作られた、魔力の込められた鏡。\n目の前のものの未来の姿を映し出す。";
        }
    }
}
