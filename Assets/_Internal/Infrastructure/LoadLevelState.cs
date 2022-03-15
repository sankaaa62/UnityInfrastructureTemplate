using _Internal.CameraLogic;
using _Internal.Logic;
using UnityEngine;

namespace _Internal.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPointTag = "InitialPoint";
        private const string PlayerHeroPath = "PlayerHero/PlayerHero";
        private const string HudPath = "Hud/Hud";

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;


        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
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
            var playerHero = Instantiate(PlayerHeroPath, at: initialPoint.transform.position);
            SetCameraFollowTarget(playerHero.transform);
            
            Instantiate(HudPath);
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        private static GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }
        
        private static GameObject Instantiate(string path, Vector3 at)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }
        
        private void SetCameraFollowTarget(Transform target)
        {
            var camera = Camera.main;
            if (camera != null) 
                camera.GetComponent<Follower>().Target = target;
        }
    }
}