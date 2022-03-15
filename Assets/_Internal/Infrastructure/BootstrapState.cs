using _Internal.Infrastructure.Services.Input;
using UnityEngine;

namespace _Internal.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string BootSceneName = "BootScene";
        
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.LoadScene(BootSceneName, onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
             
        }

        private void RegisterServices()
        {
            Game.InputService = RegisterInputService();
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>("MainGameScene");
        }

        private static IInputService RegisterInputService()
        {
            if (Application.isEditor)
                return new StandaloneInputService();
            else
                return new MobileInputService();
        }
    }
}