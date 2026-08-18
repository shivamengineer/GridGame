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

namespace GridGame.Tiles.Buildings.BuildingClasses {
    public class CityCenter : AbstractBuilding {

        private Color hexColor;

        public CityCenter() {
            hexColor = BuildingColors.CityCenterColor;
            production_needed = BuildingCosts.CITY_CENTER_PRODUCTION_COST;
        }

        public override void SetInfo() {
            progressBar.SetInfo("CITY CENTER: ", production_needed);
        }

        public override int GetMaxPeople() {
            return BuildingLimits.CITY_CENTER_MAX_PEOPLE;
        }

        public override BuildingType GetBuildingType() {
            return BuildingType.CityCenter;
        }

        public override IBuilding newInstance() {
            return new CityCenter();
        }

        public override void SetTile(ITile tile) {
            //
        }

        public override int GetResources() {
            return 0;
        }

        public override void UpdateEvent(DisplayManager displayManager) {
            displayManager.resourceManager.playerResources.AddResource(ResourceType.Food, CityBaseStats.FOOD_RATE);
            displayManager.resourceManager.playerResources.AddResource(ResourceType.Gold, CityBaseStats.GOLD_RATE);
            displayManager.resourceManager.playerResources.AddResource(ResourceType.Production, CityBaseStats.PRODUCTION_RATE);
            displayManager.resourceManager.playerResources.AddResource(ResourceType.Science, CityBaseStats.SCIENCE_RATE);
            displayManager.resourceManager.resourceDisplay.UpdateAllResources(displayManager.resourceManager.playerResources.GetResourceCounts());
            map.playerData.AddProduction(CityBaseStats.PRODUCTION_RATE);
            resourcePopup = new TemporaryPopup(content, "+1ALL", 1f);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            spriteBatch.Draw(baseTexture, position, null, hexColor, 0f, origin, hexMath.GetScale(), SpriteEffects.None, 0f);
        }

    }
}
