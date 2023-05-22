using UnityEngine;
using VladB.Utility;

namespace VladB.Utility
{
    public class UIWindow : MonoBehaviour, IUIWindow
    {
        public virtual bool IsOpened { get; set; }

        public virtual void Open()
        {
            if (gameObject)
            {
                gameObject.SetActive(true);
            }

            IsOpened = true;
        }

        public virtual void Close()
        {
            if (gameObject)
            {
                gameObject.SetActive(false);
            }

            IsOpened = false;
        }

        public virtual void Init()
        {
        }
    }
}