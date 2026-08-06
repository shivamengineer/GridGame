using GridGame.Constants;
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

        private Dictionary<(int, int), Tile> tileMap;
        private HashSet<(int, int)> discoveredTiles;

        public HexagonMath HexMath;

        private Dictionary<BuildingType, IBuilding> BuildingGetter;

        public HexagonMap(ContentLoader content) {
            this.content = content;

            HexMath = new HexagonMath();

            InitializeBuildingGetter();
            InitializeHexagons();
            discoveredTiles = new HashSet<(int, int)>();
        }

        private void InitializeBuildingGetter() {
            BuildingGetter = new Dictionary<BuildingType, IBuilding> {
                [BuildingType.Bank] = new Bank(),
                [BuildingType.Empty] = new Empty(),
                [BuildingType.Factory] = new Factory(),
                [BuildingType.Farm] = new Farm(),
                [BuildingType.Hospital] = new Hospital(),
                [BuildingType.Laboratory] = new Laboratory(),
                [BuildingType.NIL] = new NIL(),
            };
        }

        public void SetSelected(BuildingType buildingType, int x, int y) {
            IBuilding building = BuildingGetter[buildingType].newInstance();
            building.SetTextures(content.GetTexture(TextureNames.BLANK_HEXAGON_BORDER), content.GetTexture(TextureNames.BLANK_HEXAGON_BACKGROUND));
            tileMap[(x, y)].SetBuilding(building);
        }

        private void InitializeHexagons() {
            tileMap = new Dictionary<(int, int), Tile>();
            HexagonMapCSVReader.LoadHexagonMap(tileMap, content, "Map1.csv");
        }

        public void Draw(SpriteBatch spriteBatch) {
            int camPosX = HexMath.camPosX;
            int camPosY = HexMath.camPosY;

            float rad = HexMath.hexConstants.HexRadius;

            float dxQ = rad * (MathF.Sqrt(3) - 0.5f);
            float dyQ = rad * 0.75f;
            float dyR = rad * MathF.Sqrt(3) * 0.9f;

            int qMin = (int)MathF.Floor(camPosX / dxQ) - 2;
            float qMax = (int)MathF.Ceiling((camPosX + GameConstants.WINDOW_WIDTH) / dxQ) + 2;

            for(int q = qMin; q <= qMax; q++) {
                float top = camPosY;
                float bottom = camPosY + GameConstants.WINDOW_HEIGHT - (2 * UIOverlayDetails.RESOURCE_BAR_HEIGHT); //subtract resource bar height so it only renders to top of button display

                int rMin = (int)MathF.Floor((top - q * dyQ) / dyR) - 2;
                int rMax = (int)MathF.Ceiling((bottom - q * dyQ) / dyR) + 2;

                for(int r = rMin; r <= rMax; r++) {
                    if(!tileMap.ContainsKey((q, r))) {
                        ITerrain terrain = new Ocean();
                        terrain.SetTextures(content.GetTexture(TextureNames.BLANK_HEXAGON_BORDER), content.GetTexture(TextureNames.BLANK_HEXAGON_BACKGROUND));

                        IBuilding building = new NIL();
                        building.SetTextures(content.GetTexture(TextureNames.BLANK_HEXAGON_BORDER), content.GetTexture(TextureNames.BLANK_HEXAGON_BACKGROUND));

                        tileMap.Add((q, r), new Tile(terrain, building));
                    }
                    DrawHex(spriteBatch, q, r);
                }
            }
        }

        private void DrawHex(SpriteBatch spriteBatch, int Q, int R) {
            Vector2 position = HexMath.HexToPixel(Q, R);

            tileMap[(Q, R)].Draw(spriteBatch, position, HexMath);
        }
    }
}
