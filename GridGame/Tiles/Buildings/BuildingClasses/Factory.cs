using GridGame.Constants;
using GridGame.Constants.Colors;
using GridGame.Constants.Resources;
using GridGame.GameManagers;
using GridGame.Hexagons;
using GridGame.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Tiles.Buildings.BuildingClasses {
    public class Factory : AbstractBuilding {

        private Color hexColor;

        public Factory() {
            hexColor = BuildingColors.FactoryColor;
            production_needed = BuildingCosts.FACTORY_PRODUCTION_COST;
        }

        public override int GetMaxPeople() {
            return BuildingLimits.FACTORY_MAX_PEOPLE;
        }

        public override BuildingType GetBuildingType() {
            return BuildingType.Factory;
        }

        public override IBuilding newInstance() {
            return new Factory();
        }

        public override void SetTile(ITile tile) {
            //
        }

        public override int GetResources() {
            return 0;
        }

        public override void UpdateEvent(DisplayManager displayManager) {
            displayManager.resourceManager.playerResources.AddResource(ResourceType.Production, BuildingStats.FACTORY_RATE);
            displayManager.resourceManager.resourceDisplay.UpdateResource(ResourceType.Production, displayManager.resourceManager.playerResources);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            spriteBatch.Draw(baseTexture, position, null, hexColor, 0f, origin, hexMath.GetScale(), SpriteEffects.None, 0f);
        }
    }
}
