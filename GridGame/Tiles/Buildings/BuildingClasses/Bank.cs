using GridGame.Constants;
using GridGame.Constants.Colors;
using GridGame.Hexagons;
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

        public Bank() {
            hexColor = BuildingColors.BankColor;
        }

        public override int GetMaxPeople() {
            return BuildingLimits.BANK_MAX_PEOPLE;
        }

        public override void Build() {
            //
        }

        public override BuildingType GetBuildingType() {
            return BuildingType.Bank;
        }

        public override IBuilding newInstance() {
            return new Bank();
        }

        public override void SetTile(ITile tile) {
            //
        }

        public override int GetResources() {
            return 0;
        }

        public override void Update(GameTime gameTime) {
            //
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            spriteBatch.Draw(baseTexture, position, null, hexColor, 0f, origin, hexMath.GetScale(), SpriteEffects.None, 0f);
        }

    }
}
