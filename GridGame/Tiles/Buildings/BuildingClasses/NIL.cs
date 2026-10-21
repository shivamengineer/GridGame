using GridGame.Constants;
using GridGame.Constants.Colors;
using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.GameManagers;
using GridGame.Hexagons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Tiles.Buildings.BuildingClasses {
    public class NIL : AbstractBuilding {

        private Color hexColor;

        private Dictionary<ConstGameInt, int> GameInts;

        public NIL(ConstantsController Constants) {
            this.Constants = Constants;
            GameInts = Constants.GetGameInts();
            Dictionary<ConstColors, Color> Colors = Constants.GetColors();
            BuildingType = BuildingType.NIL;
            hexColor = Colors[ConstColors.Tile_NIL];
        }

        public override void SetInfo() {
            //
        }

        public override int GetMaxPeople() {
            return BuildingLimits.NIL_MAX_PEOPLE;
        }

        public override IBuilding newInstance() {
            return new NIL(Constants);
        }

        public override void SetTile(ITile tile) {
            //
        }

        public override int GetResources() {
            return 0;
        }

        public override void UpdateEvent(DisplayManager displayManager) {
            //
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            spriteBatch.Draw(baseTexture, position, null, hexColor, 0f, origin, hexMath.GetScale(), SpriteEffects.None, 0f);
        }

    }
}
