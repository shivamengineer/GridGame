using GridGame.Constants;
using GridGame.GameManagers;
using GridGame.Hexagons.StaticClasses;
using GridGame.Resources;
using GridGame.TextureLoading;
using GridGame.TextureLoading.TextureEnums;
using GridGame.Tiles;
using GridGame.Tiles.Buildings;
using GridGame.Tiles.Buildings.BuildingClasses;
using GridGame.Tiles.Terrain;
using GridGame.Tiles.Terrain.TerrainClasses;
using GridGame.Units.UnitClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons {
    public class HexagonMap {

        private ContentLoader content;

        public HexMap hexMap;
        public PlayerData playerData;

        private Dictionary<BuildingType, IBuilding> BuildingDictionary;
        private Dictionary<BuildingType, int> BuildingCostDictionary;
        private Tile UnknownTile;
        private PlayerResources playerResources;

        public HexagonMap(ContentLoader content, PlayerResources playerResources) {
            this.playerResources = playerResources;
            this.content = content;

            hexMap = new HexMap(content);

            BuildingDictionary = BuildingGetter.GetBuildingGetter();
            BuildingCostDictionary = BuildingPrices.GetPriceDictionary();
            hexMap.LandTiles = HexagonMapCSVReader.LoadHexagonMap(hexMap.Tiles, content, "Map1.csv");
            (int, int) StartCoords = DiscoveredTiles.GetStartTile(hexMap.LandTiles);
            hexMap.DiscoveredTiles = DiscoveredTiles.TilesInRadius(StartCoords, 2);

            playerData = new PlayerData(StartCoords, this, content);

            UnknownTile = UnknownTileGetter.GetTile(content);
        }

        public bool SetSelected(BuildingType buildingType, int x, int y) {
            if(!hexMap.DiscoveredTiles.Contains((x, y))) return false; //Can't build on undiscovered tile
            if(playerData.BuildingTiles.Contains((x, y))) return false; //Can't build on another building
            if(hexMap.Tiles[(x, y)].GetTerrainType() == TerrainType.Ocean) return false; //Can't build on ocean tile
            if(playerResources.GetResourceAmount(ResourceType.Gold) < BuildingCostDictionary[buildingType]) {
                return false;
            }

            if(!playerData.CityBuilt && buildingType == BuildingType.CityCenter) {
                playerData.CityBuilt = true;
                playerData.city = (x, y);
            }
            playerData.BuildingTiles.Add((x, y));
            hexMap.Tiles[(x, y)].SetBuilding(NewBuilding.GetNewBuilding(BuildingDictionary, buildingType, content));
            hexMap.Tiles[(x, y)].SetMap(this);

            playerResources.SubtractResource(ResourceType.Gold, BuildingCostDictionary[buildingType]);
            playerData.SpentGold = true;

            if(hexMap.Tiles[(x, y)].IsBuilding()) {
                playerData.UnfinishedBuildingTiles.Enqueue((x, y));
            }
            return true;
        }

        public void AddProduction(int production) {
            if(playerData.UnfinishedBuildingTiles.Count == 0) return;

            int extra = hexMap.Tiles[(playerData.UnfinishedBuildingTiles.First())].AddProduction(production);
            playerResources.SubtractResource(ResourceType.Production, production);
            playerResources.AddResource(ResourceType.Production, extra);
        }

        public void UpdateVision((int, int) position, int radius) {
            HashSet<(int, int)> newTiles = DiscoveredTiles.TilesInRadius(position, radius);
            hexMap.DiscoveredTiles.UnionWith(newTiles);
        }

        public void Update(GameTime gameTime, DisplayManager displayManager) {
            foreach((int, int) building in playerData.BuildingTiles) {
                hexMap.Tiles[building].Update(gameTime, displayManager);
            }
            playerData.Player.Update(gameTime);
            UpdateProduction(gameTime, displayManager);
        }

        public void Draw(SpriteBatch spriteBatch) {
            HexagonRenderer.Draw(spriteBatch, hexMap, UnknownTile);
            playerData.Player.Draw(spriteBatch, hexMap.HexMath);
        }

        private void UpdateProduction(GameTime gameTime, DisplayManager displayManager) {
            if(playerData.UnfinishedBuildingTiles.Count > 0) {
                AddProduction(playerResources.GetResourceAmount(ResourceType.Production));
                displayManager.resourceManager.resourceDisplay.UpdateResource(ResourceType.Production, playerResources);
            }
            if(playerData.SpentGold) {
                displayManager.resourceManager.resourceDisplay.UpdateResource(ResourceType.Gold, playerResources);
                playerData.SpentGold = false;
            }
        }
    }
}
