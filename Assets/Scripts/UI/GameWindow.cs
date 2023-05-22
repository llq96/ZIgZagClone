using UnityEngine;
using UnityEngine.UI;
using VladB.Utility;

namespace VladB.ZigZag.UI
{
    public class GameWindow : UIWindow
    {
        [SerializeField] private Button _button_tap; //TODO Switch to EventTrigger

        public void Init(InputManager inputManager)
        {
            _button_tap.onClick.AddListener(inputManager.GameWindowTap);
        }
    }
}