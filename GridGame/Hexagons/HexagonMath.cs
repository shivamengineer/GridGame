using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Hexagons {
    public class HexagonMath {

        public HexagonConstants hexConstants;

        public int camPosX = 0;
        public int camPosY = 0;

        public HexagonMath() {
            hexConstants = new HexagonConstants();
        }

        public Vector2 HexToPixel(Hex hex) {
            float rad = hexConstants.HexRadius;

            float x = hex.Q * (rad * MathF.Sqrt(3) - (rad / 2)) - camPosX;
            float y = (hex.R * rad * MathF.Sqrt(3)) * 0.9f + (hex.Q * rad / 2) * 1.5f - camPosY;

            return new Vector2(x, y);
        }

        public (int, int) PixelToHex(Vector2 mousePos) {
            float radius = hexConstants.HexRadius;

            float x = mousePos.X + camPosX;
            float y = mousePos.Y + camPosY;

            float A = radius * (MathF.Sqrt(3f) - 0.5f);
            float B = radius * 0.75f;
            float C = radius * 0.9f * MathF.Sqrt(3f);

            float q = x / A;
            float r = (y - B * q) / C;

            return (
                (int)MathF.Round(q),
                (int)MathF.Round(r)
            );
        }

        public float GetScale() {
            return hexConstants.GetScale();
        }

        public void MoveCameraUp() { camPosY -= hexConstants.CameraMoveSpeedY; }
        public void MoveCameraDown() { camPosY += hexConstants.CameraMoveSpeedY; }
        public void MoveCameraLeft() { camPosX -= hexConstants.CameraMoveSpeedX; }
        public void MoveCameraRight() { camPosX += hexConstants.CameraMoveSpeedX; }

        public void ZoomIn() { hexConstants.ZoomIn(); }
        public void ZoomOut() { hexConstants.ZoomOut(); }

    }
}
