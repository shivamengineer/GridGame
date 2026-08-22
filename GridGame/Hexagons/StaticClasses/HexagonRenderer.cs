using GridGame.Constants;
using GridGame.TextureLoading.TextureEnums;
using GridGame.Tiles;
using GridGame.Tiles.Buildings.BuildingClasses;
using GridGame.Tiles.Buildings;
using GridGame.Tiles.Terrain;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using GridGame.Tiles.Terrain.TerrainClasses;

namespace GridGame.Hexagons.StaticClasses {
    public static class HexagonRenderer {

        public static void Draw(SpriteBatch spriteBatch, HexMap hex, Tile unknown) {
            int camPosX = hex.HexMath.camPosX;
            int camPosY = hex.HexMath.camPosY;

            float rad = hex.HexMath.hexConstants.HexRadius;

            float dxQ = rad * (MathF.Sqrt(3) - 0.5f);
            float dyQ = rad * 0.75f;
            float dyR = rad * MathF.Sqrt(3) * 0.9f;

            int qMin = (int)MathF.Floor(camPosX / dxQ) - 2;
            int qMax = (int)MathF.Ceiling((camPosX + GameConstants.WINDOW_WIDTH) / dxQ) + 2;

            for(int q = qMin; q <= qMax; q++) {
                float top = camPosY;
                float bottom = camPosY + GameConstants.WINDOW_HEIGHT - 2 * UIOverlayDetails.RESOURCE_BAR_HEIGHT; //subtract resource bar height so it only renders to top of button display

                int rMin = (int)MathF.Floor((top - q * dyQ) / dyR) - 2;
                int rMax = (int)MathF.Ceiling((bottom - q * dyQ) / dyR) + 2;

                for(int r = rMin; r <= rMax; r++) {
                    if(!hex.Tiles.ContainsKey((q, r))) {
                        ITerrain terrain = new Ocean();
                        terrain.SetContent(hex.Content);

                        IBuilding building = new NIL();
                        building.SetContent(hex.Content);

                        hex.Tiles.Add((q, r), new Tile(terrain, building));
                    }
                    DrawHex(spriteBatch, hex, unknown, q, r);
                }
            }
        }

        private static void DrawHex(SpriteBatch spriteBatch, HexMap hex, Tile unknown, int Q, int R) {
            Vector2 position = hex.HexMath.HexToPixel(Q, R);

            if(hex.DiscoveredTiles.Contains((Q, R))) {
                hex.Tiles[(Q, R)].Draw(spriteBatch, position, hex.HexMath);
            } else {
                unknown.Draw(spriteBatch, position, hex.HexMath);
            }
        }

        public static void DrawRivers(SpriteBatch spriteBatch, HexMap hexMap) {
            foreach(var River in hexMap.csvReader.Rivers) {
                if(hexMap.DiscoveredTiles.Contains(River)) {
                    Vector2 position = hexMap.HexMath.HexToPixel(River.Item1, River.Item2);
                    hexMap.Tiles[River].DrawRiver(spriteBatch, position, hexMap.HexMath);
                }
            }
        }

        public static void DrawUI(SpriteBatch spriteBatch, HexagonMap hexagonMap) {
            foreach(var Building in hexagonMap.playerData.buildingManager.BuildingTiles) {
                Vector2 position = hexagonMap.hexMap.HexMath.HexToPixel(Building.Item1, Building.Item2);
                hexagonMap.hexMap.Tiles[Building].DrawUI(spriteBatch, position, hexagonMap.hexMap.HexMath);
            }
        }

    }
}
