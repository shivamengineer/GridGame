using GridGame.GameManagers;
using GridGame.Hexagons;
using GridGame.Resources;
using GridGame.Tiles.Buildings;
using GridGame.Tiles.Buildings.BuildingClasses;
using GridGame.Tiles.Terrain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public void SetMap(HexagonMap map) {
            building.SetMap(map);
        }

        public TerrainType GetTerrainType() {
            return terrain.GetTerrainType();
        }

        public BuildingType GetBuildingType() {
            return building.GetBuildingType();
        }

        public bool IsBuilding() {
            return building.IsBuilding();
        }

        public int AddProduction(int production) {
            return building.Build(production);
        }

        public Tile newInstance() {
            return new Tile(terrain.newInstance(), building.newInstance());
        }

        public void Update(GameTime gameTime, DisplayManager displayManager) {
            terrain.Update(gameTime, displayManager);
            building.Update(gameTime, displayManager);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            Vector2 offsetPos = new Vector2(position.X + hexMath.hexConstants.HexRadius - 5, position.Y + hexMath.hexConstants.HexRadius - 5);
            if(building.GetBuildingType() != BuildingType.NIL && terrain.GetTerrainType() != TerrainType.Unknown) {
                terrain.DrawBackground(spriteBatch, position, hexMath);
                building.Draw(spriteBatch, offsetPos, hexMath);
            } else {
                terrain.DrawBackground(spriteBatch, position, hexMath);
            }
            terrain.Draw(spriteBatch, position, hexMath);
        }

    }
}
