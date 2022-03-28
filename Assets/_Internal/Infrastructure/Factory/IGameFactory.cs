using _Internal.Infrastructure.Services;
using UnityEngine;

namespace _Internal.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayerHero(GameObject at);
        void CreateHud();
    }
}