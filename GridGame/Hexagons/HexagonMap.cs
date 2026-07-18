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
            float rad = hexConstants.HexRadius;

            float x = hex.Q * (rad * MathF.Sqrt(3) - (rad / 2)) - camPosX;
            float y = (hex.R * rad * MathF.Sqrt(3)) * 0.9f + (hex.Q * rad / 2) * 1.5f - camPosY;

            return new Vector2(x, y);
        }

        public void SetSelected(int x, int y) {
            setPOS = (x, y);

            posSet = hexMap.ContainsKey(setPOS);
        }

        public (int, int) PixelToHex(Vector2 mousePos) {
            float radius = hexConstants.HexRadius;

            float x = mousePos.X + camPosX;
            float y = mousePos.Y + camPosY;

            float A = radius * (MathF.Sqrt(3f) - 0.5f);
            float B = radius * 0.75f;
            float C = radius * 0.9f * MathF.Sqrt(3f);

            float q = x / A;
            float r = (y - B * q) / C;

            return (
                (int)MathF.Round(q),
                (int)MathF.Round(r)
            );
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
            Vector2 origin = new Vector2(hexTexture.Width / 2f, hexTexture.Height / 2f);
            //Vector2 origin = Vector2.Zero;

            foreach(var hex in hexes) {
                Vector2 position = HexToPixel(hex);

                Color fillColor = Color.White;
                if(posSet && hex.Q == setPOS.Item1 && hex.R == setPOS.Item2) {
                    fillColor = Color.Red;
                }

                spriteBatch.Draw(tex2, position, null, Color.White, 0f, origin, hexConstants.GetScale(), SpriteEffects.None, 0f);
                spriteBatch.Draw(hexTexture, position, null, fillColor, 0f, origin, hexConstants.GetScale(), SpriteEffects.None, 0f);

                //hexConstants.Update();
                //camPosX += 0.001f;
                //camPosY -= 0.002f;
            }

        }

    }
}
