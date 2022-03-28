using _Internal.CameraLogic;
using _Internal.Infrastructure.Factory;
using _Internal.Logic;
using UnityEngine;

namespace _Internal.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;


        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _sceneLoader.LoadScene(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _loadingCurtain.Hide();
        }

        private void OnLoaded()
        {
            var initialPoint = GameObject.FindWithTag(InitialPointTag);
            var playerHero = _gameFactory.CreatePlayerHero(at: initialPoint);
            
            //TO DO
            SetCameraFollowTarget(playerHero.transform);

            _gameFactory.CreateHud();
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void SetCameraFollowTarget(Transform target)
        {
            var camera = Camera.main;
            if (camera != null) 
                camera.GetComponent<Follower>().Target = target;
        }
    }
}