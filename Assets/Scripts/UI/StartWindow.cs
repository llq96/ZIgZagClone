using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VladB.Utility;

namespace VladB.ZigZag.UI
{
    public class StartWindow : UIWindow
    {
        [SerializeField] private Button _button_startGame;

        public void Init(GameLifeCycle gameLifeCycle)
        {
            _button_startGame.onClick.AddListener(gameLifeCycle.StartGame);
        }
    }
}