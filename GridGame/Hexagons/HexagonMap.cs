using GridGame.Constants;
using GridGame.GameManagers;
using GridGame.Hexagons.StaticClasses;
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

        private Dictionary<BuildingType, IBuilding> BuildingDictionary;
        private Tile UnknownTile;

        private Citizen citizen;

        public HexagonMap(ContentLoader content) {
            this.content = content;

            hexMap = new HexMap(content);

            BuildingDictionary = BuildingGetter.GetBuildingGetter();
            hexMap.LandTiles = HexagonMapCSVReader.LoadHexagonMap(hexMap.Tiles, content, "Map1.csv");
            (int, int) StartCoords = DiscoveredTiles.GetStartTile(hexMap.LandTiles);
            hexMap.DiscoveredTiles = DiscoveredTiles.TilesInRadius(StartCoords, 2);

            citizen = new Citizen(StartCoords.Item1, StartCoords.Item2);
            citizen.SetTexture(content);

            UnknownTile = UnknownTileGetter.GetTile(content);
        }

        public void SetSelected(BuildingType buildingType, int x, int y) {
            if(!hexMap.DiscoveredTiles.Contains((x, y))) return; //Can't build on undiscovered tile
            if(hexMap.BuildingTiles.Contains((x, y))) return; //Can't build on another building
            if(hexMap.Tiles[(x, y)].GetTerrainType() == TerrainType.Ocean) return; //Can't build on ocean tile

            hexMap.BuildingTiles.Add((x, y));
            hexMap.Tiles[(x, y)].SetBuilding(NewBuilding.GetNewBuilding(BuildingDictionary, buildingType, content));
        }

        public void Update(GameTime gameTime, DisplayManager displayManager) {
            foreach((int, int) building in hexMap.BuildingTiles) {
                hexMap.Tiles[building].Update(gameTime, displayManager);
            }
            citizen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch) {
            HexagonRenderer.Draw(spriteBatch, hexMap, UnknownTile);
            citizen.Draw(spriteBatch, hexMap.HexMath);
        }
    }
}
