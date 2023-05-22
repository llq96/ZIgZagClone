using UnityEngine;
using VladB.ZigZag.MainPlayer;
using VladB.ZigZag.UI;

namespace VladB.ZigZag
{
    public class GameLifeCycle : MonoBehaviour
    {
        public GameState State { get; private set; }

        private Player _player;
        private UIController _uiController;

        public void Init(Player player, UIController uiController)
        {
            _player = player;
            _uiController = uiController;
        }

        public void StartGame()
        {
            State = GameState.Game;

            _player.StartMoving();
            _uiController.OpenWindow<GameWindow>();
        }

        public void ResetGame()
        {
            State = GameState.Start;

            _uiController.OpenWindow<StartWindow>();
            _player.ResetPlayer();
        }

        public void GameOver()
        {
            State = GameState.GameOver;
        }
    }

    public enum GameState
    {
        Start,
        Game,
        GameOver
    }
}