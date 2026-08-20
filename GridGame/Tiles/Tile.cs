using GridGame.GameManagers;
using GridGame.Hexagons;
using GridGame.Resources;
using GridGame.TextureLoading;
using GridGame.TextureLoading.TextureEnums;
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

        private bool hovered;
        private bool inRange;

        public Tile(ITerrain terrain, IBuilding building) {
            this.terrain = terrain;
            this.building = building;
        }

        public void SetTerrainContent(ContentLoader content) {
            terrain.SetContent(content);
        }

        public void SetBuildingContent(ContentLoader content) {
            building.SetContent(content);
        }

        public void SetRiverTexture(ContentLoader content, TextureNames texture) {
            terrain.SetRiverTexture(content, texture);
        }

        public void SetTerrain(ITerrain terrain) {
            this.terrain = terrain;
        }

        public void SetBuilding(IBuilding building) {
            this.building = building;
            this.building.SetInfo();
            this.building.IsBuilding();
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

        public void WorkTile(DisplayManager displayManager) {
            if(building.GetBuildingType() != BuildingType.NIL && terrain.GetTerrainType() != TerrainType.Unknown) {
                building.UpdateEvent(displayManager);
            }
        }

        public void SetHovered(bool hovered, bool inRange) {
            this.hovered = hovered;
            this.inRange = inRange;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            Vector2 offsetPos = new Vector2(position.X + hexMath.hexConstants.HexRadius - 5, position.Y + hexMath.hexConstants.HexRadius - 5);
            terrain.DrawBackground(spriteBatch, position, hexMath, hovered, inRange);

            if(building.GetBuildingType() != BuildingType.NIL && terrain.GetTerrainType() != TerrainType.Unknown) {
                building.Draw(spriteBatch, offsetPos, hexMath);
            }
            terrain.Draw(spriteBatch, position, hexMath);
        }

        public void DrawUI(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath) {
            Vector2 offsetPos = new Vector2(position.X + hexMath.hexConstants.HexRadius - 5, position.Y + hexMath.hexConstants.HexRadius - 5);

            if(building.GetBuildingType() != BuildingType.NIL && terrain.GetTerrainType() != TerrainType.Unknown) {
                building.DrawUI(spriteBatch, offsetPos, hexMath);
            }
        }

    }
}
