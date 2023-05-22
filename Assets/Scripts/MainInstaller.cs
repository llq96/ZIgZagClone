using UnityEngine;
using Zenject;
using VladB.ZigZag.MainPlayer;

namespace VladB.ZigZag
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private TilesMaterialsHelper _tilesMaterialsHelper;
        [SerializeField] private Player _player;
        [SerializeField] private GameCamera _gameCamera;

        public override void InstallBindings()
        {
            Container.Bind<TilesMaterialsHelper>().FromInstance(_tilesMaterialsHelper).AsSingle().NonLazy();
            Container.Bind<Player>().FromInstance(_player).AsSingle().NonLazy();
            Container.Bind<GameCamera>().FromInstance(_gameCamera).AsSingle().NonLazy();
        }

        public override void Start()
        {
            Init();
            StartGame();
        }

        private void Init()
        {
            Container.Resolve<Player>().Init();
            Container.Resolve<GameCamera>().Init(Container.Resolve<Player>().transform);
            Container.Resolve<TilesMaterialsHelper>().Init(Container.Resolve<Player>().transform);
        }

        private void StartGame()
        {
        }
    }
}