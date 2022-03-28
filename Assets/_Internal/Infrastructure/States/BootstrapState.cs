using _Internal.Infrastructure.AssetManagement;
using _Internal.Infrastructure.Factory;
using _Internal.Infrastructure.Services;
using _Internal.Infrastructure.Services.Input;
using UnityEngine;

namespace _Internal.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string BootSceneName = "BootScene";
        
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices allServices)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = allServices;
            
            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.LoadScene(BootSceneName, onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>("MainGameScene");
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<IInputService>(InputService());
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IGameFactory>(
                new GameFactory(_services.Single<IAssetProvider>()));
            
        }

        private static IInputService InputService()
        {
            if (Application.isEditor)
                return new StandaloneInputService();
            else
                return new MobileInputService();
        }
    }
}