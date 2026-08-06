using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Units {
    public abstract class AbstractUnit : IUnit {

        public (int, int) LastPos;

        public (int, int) Pos;

        public (int, int) Coords;
        public (int, int) TargetCoords;

        public void MoveTo(int q, int r) {
            //
        }

        public void MoveUp() {
            Pos.Item2--;
        }

        public void MoveDown() {
            Pos.Item2++;
        }

        public void MoveUpRight() {
            Pos.Item1++;
            Pos.Item2--;
        }

        public void MoveDownRight() {
            Pos.Item1++;
        }

        public void MoveUpLeft() {
            Pos.Item1--;
        }

        public void MoveDownLeft() {
            Pos.Item1--;
            Pos.Item2++;
        }

        public void SetTargetCoords() {
            TargetCoords = 
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch); 

    }
}
