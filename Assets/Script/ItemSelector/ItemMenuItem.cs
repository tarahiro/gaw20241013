using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace gad20241013.ItemSelector
{
    public class ItemMenuItem : MonoBehaviour,IItemMenuItem
    {
        [SerializeField] Image m_itemIcon;
        [SerializeField] TextMeshProUGUI m_itemName;
        [SerializeField] GameObject m_focusObject;



       public void SetPosition(Vector2 vector2)
        {
            transform.localPosition = vector2;
        }

       public void SetSprite(Sprite sprite)
        {
            m_itemIcon.sprite = sprite;
        }

        public void SetName(string s)
        {
            m_itemName.text = s;
        }

        public void Focus()
        {
            m_focusObject.SetActive(true);
        }

        public void UnFocus()
        {
            m_focusObject.SetActive(false);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
