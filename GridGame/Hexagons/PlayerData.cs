using GridGame.Constants;
using GridGame.GameManagers;
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

        public bool CityBuilt;
        
        public (int, int) city;
        public HashSet<(int, int)> BuildingTiles;
        public Queue<(int, int)> UnfinishedBuildingTiles;
        public HashSet<(int, int)> CanBuildTiles;
        public bool SpentGold;

        private HexMap hexMap;

        private ContentLoader content;
        public PlayerResources playerResources;

        private Dictionary<BuildingType, int> BuildingCostDictionary;

        public PlayerData(PlayerResources playerResources, HexMap hexMap) {
            this.playerResources = playerResources;
            this.hexMap = hexMap;
            
            CityBuilt = false;
            BuildingTiles = new HashSet<(int, int)>();
            UnfinishedBuildingTiles = new Queue<(int, int)>();
            CanBuildTiles = new HashSet<(int, int)>();
            SpentGold = false;

            BuildingCostDictionary = BuildingPrices.GetPriceDictionary();
        }

        public bool AddBuilding(BuildingType buildingType, int x, int y) {
            if(playerResources.GetResourceAmount(ResourceType.Gold) < BuildingCostDictionary[buildingType]) {
                return false; //Not enough gold
            }

            if(!CityBuilt && buildingType == BuildingType.CityCenter) {
                CityBuilt = true;
                city = (x, y);
                CanBuildTiles = DiscoverTiles.TilesInRadius(city, BuildingLimits.BUILDING_RADIUS_FROM_CITY);
            }

            BuildingTiles.Add((x, y));
            playerResources.SubtractResource(ResourceType.Gold, BuildingCostDictionary[buildingType]);
            SpentGold = true;
            if(hexMap.Tiles[(x, y)].IsBuilding()) {
                UnfinishedBuildingTiles.Enqueue((x, y));
            }

            return true;
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
