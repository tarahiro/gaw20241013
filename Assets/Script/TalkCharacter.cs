
using UnityEngine;

namespace gad20241013
{
    public class Doctor :ITalkCharacter
    {
        string m_name;
        Color m_color;

        public string Name => m_name;
        public Color NameColor => m_color;

        public Doctor()
        {
            Debug.Log("スライム生成");

            m_name = "ドクター";
            m_color = Color.blue;
        }

    }
}
