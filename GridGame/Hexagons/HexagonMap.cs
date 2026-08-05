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

        private (int, int) setPOS;

        public HexagonMap(ContentLoader content) {
            this.content = content;

            HexMath = new HexagonMath();

            InitializeHexagons();
            discoveredTiles = new HashSet<(int, int)>();
        }

        public void SetSelected(int x, int y) {
            setPOS = (x, y);
        }

        private void InitializeHexagons() {
            tileMap = new Dictionary<(int, int), Tile>();
            HexagonMapCSVReader.LoadHexagonMap(tileMap, content, "TestMap.csv");

            /*int width = 10;
            int height = 10;

            for(int r = 0; r < height; r++) {
                for(int q = 0; q < width; q++) {
                    ITerrain terrain = new Land();
                    terrain.SetTextures(content.GetTexture(TextureNames.BLANK_HEXAGON_BORDER), content.GetTexture(TextureNames.BLANK_HEXAGON_BACKGROUND));

                    IBuilding building = new NIL();
                    building.SetTextures(content.GetTexture(TextureNames.BLANK_HEXAGON_BORDER), content.GetTexture(TextureNames.BLANK_HEXAGON_BACKGROUND));

                    tileMap.Add((q, r), new Tile(terrain, building));
                }
            }*/
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
                float bottom = camPosY + GameConstants.WINDOW_HEIGHT;

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
