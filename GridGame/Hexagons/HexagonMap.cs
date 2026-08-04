using GridGame.Constants;
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

        private Texture2D hexTexture;
        private Texture2D tex2;

        private Dictionary<(int, int), Tile> tileMap;

        public HexagonMath HexMath;

        private (int, int) setPOS;

        public HexagonMap(Texture2D hexTexture, Texture2D texture2) {
            this.hexTexture = hexTexture;
            tex2 = texture2;

            HexMath = new HexagonMath();

            InitializeHexagons();
        }

        public void SetSelected(int x, int y) {
            setPOS = (x, y);
        }

        private void InitializeHexagons() {
            tileMap = new Dictionary<(int, int), Tile>();

            int width = 10;
            int height = 10;

            for(int r = 0; r < height; r++) {
                for(int q = 0; q < width; q++) {
                    ITerrain terrain = new Land(q, r);
                    terrain.SetTextures(tex2, hexTexture);

                    IBuilding building = new Bank(q, r);
                    building.SetTextures(tex2, hexTexture);

                    tileMap.Add((q, r), new Tile(terrain, building));
                }
            }
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
                        ITerrain terrain = new Land(q, r);
                        terrain.SetTextures(tex2, hexTexture);

                        IBuilding building = new Bank(q, r);
                        building.SetTextures(tex2, hexTexture);

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
