using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons {
    public class HexagonConstants {

        public float HexRadius;
        private float HexRadiusScaled;
        private float baseHexRadius;

        private float Scale;
        private float counter;
        private float offset;

        public HexagonConstants() {
            Scale = 1;
            baseHexRadius = 35f;
            HexRadiusScaled = baseHexRadius * Scale;
            HexRadius = HexRadiusScaled + offset;

            offset = 0;
            counter = 0;
        }

        public void Update() {
            SetScale(Scale + 0.002f);

            counter += 0.001f;
            offset = 2 * MathF.Sin(counter);

            HexRadius = HexRadiusScaled + offset;
        }

        public void SetScale(float newScale) {
            Scale = newScale;
            HexRadiusScaled = baseHexRadius * Scale;
        }

        public float GetScale() {
            return Scale;
        }

    }
}
