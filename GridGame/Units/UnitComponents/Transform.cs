using GridGame.Constants;
using GridGame.Hexagons;
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

        private Vector2 origin;

        public Transform((int, int) pos) {
            active = false;
            moving = false;

            Coords = pos;

            destRect = new Rectangle(0, 0, UnitInfo.UNIT_WIDTH, UnitInfo.UNIT_HEIGHT);
            infectedDestRect = new Rectangle(0, 0, UnitInfo.INFECTED_WIDTH, UnitInfo.INFECTED_HEIGHT);
        }

        public void SetOrigin(Vector2 origin) {
            this.origin = origin;
        }

        public void SetTargetCoords(int x, int y) {
            TargetCoords = (Coords.Item1 + x, Coords.Item2 + y);
        }

        public void SetDestRectDimensions(Vector2 pos, HexagonMath hexMath) {
            float scale = hexMath.GetScale();

            destRect.Width = (int)(UnitInfo.UNIT_WIDTH * scale);
            destRect.Height = (int)(UnitInfo.UNIT_HEIGHT * scale);

            infectedDestRect.Width = (int)(UnitInfo.INFECTED_WIDTH * scale);
            infectedDestRect.Height = (int)(UnitInfo.INFECTED_HEIGHT * scale);

            float centerX = ((origin.X * scale) / 2f) - (destRect.Width / 2);
            float centerY = ((origin.Y * scale) / 2f) - (destRect.Height / 2);

            destRect.X = (int)(pos.X + centerX);
            destRect.Y = (int)(pos.Y + centerY);

            int diffWidth = infectedDestRect.Width - destRect.Width;

            infectedDestRect.X = destRect.X - (diffWidth / 2);
            infectedDestRect.Y = destRect.Y - infectedDestRect.Height;
        }
    }
}
