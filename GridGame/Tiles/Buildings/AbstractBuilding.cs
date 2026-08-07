using GridGame.Constants;
using GridGame.GameManagers;
using GridGame.Hexagons;
using GridGame.Resources;
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

        public int production_spent = 0;
        public int production_needed = 0;

        public bool constructed = false;

        public HexagonMap map;

        public void SetTextures(Texture2D borderTexture, Texture2D baseTexture) {
            this.borderTexture = borderTexture;
            this.baseTexture = baseTexture;

            origin = new Vector2(borderTexture.Width / 2f, borderTexture.Height / 2f);
        }

        public void SetMap(HexagonMap map) {
            this.map = map;
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
            if(!constructed) return;

            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(timeElapsed >= GameConstants.RESOURCE_TICK_SPEED) {
                timeElapsed -= GameConstants.RESOURCE_TICK_SPEED;
                UpdateEvent(displayManager);
            }
        }

        public abstract int GetMaxPeople();

        public int Build(int production) {
            production_spent += production;

            if(production_spent >= production_needed) {
                constructed = true;
                return production_needed - production_spent;
            }
            return 0;
        }

        public bool IsBuilding() { return !constructed; }

        public abstract BuildingType GetBuildingType();

        public abstract IBuilding newInstance();

        public abstract int GetResources();

        public abstract void SetTile(ITile tile);

        public abstract void UpdateEvent(DisplayManager displayManager);

        public abstract void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath);

    }
}
