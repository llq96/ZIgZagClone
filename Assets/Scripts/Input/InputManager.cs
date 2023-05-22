using UnityEngine;
using VladB.ZigZag;
using VladB.ZigZag.MainPlayer;

public class InputManager : MonoBehaviour
{
    private GameLifeCycle _gameLifeCycle;
    private Player _player;

    public void Init(GameLifeCycle gameLifeCycle, Player player)
    {
        _gameLifeCycle = gameLifeCycle;
        _player = player;
    }

    public void GameWindowTap()
    {
        if (_gameLifeCycle.State == GameState.Game)
        {
            _player.PlayerComponents.Mover.SwitchDirection();
        }
    }
}