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

        private HexMap hexMap;

        private ContentLoader content;
        public PlayerResources playerResources;

        public BuildingManager buildingManager;

        private Dictionary<BuildingType, int> BuildingCostDictionary;

        public PlayerData(PlayerResources playerResources, HexMap hexMap) {
            this.playerResources = playerResources;
            this.hexMap = hexMap;

            SpentGold = false;

            BuildingCostDictionary = BuildingPrices.GetPriceDictionary();
            buildingManager = new BuildingManager(hexMap);
        }

        public bool AddBuilding(BuildingType buildingType, (int, int) pos) {
            if(playerResources.GetResourceAmount(ResourceType.Gold) < BuildingCostDictionary[buildingType]) {
                return false; //Not enough gold
            }

            buildingManager.AddBuilding(buildingType, pos);

            playerResources.SubtractResource(ResourceType.Gold, BuildingCostDictionary[buildingType]);
            SpentGold = true;

            return true;
        }

        public void UpdateProduction(GameTime gameTime, DisplayManager displayManager) {
            if(buildingManager.BuildingSomething() && playerResources.GetResourceAmount(ResourceType.Production) > 0) {
                AddProduction(playerResources.GetResourceAmount(ResourceType.Production));
                displayManager.resourceManager.resourceDisplay.UpdateResource(ResourceType.Production, playerResources);
            }
            if(SpentGold) {
                displayManager.resourceManager.resourceDisplay.UpdateResource(ResourceType.Gold, playerResources);
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
