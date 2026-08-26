using GridGame.Hexagons;
using GridGame.TextureLoading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Units {
    public interface IUnit {

        public void SetTexture(ContentLoader Content);

        public void SetActive(bool active);

        public void Update(GameTime gameTime);

        public void Draw(SpriteBatch spriteBatch, HexagonMath hexMath);

    }
}
