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
    public class Bank : AbstractBuilding {

        private Color hexColor;

        private Dictionary<ConstGame, int> GameInts;

        public Bank(ConstantsController Constants) {
            this.Constants = Constants;
            GameInts = Constants.GetGameInts();
            Dictionary<ConstColors, Color> Colors = Constants.GetColors();
            BuildingType = BuildingType.Bank;
            hexColor = Colors[ConstColors.Bank];
            production_needed = GameInts[ConstGame.BankProductionCost];
        }

        public override void SetInfo() {
            progressBar.SetInfo("BANK: ", production_needed);
        }

        public override int GetMaxPeople() {
            return BuildingLimits.BANK_MAX_PEOPLE;
        }

        public override IBuilding newInstance() {
            return new Bank(Constants);
        }

        public override void SetTile(ITile tile) {
            //
        }

        public override int GetResources() {
            return 0;
        }

        public override void UpdateEvent(DisplayManager displayManager) {
            displayManager.AddResource(ResourceType.Gold, GameInts[ConstGame.BankResourceRate]);
            displayManager.UpdateResource(ResourceType.Gold);
            resourcePopup = new TemporaryPopup(content, "+1G", 1f);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            spriteBatch.Draw(baseTexture, position, null, hexColor, 0f, origin, hexMath.GetScale(), SpriteEffects.None, 0f);
        }

    }
}
