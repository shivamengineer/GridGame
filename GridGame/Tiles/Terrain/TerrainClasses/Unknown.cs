using GridGame.Hexagons;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridGame.Constants.Colors;

namespace GridGame.Tiles.Terrain.TerrainClasses {
    public class Unknown : AbstractTerrain {

        private Color hexColor;
        private Color hexBorderColor;

        public Unknown() {
            hexColor = TerrainColors.UnknownColor;
            hexBorderColor = TerrainColors.UnknownBorderColor;
        }

        public override int GetResources() {
            return 0;
        }

        public override void SetTile(ITile tile) {
            //
        }

        public override TerrainType GetTerrainType() {
            return TerrainType.Unknown;
        }

        public override ITerrain newInstance() {
            return new Unknown();
        }

        public override void UpdateEvent() {
            //
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            spriteBatch.Draw(borderTexture, position, null, hexBorderColor, 0f, origin, hexMath.GetScale(), SpriteEffects.None, 0f);
        }

        public override void DrawBackground(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            spriteBatch.Draw(baseTexture, position, null, hexColor, 0f, origin, hexMath.GetScale(), SpriteEffects.None, 0f);
        }

    }
}
