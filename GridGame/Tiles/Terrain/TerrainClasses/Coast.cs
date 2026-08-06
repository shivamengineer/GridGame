using GridGame.Constants.Colors;
using GridGame.Hexagons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Tiles.Terrain.TerrainClasses {
    public class Coast : AbstractTerrain {

        private Color hexColor;

        public Coast() {
            hexColor = TerrainColors.CoastColor;
        }

        public override int GetResources() {
            return 0;
        }

        public override void SetTile(ITile tile) {
            //
        }

        public override TerrainType GetTerrainType() {
            return TerrainType.Coast;
        }

        public override ITerrain newInstance() {
            return new Coast();
        }

        public override void UpdateEvent() {
            //
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            spriteBatch.Draw(borderTexture, position, null, hexColor, 0f, origin, hexMath.GetScale(), SpriteEffects.None, 0f);
        }

        public override void DrawBackground(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            spriteBatch.Draw(baseTexture, position, null, hexColor, 0f, origin, hexMath.GetScale(), SpriteEffects.None, 0f);
        }

    }
}
