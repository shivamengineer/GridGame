using GridGame.Constants;
using GridGame.GameManagers;
using GridGame.Hexagons.Managers;
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
using GridGame.Virus.VirusControllers;
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
        public CitizenManager citizenManager;
        public DisplayManager displayManager;
        private FoodManager foodManager;
        private CitizenVirusController virusController;

        private Dictionary<BuildingType, IBuilding> BuildingDictionary;
        private Tile UnknownTile;
                   
        public HexagonMap(ContentLoader content, DisplayManager displayManager) {
            this.content = content;

            hexMap = new HexMap(content, citizenManager);

            BuildingDictionary = BuildingGetter.GetBuildingGetter();

            (int, int) StartCoords = hexMap.Initialize();

            this.displayManager = displayManager;
            citizenManager = new CitizenManager(StartCoords, this, content);
            hexMap.SetCitizens(citizenManager);
            playerData = new PlayerData(displayManager.resourceManager.playerResources, hexMap);
            UnknownTile = UnknownTileGetter.GetTile(content);
            foodManager = new FoodManager(this);
            virusController = new CitizenVirusController(this);

            hexMap.HexMath.FocusCamera();
        }

        public bool SetSelected(BuildingType buildingType, int x, int y) {
            if(!hexMap.DiscoveredTiles.Contains((x, y))) return false; //Can't build on undiscovered tile
            if(playerData.buildingManager.HasBuilding(x, y)) return false; //Can't build on another building
            if(hexMap.Tiles[(x, y)].GetTerrainType() == TerrainType.Ocean) return false; //Can't build on ocean tile
            if(hexMap.Tiles[(x, y)].GetTerrainType() == TerrainType.Land_River) return false; //Can't build on river tile

            if(!playerData.AddBuilding(buildingType, x, y)) return false; //Not enough gold

            hexMap.Tiles[(x, y)].SetBuilding(NewBuilding.GetNewBuilding(BuildingDictionary, buildingType, content));
            hexMap.Tiles[(x, y)].SetMap(this);

            return true;
        }

        public void SetHover(int x, int y) {
            if(!hexMap.DiscoveredTiles.Contains((x, y)) || playerData.buildingManager.HasBuilding(x, y)) return;

            bool inRange = DiscoverTiles.DistanceBetweenTiles(citizenManager.CurrentPlayer.transform.Coords, (x, y)) <= BuildingLimits.BUILDING_RADIUS_FROM_PLAYER;
            if(playerData.buildingManager.CityBuilt) {
                inRange = inRange && playerData.buildingManager.InRangeOfCity(x, y);
                inRange = inRange && hexMap.Tiles[(x, y)].GetTerrainType() != TerrainType.Ocean;
            }

            if(hexMap.Tiles.ContainsKey((hexMap.HoveredTile))) {
                hexMap.Tiles[hexMap.HoveredTile].SetHovered(false, inRange);
            }
            hexMap.Tiles[(x, y)].SetHovered(true, inRange);

            hexMap.HoveredTile = (x, y);
        }

        public void AddCitizen() {
            if(playerData.buildingManager.CityBuilt == false) return;
            if(citizenManager.HasOtherCitizenAtPos(playerData.buildingManager.city)) return;

            citizenManager.AddCitizen(playerData.buildingManager.city);
        }

        public void WorkTile((int, int) Coords) {
            hexMap.Tiles[Coords].WorkTile(displayManager);
        }

        public void BuildBuilding((int, int) Coords, int production) {
            hexMap.Tiles[Coords].AddProduction(production);
        }

        public void Update(GameTime gameTime, DisplayManager displayManager) {
            foreach((int, int) building in playerData.buildingManager.BuildingTiles) {
                hexMap.Tiles[building].Update(gameTime, displayManager);
            }
            foreach(var citizen in citizenManager.Citizens) {
                citizen.Update(gameTime);
            }
            while(citizenManager.ToRemoveCitizens.Count > 0) {
                citizenManager.KillCitizen(citizenManager.ToRemoveCitizens.Pop());
            }
            foodManager.Update(gameTime);
            playerData.UpdateProduction(gameTime, displayManager);
            virusController.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch) {
            HexagonRenderer.Draw(spriteBatch, hexMap, UnknownTile);
            HexagonRenderer.DrawRivers(spriteBatch, hexMap);
            HexagonRenderer.DrawBuildings(spriteBatch, this);
            foreach(var citizen in citizenManager.Citizens) {
                citizen.Draw(spriteBatch, hexMap.HexMath);
            }
            HexagonRenderer.DrawUI(spriteBatch, this);
        }
    }
}
