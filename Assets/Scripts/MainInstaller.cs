using System;
using UnityEngine;
using Zenject;

namespace VladB.ZigZag
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private TilesMaterialsHelper _tilesMaterialsHelper;
        [SerializeField] private Player _player;

        public override void InstallBindings()
        {
            Container.Bind<TilesMaterialsHelper>().FromInstance(_tilesMaterialsHelper).AsSingle().NonLazy();
            Container.Bind<Player>().FromInstance(_player).AsSingle().NonLazy();
        }

        public override void Start()
        {
            Init();
            StartGame();
        }

        private void Init()
        {
            _tilesMaterialsHelper.Init(Container.Resolve<Player>().transform);
        }

        private void StartGame()
        {
        }
    }
}