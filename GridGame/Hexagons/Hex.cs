using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons {
    public struct Hex {
        public int Q;
        public int R;

        public Hex(int q, int r) {
            Q = q;
            R = r;
        }
    }
}
