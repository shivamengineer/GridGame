using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Tiles {
    public interface ITile {

        public void SetTextures(Texture2D borderTexture, Texture2D baseTexture);

        public void AddPeople(int numPeople);

        public void RemovePeople(int numPeople);

        public int GetNumPeople();

        public int GetMaxPeople();

        public int GetResources();

        public void SetTile(ITile tile);

        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch);
    }
}
