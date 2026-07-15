using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons {
    public class HexagonConstants {

        public float HexRadius;
        private float counter;

        public HexagonConstants() {
            HexRadius = 35f;
            counter = 0;
        }

        public void Update() {
            counter += 0.001f;
            HexRadius = 35 + (2 * MathF.Sin(counter));

        }

    }
}
