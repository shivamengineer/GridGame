using GridGame.Tiles.Buildings;
using GridGame.Tiles.Terrain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Tiles {
    public class Tile {

        private ITerrain terrain;
        private IBuilding building;

        public Tile(ITerrain terrain, IBuilding building) {
            this.terrain = terrain;
            this.building = building;
        }

        public void SetTerrain(ITerrain terrain) {
            this.terrain = terrain;
        }

        public void SetBuilding(IBuilding building) {
            this.building = building;
        }

        public void Update(GameTime gameTime) {
            terrain.Update(gameTime);
            building.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch) {
            terrain.Draw(spriteBatch);
            building.Draw(spriteBatch);
        }

    }
}
