using GridGame.Constants;
using GridGame.Constants.Colors;
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

        public Farm() {
            hexColor = BuildingColors.FarmColor;
            production_needed = BuildingCosts.FARM_PRODUCTION_COST;
        }

        public override void SetInfo() {
            progressBar.SetInfo("FARM: ", production_needed);
        }

        public override int GetMaxPeople() {
            return BuildingLimits.FARM_MAX_PEOPLE;
        }

        public override BuildingType GetBuildingType() {
            return BuildingType.Farm;
        }

        public override IBuilding newInstance() {
            return new Farm();
        }

        public override void SetTile(ITile tile) {
            //
        }

        public override int GetResources() {
            return 0;
        }

        public override void UpdateEvent(DisplayManager displayManager) {
            displayManager.resourceManager.playerResources.AddResource(ResourceType.Food, BuildingStats.FARM_RATE);
            displayManager.resourceManager.resourceDisplay.UpdateResource(ResourceType.Food, displayManager.resourceManager.playerResources);
            resourcePopup = new TemporaryPopup(content, "+1 Food", 1f);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            spriteBatch.Draw(baseTexture, position, null, hexColor, 0f, origin, hexMath.GetScale(), SpriteEffects.None, 0f);
            progressBar.Draw(spriteBatch, position, hexMath);
            if(resourcePopup != null) resourcePopup.Draw(spriteBatch, position, hexMath);
        }

    }
}
