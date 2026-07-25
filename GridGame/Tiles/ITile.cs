using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Tiles {
    public interface ITile {
        public void GetResources();

        public void SetTile(ITile tile);

        public void Draw(SpriteBatch spriteBatch);
    }
}
