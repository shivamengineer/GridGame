using GridGame.Constants;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Units.UnitComponents {
    public class Transform {
        public (int, int) Coords;
        public (int, int) TargetCoords;

        public Rectangle destRect;
        public Rectangle infectedDestRect;

        public bool active;
        public bool moving;

        public Transform((int, int) pos) {
            active = false;
            moving = false;

            Coords = pos;

            destRect = new Rectangle(0, 0, UnitInfo.UNIT_WIDTH, UnitInfo.UNIT_HEIGHT);
            infectedDestRect = new Rectangle(0, 0, UnitInfo.INFECTED_WIDTH, UnitInfo.INFECTED_HEIGHT);
        }

        public void SetTargetCoords(int x, int y) {
            TargetCoords = (Coords.Item1 + x, Coords.Item2 + y);
        }
    }
}
