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

        private HexagonConstants hexConstants;

        private float camPos = 0;

        public HexagonMap(Texture2D hexTexture, Texture2D texture2) {
            hexConstants = new HexagonConstants();
            this.hexTexture = hexTexture;
            tex2 = texture2;
            InitializeHexagons();
        }

        public Vector2 HexToPixel(Hex hex) {
            float x = hexConstants.HexRadius * MathF.Sqrt(3) * (hex.Q + hex.R / 2f) - camPos;
            float y = hexConstants.HexRadius * 1.5f * hex.R;

            return new Vector2(x, y);
        }

        private void InitializeHexagons() {
            hexes = new();

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
                camPos += 0.001f;
                
            }
        }

    }
}
