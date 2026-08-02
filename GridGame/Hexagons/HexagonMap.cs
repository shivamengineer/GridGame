using GridGame.Constants;
using GridGame.Tiles;
using GridGame.Tiles.Buildings.BuildingClasses;
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

        private Dictionary<(int, int), Hex> hexMap;
        private Dictionary<(int, int), ITile> tileMap;

        public HexagonMath HexMath;

        private (int, int) topLeftXY = (0, 0);

        private bool posSet = false;
        private (int, int) setPOS;

        private Vector2 origin;

        public HexagonMap(Texture2D hexTexture, Texture2D texture2) {
            this.hexTexture = hexTexture;
            tex2 = texture2;

            HexMath = new HexagonMath();

            origin = new Vector2(hexTexture.Width / 2f, hexTexture.Height / 2f);
            InitializeHexagons();
        }

        public void SetSelected(int x, int y) {
            setPOS = (x, y);

            posSet = hexMap.ContainsKey(setPOS);
        }

        private void InitializeHexagons() {
            hexMap = new Dictionary<(int, int), Hex>();
            tileMap = new Dictionary<(int, int), ITile>();

            int width = 10;
            int height = 10;

            for(int r = 0; r < height; r++) {
                for(int q = 0; q < width; q++) {
                    Hex hex = new Hex(q, r);
                    hexMap.Add((q, r), hex);

                    ITile tile = new NIL(q, r);
                    tile.SetTextures(tex2, hexTexture);
                    tileMap.Add((q, r), tile);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            int camPosX = HexMath.camPosX;
            int camPosY = HexMath.camPosY;

            float rad = HexMath.hexConstants.HexRadius;

            topLeftXY = HexMath.PixelToHex(new Vector2(camPosX, camPosY));

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
                    if(!hexMap.ContainsKey((q, r))) {
                        Hex hex = new Hex(q, r);
                        hexMap.Add((q, r), hex);

                        ITile tile = new NIL(q, r);
                        tile.SetTextures(tex2, hexTexture);
                        tileMap.Add((q, r), tile);
                    }
                    DrawHex(spriteBatch, hexMap[(q, r)]);
                }
            }
        }

        private void DrawHex(SpriteBatch spriteBatch, Hex hex) {
            Vector2 position = HexMath.HexToPixel(hex);

            Color fillColor = Color.White;
            if(posSet && hex.Q == setPOS.Item1 && hex.R == setPOS.Item2) {
                fillColor = Color.Green;
            }

            tileMap[(hex.Q, hex.R)].Draw(spriteBatch, position, HexMath);
        }
    }
}
