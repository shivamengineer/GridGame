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

        public abstract int GetMaxPeople();

        public abstract void Build();

        public abstract int GetResources();

        public abstract void SetTile(ITile tile);

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath);

    }
}
