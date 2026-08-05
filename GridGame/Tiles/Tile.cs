using GridGame.Hexagons;
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

        public void SetTerrainTextures(Texture2D borderTexture, Texture2D backgroundTexture) {
            terrain.SetTextures(borderTexture, backgroundTexture);
        }

        public void SetBuildingTextures(Texture2D borderTexture, Texture2D backgroundTexture) {
            building.SetTextures(borderTexture, backgroundTexture);
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

        public void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            building.Draw(spriteBatch, position, hexMath);
            Vector2 offsetPos = new Vector2(position.X + 10, position.Y - 6);
            terrain.Draw(spriteBatch, offsetPos, hexMath);

            //if building == null draw terrain base
        }

    }
}
