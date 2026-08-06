using GridGame.Constants;
using GridGame.Constants.Colors;
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
    public class Hospital : AbstractBuilding {

        private Color hexColor;

        public Hospital() {
            hexColor = BuildingColors.HospitalColor;
        }
        public override int GetMaxPeople() {
            return BuildingLimits.HOSPITAL_MAX_PEOPLE;
        }

        public override void Build() {
            //
        }

        public override BuildingType GetBuildingType() {
            return BuildingType.Hospital;
        }

        public override IBuilding newInstance() {
            return new Hospital();
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
