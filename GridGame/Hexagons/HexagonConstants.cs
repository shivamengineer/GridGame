using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons {
    public class HexagonConstants {

        public int CameraMoveSpeedX;
        public int CameraMoveSpeedY;

        public float HexRadius;
        private float HexRadiusScaled;
        private float baseHexRadius;

        private float Scale;
        private float counter;
        private float offset;

        private float zoomSpeed;
        private float minScale;
        private float maxScale;

        public HexagonConstants() {
            CameraMoveSpeedX = 3;
            CameraMoveSpeedY = 3;

            Scale = 1;
            baseHexRadius = 35f;
            HexRadiusScaled = baseHexRadius * Scale;
            HexRadius = HexRadiusScaled + offset;

            offset = 0;
            counter = 0;

            zoomSpeed = 0.02f;
            minScale = 1f;
            maxScale = 5f;
        }

        public void Update() {
            SetScale(Scale + 0.002f);

            counter += 0.001f;
            offset = 2 * MathF.Sin(counter);

            HexRadius = HexRadiusScaled + offset;
        }

        private void SetScale(float newScale) {
            Scale = newScale;
            HexRadiusScaled = baseHexRadius * Scale;

            HexRadius = HexRadiusScaled + offset;
        }

        public float GetScale() {
            return Scale;
        }

        public void ZoomIn() {
            if(Scale >= maxScale) return;
            SetScale(Scale + zoomSpeed);
        }

        public void ZoomOut() {
            if(Scale <= minScale) return;
            SetScale(Scale - zoomSpeed);
        }

    }
}
