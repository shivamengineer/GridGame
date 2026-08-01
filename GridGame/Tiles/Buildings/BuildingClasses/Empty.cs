using GridGame.Constants;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Tiles.Buildings.BuildingClasses {
    public class Empty : AbstractBuilding {

        private int q;
        private int r;

        public Empty(int q, int r) {
            this.q = q;
            this.r = r;
        }
        public override int GetMaxPeople() {
            return BuildingLimits.EMPTY_MAX_PEOPLE;
        }

        public override void Build() {
            //
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

        public override void Draw(SpriteBatch spriteBatch) {
            //
        }

    }
}
