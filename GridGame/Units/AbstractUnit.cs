using GridGame.Constants;
using GridGame.Hexagons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Units {
    public abstract class AbstractUnit : IUnit {

        public (int, int) Coords;
        public (int, int) TargetCoords;

        public bool moving = false;
        public float progress = 0f;
        public float timeElapsed = 0f;

        public void MoveTo(int q, int r) {
            //
        }

        public void MoveUp() {
            TargetCoords = Coords;
            TargetCoords.Item2--;
            SetMoving();
        }

        public void MoveDown() {
            TargetCoords = Coords;
            TargetCoords.Item2++;
            SetMoving();
        }

        public void MoveUpRight() {
            TargetCoords = (Coords.Item1 + 1, Coords.Item2 - 1);
            SetMoving();
        }

        public void MoveDownRight() {
            TargetCoords = Coords;
            TargetCoords.Item1++;
            SetMoving();
        }

        public void MoveUpLeft() {
            TargetCoords = Coords;
            TargetCoords.Item1--;
            SetMoving();
        }

        public void MoveDownLeft() {
            TargetCoords = (Coords.Item1 - 1, Coords.Item2 - 1);
            SetMoving();
        }

        public void SetMoving() {
            moving = true;
            timeElapsed = 0f;
        }

        public void UpdatePos(GameTime gameTime) {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            progress = timeElapsed / UnitInfo.UNIT_MOVE_TIME;
            if(progress > 1.0f) {
                progress = 1.0f;
            }
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch, Vector2 position, HexagonMath hexMath); 

    }
}
