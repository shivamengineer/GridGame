using GridGame.Constants.Colors;
using GridGame.GameManagers;
using GridGame.Hexagons;
using GridGame.TextureLoading;
using GridGame.TextureLoading.TextureEnums;
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
        private Color hoverColor;

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

        public override void SetRiverTexture(ContentLoader content, TextureNames texture) {
            //
        }

        public override void UpdateEvent(DisplayManager displayManager) {
            //
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            spriteBatch.Draw(borderTexture, position, null, hexColor, 0f, origin, hexMath.GetScale(), SpriteEffects.None, 0f);
        }

        public override void DrawBackground(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath, bool hovered, bool inRange) {
            if(!hovered) {
                spriteBatch.Draw(baseTexture, position, null, hexColor, 0f, origin, hexMath.GetScale(), SpriteEffects.None, 0f);
            } else {
                if(inRange) hoverColor = TerrainColors.CanBuildColor;
                else hoverColor = TerrainColors.CannotBuildColor;

                spriteBatch.Draw(baseTexture, position, null, hoverColor, 0f, origin, hexMath.GetScale(), SpriteEffects.None, 0f);
            }
        }

    }
}
