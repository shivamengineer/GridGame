using GridGame.Constants.Colors;
using GridGame.Constants;
using GridGame.Hexagons;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridGame.GameManagers;
using GridGame.Constants.Resources;
using GridGame.Resources;
using GridGame.UI.Popups;
using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.Constants.Controller;

namespace GridGame.Tiles.Buildings.BuildingClasses {
    public class CityCenter : AbstractBuilding {

        private Color hexColor;

        private Dictionary<ConstGame, int> GameInts;

        public CityCenter(ConstantsController Constants) {
            this.Constants = Constants;
            GameInts = Constants.GetGameInts();
            Dictionary<ConstColors, Color> Colors = Constants.GetColors(); 
            BuildingType = BuildingType.CityCenter;
            hexColor = Colors[ConstColors.CityCenter];
            production_needed = GameInts[ConstGame.CityCenterProductionCost];
        }

        public override void SetInfo() {
            progressBar.SetInfo("CITY CENTER: ", production_needed);
        }

        public override int GetMaxPeople() {
            return BuildingLimits.CITY_CENTER_MAX_PEOPLE;
        }

        public override IBuilding newInstance() {
            return new CityCenter(Constants);
        }

        public override void SetTile(ITile tile) {
            //
        }

        public override int GetResources() {
            return 0;
        }

        public override void UpdateEvent(DisplayManager displayManager) {
            displayManager.AddResource(ResourceType.Food, GameInts[ConstGame.CityFoodResourceRate]);
            displayManager.AddResource(ResourceType.Gold, GameInts[ConstGame.CityGoldResourceRate]);
            displayManager.AddResource(ResourceType.Production, GameInts[ConstGame.CityProductionResourceRate]);
            displayManager.AddResource(ResourceType.Science, GameInts[ConstGame.CityScienceResourceRate]);
            displayManager.resourceManager.resourceDisplay.UpdateAllResources(displayManager.resourceManager.playerResources.GetResourceCounts());
            map.playerData.AddProduction(CityBaseStats.PRODUCTION_RATE);
            resourcePopup = new TemporaryPopup(content, "+1ALL", 1f);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            spriteBatch.Draw(baseTexture, position, null, hexColor, 0f, origin, hexMath.GetScale(), SpriteEffects.None, 0f);
        }

    }
}
