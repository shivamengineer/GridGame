using GridGame.Constants;
using GridGame.Constants.Colors;
using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.Constants.Resources;
using GridGame.GameManagers;
using GridGame.Hexagons;
using GridGame.Resources;
using GridGame.UI.Popups;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Tiles.Buildings.BuildingClasses {
    public class Farm : AbstractBuilding {

        private Color hexColor;

        private Dictionary<ConstGameInt, int> GameInts;

        public Farm(ConstantsController Constants) {
            this.Constants = Constants;
            GameInts = Constants.GetGameInts();
            Dictionary<ConstColors, Color> Colors = Constants.GetColors();
            BuildingType = BuildingType.Farm;
            hexColor = Colors[ConstColors.Farm];
            production_needed = GameInts[ConstGameInt.FarmProductionCost];
        }

        public override void SetInfo() {
            progressBar.SetInfo("FARM: ", production_needed);
        }

        public override int GetMaxPeople() {
            return BuildingLimits.FARM_MAX_PEOPLE;
        }

        public override IBuilding newInstance() {
            return new Farm(Constants);
        }

        public override void SetTile(ITile tile) {
            //
        }

        public override int GetResources() {
            return 0;
        }

        public override void UpdateEvent(DisplayManager displayManager) {
            displayManager.AddResource(ResourceType.Food, GameInts[ConstGameInt.FarmResourceRate]);
            displayManager.UpdateResource(ResourceType.Food);
            resourcePopup = new TemporaryPopup(content, "+1F", 1f);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            spriteBatch.Draw(baseTexture, position, null, hexColor, 0f, origin, hexMath.GetScale(), SpriteEffects.None, 0f);
        }

    }
}
