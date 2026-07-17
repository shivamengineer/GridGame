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

        private float camPosX = 0;
        private float camPosY = 0;

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

        public HexagonMap(Texture2D hexTexture, Texture2D texture2) {
            hexConstants = new HexagonConstants();
            this.hexTexture = hexTexture;
            tex2 = texture2;
            InitializeHexagons();
        }

        public Vector2 HexToPixel(Hex hex) {
            float x = 1.5f * hexConstants.HexRadius * MathF.Sqrt(3) * (hex.Q + hex.R / 2f) - camPosX;
            float y = 0.5f * hexConstants.HexRadius * 1.5f * hex.R - camPosY;

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

            float q = (MathF.Sqrt(3) / 3f * x - 1f / 3f * y) / hexConstants.HexRadius;
            float r = (2f / 3f * y) / hexConstants.HexRadius;

            return HexRound(q, r);
        }

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
            int height = 20;

            for(int r = 0; r < height; r++) {
                for(int q = -10; q < width; q++) {
                    Hex hex = new Hex(q, r);
                    hexes.Add(hex);
                    hexMap.Add((q, r), hex);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach(var hex in hexes) {
                Vector2 position = HexToPixel(hex);
                Vector2 origin = new Vector2(hexTexture.Width / 2f, hexTexture.Height / 2f);

                Color fillColor = Color.White;
                if(posSet && hex.Q == setPOS.Item1 && hex.R == setPOS.Item2) {
                    fillColor = Color.Red;
                }

                //Debug.WriteLine("THIS NODE POS X: " + hex.Q + "| Y: " + hex.R);

                spriteBatch.Draw(tex2, position, null, Color.White, 0f, origin, hexConstants.GetScale(), SpriteEffects.None, 0f);
                spriteBatch.Draw(hexTexture, position, null, fillColor, 0f, origin, hexConstants.GetScale(), SpriteEffects.None, 0f);

                //hexConstants.Update();
                //camPosX += 0.001f;
                //camPosY -= 0.002f;
            }
        }

    }
}
