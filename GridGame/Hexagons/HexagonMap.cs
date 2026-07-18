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

        private List<Hex> hexes;
        private Texture2D hexTexture;
        private Texture2D tex2;

        private Dictionary<(int, int), Hex> hexMap;

        private HexagonConstants hexConstants;

        private int camPosX = -300;
        private int camPosY = -100;

        private int texX = -100, texY = -100;
        private Texture2D otherTex;

        private bool posSet = false;
        private (int, int) setPOS;

        public static readonly Hex[] Directions = {
            new Hex(1, 0),
            new Hex(1, -1),
            new Hex(0, -1),
            new Hex(-1, 0),
            new Hex(-1, 1),
            new Hex(0, 1)
        };

        public HexagonMap(Texture2D hexTexture, Texture2D texture2, Texture2D otherTex) {
            hexConstants = new HexagonConstants();
            this.hexTexture = hexTexture;
            tex2 = texture2;
            this.otherTex = otherTex;
            InitializeHexagons();
        }

        public Vector2 HexToPixel(Hex hex) {
            //float x = 1.5f * hexConstants.HexRadius * MathF.Sqrt(3) * (hex.Q + hex.R / 2f) - camPosX;
            //float y = 0.5f * hexConstants.HexRadius * 1.5f * hex.R - camPosY;

            float rad = hexConstants.HexRadius;

            float x = hex.Q * (rad * MathF.Sqrt(3) - (rad / 2)) - camPosX;
            float y = (hex.R * rad * MathF.Sqrt(3)) * 0.9f + (hex.Q * rad / 2) * 1.5f - camPosY;

            return new Vector2(x, y);
        }

        public void SetSelected(int x, int y) {
            setPOS = (x, y);

            Debug.WriteLine("SET POS " + x + ", " + y);

            posSet = hexMap.ContainsKey(setPOS);
        }

        public (int, int) PixelToHex(Vector2 mousePos) {
            // Undo camera offset
            float x = mousePos.X + camPosX;
            float y = mousePos.Y + camPosY;

            Debug.WriteLine("X: " + x);
            Debug.WriteLine("Y: " + y);

            float r = y / (0.75f * hexConstants.HexRadius);
            float q = (float)((x - (r / 2)) / (1.5 * MathF.Sqrt(3) * hexConstants.HexRadius));

            return HexRound(q, r);
        }

        public (int, int) GetCoords(Vector2 mousePos) {
            float x = mousePos.X + camPosX;
            float y = mousePos.Y + camPosY;

            texX = (int)x - camPosX;
            texY = (int)y - camPosY;

            float w = hexConstants.HexRadius * 3;
            float h = 2 * (MathF.Pow(hexConstants.HexRadius, 2) - (MathF.Pow(hexConstants.HexRadius, 2) / 4));

            float newX = x % w;

            int modX = (int)newX % 6;

            (int, int) coords;

            coords = (0, 0);

            if(modX == 0) {
                //
            } else if(modX == 1 || modX == 2) {
                coords.Item1 = 2 * (int)x / (int)w;
                //coords.Item2 = (int)(y % h) - ((int)x / (int)w);
            } else if(modX == 3) {
                //
            } else { //modX == 4 || modX == 5
                coords.Item1 = 2 * (int)x / (int)w;
                //coords.Item2 = (int)((y - (h/2)) % h) - ((int)x / (int)w);
            }

            return coords;
        }

        /*public (int, int) GetCoords(Vector2 mousePos) {
            float x = mousePos.X;
            float y = mousePos.Y;

            texX = (int)x;
            texY = (int)y;

            int gridWidth = (int)(hexConstants.HexRadius * 3 / 2);
            int gridHeight = (int)(2 * (MathF.Pow(hexConstants.HexRadius, 2) - (MathF.Pow(hexConstants.HexRadius, 2) / 4)));

            int column = (int)(x / gridWidth);
            int row;

            bool columnIsOdd = column % 2 == 1;

            if(columnIsOdd) {
                row = (int)((y - (gridHeight / 2)) / gridHeight);
            } else {
                row = (int)(y / gridHeight);
            }

            float relX = x - (column * gridWidth);
            float relY;

            if(columnIsOdd) {
                relY = (y - (row * gridHeight)) - (gridHeight / 2);
            } else {
                relY = y - (row * gridHeight);
            }

            float m = (hexConstants.HexRadius / 2) / (gridHeight / 2);

            if(relX < (-m * relY) + (hexConstants.HexRadius / 2)) {
                column--;
                if(!columnIsOdd) {
                    row--;
                }
            } else if(relX < (m * relY) - (hexConstants.HexRadius / 2)) {
                column--;
                if(columnIsOdd) {
                    row++;
                }
            }

            return (column, row);
        }*/

        private (int, int) HexRound(float q, float r) {
            float s = -q - r;

            int rq = (int)MathF.Round(q);
            int rr = (int)MathF.Round(r);
            int rs = (int)MathF.Round(s);

            float qDiff = MathF.Abs(rq - q);
            float rDiff = MathF.Abs(rr - r);
            float sDiff = MathF.Abs(rs - s);

            if(qDiff > rDiff && qDiff > sDiff)
                rq = -rr - rs;
            else if(rDiff > sDiff)
                rr = -rq - rs;

            Console.WriteLine("Q = " + rq + " | R = " + rr);
            return (rq, rr);
        }

        public static Hex GetNeighbor(Hex hex, int direction) {
            var d = Directions[direction];
            return new Hex(hex.Q + d.Q, hex.R + d.R);
        }

        private void InitializeHexagons() {
            hexes = new List<Hex>();
            hexMap = new Dictionary<(int, int), Hex>();

            int width = 10;
            int height = 10;

            for(int r = 0; r < height; r++) {
                for(int q = 0; q < width; q++) {
                    Hex hex = new Hex(q, r);
                    hexes.Add(hex);
                    hexMap.Add((q, r), hex);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            //Vector2 origin = new Vector2(hexTexture.Width / 2f, hexTexture.Height / 2f);
            Vector2 origin = Vector2.Zero;

            foreach(var hex in hexes) {
                Vector2 position = HexToPixel(hex);

                Color fillColor = Color.White;
                if(posSet && hex.Q == setPOS.Item1 && hex.R == setPOS.Item2) {
                    fillColor = Color.Red;
                }

                //Debug.WriteLine("THIS NODE POS X: " + hex.Q + "| Y: " + hex.R);
                /*if(hex.Q == 0) {
                    spriteBatch.Draw(tex2, position, null, Color.White, 0f, origin, hexConstants.GetScale(), SpriteEffects.None, 0f);
                    spriteBatch.Draw(hexTexture, position, null, fillColor, 0f, origin, hexConstants.GetScale(), SpriteEffects.None, 0f);
                }*/
                spriteBatch.Draw(tex2, position, null, Color.White, 0f, origin, hexConstants.GetScale(), SpriteEffects.None, 0f);
                spriteBatch.Draw(hexTexture, position, null, fillColor, 0f, origin, hexConstants.GetScale(), SpriteEffects.None, 0f);

                //hexConstants.Update();
                //camPosX += 0.001f;
                //camPosY -= 0.002f;
            }

            spriteBatch.Draw(otherTex, new Vector2(texX, texY), null, Color.White, 0f, new Vector2(0, 0), 0.2f, SpriteEffects.None, 0f);

        }

    }
}
