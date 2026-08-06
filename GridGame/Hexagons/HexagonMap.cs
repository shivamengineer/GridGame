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

        public HexagonMap(ContentLoader content) {
            this.content = content;

            hexMap = new HexMap(content);

            BuildingDictionary = BuildingGetter.GetBuildingGetter();
            hexMap.LandTiles = HexagonMapCSVReader.LoadHexagonMap(hexMap.Tiles, content, "Map1.csv");
            hexMap.DiscoveredTiles = DiscoveredTiles.GetTileSet(hexMap.LandTiles);

            UnknownTile = UnknownTileGetter.GetTile(content);
        }

        public void SetSelected(BuildingType buildingType, int x, int y) {
            if(!hexMap.DiscoveredTiles.Contains((x, y)) || hexMap.BuildingTiles.Contains((x, y))) return;

            hexMap.BuildingTiles.Add((x, y));
            IBuilding building = BuildingDictionary[buildingType].newInstance();
            building.SetTextures(content.GetTexture(TextureNames.BLANK_HEXAGON_BORDER), content.GetTexture(TextureNames.BLANK_HEXAGON_BACKGROUND));
            hexMap.Tiles[(x, y)].SetBuilding(building);
        }

        public void Update(GameTime gameTime, DisplayManager displayManager) {
            foreach((int, int) building in hexMap.BuildingTiles) {
                hexMap.Tiles[building].Update(gameTime, displayManager);
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            HexagonRenderer.Draw(spriteBatch, hexMap, UnknownTile);
        }
    }
}
