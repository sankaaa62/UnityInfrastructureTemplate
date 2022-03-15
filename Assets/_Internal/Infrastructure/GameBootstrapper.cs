using _Internal.Logic;
using UnityEngine;

namespace _Internal.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public LoadingCurtain LoadingCurtain;

        private Game _game;

        private void Awake()
        {
            _game = new Game(this, LoadingCurtain);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}