using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VladB.ZigZag.UI
{
    public class UIController : VladB.Utility.UIController
    {
        [SerializeField] private StartWindow _startWindow;
        public StartWindow StartWindow => _startWindow;

        [SerializeField] private GameWindow _gameWindow;
        public GameWindow GameWindow => _gameWindow;

        public override void Init()
        {
            base.Init();
        }
    }
}