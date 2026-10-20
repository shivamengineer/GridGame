using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Interface {
    public abstract class AbstractConstantBlock : IConstantBlock {

        public Rectangle Background;
        public string Text;

        public void SetBackground() {
            //
        }

        public void Draw(SpriteBatch spriteBatch) {
            
        }

    }
}
