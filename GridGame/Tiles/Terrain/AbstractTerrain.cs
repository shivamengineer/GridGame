using GridGame.Constants;
using GridGame.GameManagers;
using GridGame.Hexagons;
using GridGame.Resources;
using GridGame.TextureLoading;
using GridGame.TextureLoading.TextureEnums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Tiles.Terrain {
    public abstract class AbstractTerrain : ITerrain {

        private int population = 0;

        public Texture2D borderTexture;
        public Texture2D baseTexture;

        public Vector2 origin;

        private float timeElapsed = 0f;

        //

        public void SetTextures(Texture2D borderTexture, Texture2D baseTexture) {
            this.borderTexture = borderTexture;
            this.baseTexture = baseTexture;
        }

        public void SetContent(ContentLoader content) {
            borderTexture = content.GetTexture(TextureNames.BLANK_HEXAGON_BORDER);
            baseTexture = content.GetTexture(TextureNames.BLANK_HEXAGON_BACKGROUND);
        }

        public void SetMap(HexagonMap map) {
            //
        }

        public void AddPeople(int numPeople) {
            population += numPeople;
        }

        public void RemovePeople(int numPeople) {
            population -= numPeople;
        }

        public int GetNumPeople() {
            return population;
        }

        public int GetMaxPeople() {
            return 1;
        }

        public void Update(GameTime gameTime, DisplayManager displayManager) {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            if(timeElapsed >= GameConstants.RESOURCE_TICK_SPEED) {
                timeElapsed -= GameConstants.RESOURCE_TICK_SPEED;
                UpdateEvent(displayManager);
            }
        }

        public abstract int GetResources();

        public abstract void SetTile(ITile tile);

        public abstract TerrainType GetTerrainType();

        public abstract ITerrain newInstance();

        public abstract void UpdateEvent(DisplayManager displayManager);

        public abstract void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath);

        public abstract void DrawBackground(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath);

    }
}
