using _Internal.Infrastructure.Services;
using _Internal.Infrastructure.States;
using _Internal.Logic;

namespace _Internal.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain, AllServices services)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingCurtain, services);
        }
    }
}