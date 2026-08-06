using GridGame.Constants;
using GridGame.GameManagers;
using GridGame.Hexagons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Tiles.Buildings {
    public abstract class AbstractBuilding : IBuilding {

        private int population = 0;

        public Texture2D borderTexture;
        public Texture2D baseTexture;

        public Vector2 origin;

        private float timeElapsed = 0f;

        public void SetTextures(Texture2D borderTexture, Texture2D baseTexture) {
            this.borderTexture = borderTexture;
            this.baseTexture = baseTexture;

            origin = new Vector2(borderTexture.Width / 2f, borderTexture.Height / 2f);
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

        public void Update(GameTime gameTime, DisplayManager displayManager) {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(timeElapsed >= GameConstants.RESOURCE_TICK_SPEED) {
                timeElapsed -= GameConstants.RESOURCE_TICK_SPEED;
                UpdateEvent(displayManager);
            }
        }

        public abstract int GetMaxPeople();

        public abstract void Build();

        public abstract BuildingType GetBuildingType();

        public abstract IBuilding newInstance();

        public abstract int GetResources();

        public abstract void SetTile(ITile tile);

        public abstract void UpdateEvent(DisplayManager displayManager);

        public abstract void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath);

    }
}
