using GridGame.Hexagons;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridGame.Constants.Colors;
using GridGame.GameManagers;
using GridGame.TextureLoading.TextureEnums;
using GridGame.TextureLoading;
using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.Constants.Controller;

namespace GridGame.Tiles.Terrain.TerrainClasses {
    public class Unknown : AbstractTerrain {

        private Color hexColor;
        private Color hexBorderColor;

        private Dictionary<ConstColors, Color> Colors;

        public Unknown(ConstantsController Constants) {
            this.Constants = Constants;
            Colors = Constants.ConstantsFiles[ConstantTypes.COLOR].GetColors();

            TerrainType = TerrainType.Unknown;
            hexColor = Colors[ConstColors.Unknown];
            hexBorderColor = Colors[ConstColors.UnknownBorder];
        }

        public override int GetResources() {
            return 0;
        }

        public override void SetTile(ITile tile) {
            //
        }

        public override ITerrain newInstance() {
            return new Unknown(Constants);
        }

        public override void SetRiverTexture(ContentLoader content, TextureNames texture) {
            //
        }

        public override void UpdateEvent(DisplayManager displayManager) {
            //
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            spriteBatch.Draw(borderTexture, position, null, hexBorderColor, 0f, origin, hexMath.GetScale(), SpriteEffects.None, 0f);
        }

        public override void DrawBackground(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath, bool hovered, bool inRange) {
            spriteBatch.Draw(baseTexture, position, null, hexColor, 0f, origin, hexMath.GetScale(), SpriteEffects.None, 0f);
        }

        public override void DrawRiver(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            //
        }

    }
}
