using UnityEngine;
using Zenject;
using VladB.ZigZag.MainPlayer;
using VladB.ZigZag.UI;

namespace VladB.ZigZag
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private TilesMaterialsHelper _tilesMaterialsHelper;
        [SerializeField] private Player _player;
        [SerializeField] private GameCamera _gameCamera;
        [SerializeField] private GameLifeCycle _gameLifeCycle;
        [SerializeField] private UIController _uiController;
        [SerializeField] private InputManager _inputManager;

        public override void InstallBindings()
        {
            Container.Bind<TilesMaterialsHelper>().FromInstance(_tilesMaterialsHelper).AsSingle().NonLazy();
            Container.Bind<Player>().FromInstance(_player).AsSingle().NonLazy();
            Container.Bind<GameCamera>().FromInstance(_gameCamera).AsSingle().NonLazy();
            Container.Bind<GameLifeCycle>().FromInstance(_gameLifeCycle).AsSingle().NonLazy();
            Container.Bind<UIController>().FromInstance(_uiController).AsSingle().NonLazy();
            Container.Bind<InputManager>().FromInstance(_inputManager).AsSingle().NonLazy();
        }

        public override void Start()
        {
            Init();
            StartGame();
        }

        private void Init()
        {
            Container.Resolve<InputManager>().Init(Container.Resolve<GameLifeCycle>(), Container.Resolve<Player>());
            Container.Resolve<UIController>().Init();
            Container.Resolve<UIController>().StartWindow.Init(Container.Resolve<GameLifeCycle>());
            Container.Resolve<UIController>().GameWindow.Init(Container.Resolve<InputManager>());
            Container.Resolve<Player>().Init();
            Container.Resolve<GameCamera>().Init(Container.Resolve<Player>().transform);
            Container.Resolve<TilesMaterialsHelper>().Init(Container.Resolve<Player>().transform);
            Container.Resolve<GameLifeCycle>().Init(Container.Resolve<Player>(), Container.Resolve<UIController>());
        }

        private void StartGame()
        {
            Container.Resolve<GameLifeCycle>().ResetGame();
        }
    }
}