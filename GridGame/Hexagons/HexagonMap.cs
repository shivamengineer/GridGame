using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
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
                    hexes.Add(new Hex(q, r));
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach(var hex in hexes) {
                Vector2 position = HexToPixel(hex);

                spriteBatch.Draw(
                    tex2,
                    position,
                    null,
                    Color.White,
                    0f,
                    new Vector2(
                        hexTexture.Width / 2f,
                        hexTexture.Height / 2f),
                    1f,
                    SpriteEffects.None,
                    0f);

                spriteBatch.Draw(
                    hexTexture,
                    position,
                    null,
                    Color.White,
                    0f,
                    new Vector2(
                        hexTexture.Width / 2f,
                        hexTexture.Height / 2f),
                    1f,
                    SpriteEffects.None,
                    0f);

                hexConstants.Update();
                //camPosX += 0.001f;
                camPosY -= 0.002f;
            }
        }

    }
}
