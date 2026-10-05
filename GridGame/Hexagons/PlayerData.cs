using GridGame.Constants;
using GridGame.GameManagers;
using GridGame.Hexagons.Managers;
using GridGame.Hexagons.StaticClasses;
using GridGame.Resources;
using GridGame.TextureLoading;
using GridGame.Tiles.Buildings;
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

        public bool SpentGold;

        public PlayerResources playerResources;
        public BuildingManager buildingManager;

        private Dictionary<BuildingType, int> BuildingCostDictionary;

        public PlayerData(PlayerResources playerResources, HexMap hexMap) {
            this.playerResources = playerResources;

            SpentGold = false;

            BuildingCostDictionary = BuildingPrices.GetPriceDictionary();
            buildingManager = new BuildingManager(hexMap);
        }

        public bool AddBuilding(BuildingType buildingType, (int, int) pos) {
            if(!buildingManager.UnlockedBuildings.Contains(buildingType)) return false; //Checks if building technology is unlocked

            if(!playerResources.TrySubtractResource(ResourceType.Gold, BuildingCostDictionary[buildingType])) {
                return false;
            }

            buildingManager.AddBuilding(buildingType, pos);

            SpentGold = true;
            return true;
        }

        public void UpdateProduction(GameTime gameTime, DisplayManager displayManager) {
            if(buildingManager.BuildingSomething() && playerResources.GetResourceAmount(ResourceType.Production) > 0) {
                AddProduction(playerResources.GetResourceAmount(ResourceType.Production));
                displayManager.UpdateResource(ResourceType.Production);
            }
            if(SpentGold) {
                displayManager.UpdateResource(ResourceType.Gold);
                SpentGold = false;
            }
        }

        public void AddProduction(int production) {
            if(!buildingManager.BuildingSomething()) return;

            int extra = buildingManager.AddProduction(production);
            playerResources.SubtractResource(ResourceType.Production, production);
            playerResources.AddResource(ResourceType.Production, extra);
        }

    }
}
