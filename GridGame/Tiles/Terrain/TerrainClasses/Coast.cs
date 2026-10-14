using GridGame.Constants.Colors;
using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
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

        private Dictionary<ConstColors, Color> Colors;

        public Coast(ConstantsController Constants) {
            this.Constants = Constants;
            Colors = Constants.ConstantsFiles[ConstantTypes.COLOR].GetColors();

            TerrainType = TerrainType.Coast;
            hexColor = Colors[ConstColors.Coast];
        }

        public override int GetResources() {
            return 0;
        }

        public override void SetTile(ITile tile) {
            //
        }

        public override ITerrain newInstance() {
            return new Coast(Constants);
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
                if(inRange) hoverColor = Colors[ConstColors.CanBuild];
                else hoverColor = Colors[ConstColors.CannotBuild];

                spriteBatch.Draw(baseTexture, position, null, hoverColor, 0f, origin, hexMath.GetScale(), SpriteEffects.None, 0f);
            }
        }

        public override void DrawRiver(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            //
        }

    }
}
