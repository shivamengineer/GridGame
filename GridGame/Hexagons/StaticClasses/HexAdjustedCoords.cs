using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons.StaticClasses {
    public static class HexAdjustedCoords {

        public static (int, int) AdjustedPos((int, int) pos) {
            int x;

            if(pos.Item1 % 2 == 0) {
                x = pos.Item1 / 2;
            } else {
                x = (pos.Item1 + 1) / 2;
            }

            return (pos.Item1, pos.Item2 - x);
        }

    }
}
