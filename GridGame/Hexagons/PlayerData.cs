using GridGame.GameManagers;
using GridGame.Resources;
using GridGame.TextureLoading;
using GridGame.Tiles.Buildings.BuildingClasses;
using GridGame.Units.UnitClasses;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons {
    public class PlayerData {

        public bool CityBuilt;
        
        public (int, int) city;
        public HashSet<(int, int)> BuildingTiles;
        public Queue<(int, int)> UnfinishedBuildingTiles;
        public bool SpentGold;

        private HexMap hexMap;

        private ContentLoader content;
        public PlayerResources playerResources;

        public PlayerData(PlayerResources playerResources, HexMap hexMap) {
            this.playerResources = playerResources;
            this.hexMap = hexMap;
            
            CityBuilt = false;
            BuildingTiles = new HashSet<(int, int)>();
            UnfinishedBuildingTiles = new Queue<(int, int)>();
            SpentGold = false;
        }

        public void UpdateProduction(GameTime gameTime, DisplayManager displayManager) {
            if(UnfinishedBuildingTiles.Count > 0 && playerResources.GetResourceAmount(ResourceType.Production) > 0) {
                AddProduction(playerResources.GetResourceAmount(ResourceType.Production));
                displayManager.resourceManager.resourceDisplay.UpdateResource(ResourceType.Production, playerResources);
            }
            if(SpentGold) {
                displayManager.resourceManager.resourceDisplay.UpdateResource(ResourceType.Gold, playerResources);
                SpentGold = false;
            }
        }

        public void AddProduction(int production) {
            if(UnfinishedBuildingTiles.Count == 0) return;

            int extra = hexMap.Tiles[(UnfinishedBuildingTiles.First())].AddProduction(production);
            if(!hexMap.Tiles[(UnfinishedBuildingTiles.First())].IsBuilding()) {
                UnfinishedBuildingTiles.Dequeue();
            }
            playerResources.SubtractResource(ResourceType.Production, production);
            playerResources.AddResource(ResourceType.Production, extra);
        }

    }
}
