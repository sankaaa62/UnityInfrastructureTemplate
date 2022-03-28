﻿using _Internal.Infrastructure.AssetManagement;
using UnityEngine;

namespace _Internal.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public GameObject CreatePlayerHero(GameObject at)
        {
            return _assetProvider.Instantiate(AssetPath.PlayerHeroPath, at.transform.position);
        }

        public void CreateHud()
        {
            _assetProvider.Instantiate(AssetPath.HudPath);
        }
    }
}