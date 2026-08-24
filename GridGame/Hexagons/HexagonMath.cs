using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridGame.Constants;
using SharpDX.Direct3D9;
using GridGame.Hexagons.Managers;
using System.Diagnostics;

namespace GridGame.Hexagons {
    public class HexagonMath {

        public HexagonConstants hexConstants;

        public int camPosX = 0;
        public int camPosY = 0;

        private CitizenManager citizens;

        public HexagonMath() {
            hexConstants = new HexagonConstants();
        }

        public void SetCitizens(CitizenManager citizens) {
            this.citizens = citizens;
        }

        public Vector2 HexToPixel(int Q, int R) {
            float rad = hexConstants.HexRadius;

            float x = Q * (rad * MathF.Sqrt(3) - (rad / 2)) - camPosX;
            float y = (R * rad * MathF.Sqrt(3)) * 0.9f + (Q * rad / 2) * 1.5f - camPosY;

            y += UIOverlayDetails.RESOURCE_BAR_HEIGHT;

            return new Vector2(x, y);
        }

        public Vector2 HexToPixelAbsolute(int Q, int R) {
            float rad = hexConstants.HexRadius;

            float x = Q * (rad * MathF.Sqrt(3) - (rad / 2));
            float y = (R * rad * MathF.Sqrt(3)) * 0.9f + (Q * rad / 2) * 1.5f;

            y += UIOverlayDetails.RESOURCE_BAR_HEIGHT;

            return new Vector2(x, y);
        }

        public (int, int) PixelToHex(Vector2 mousePos) {
            float radius = hexConstants.HexRadius;

            float x = mousePos.X + camPosX;
            float y = mousePos.Y + camPosY - UIOverlayDetails.RESOURCE_BAR_HEIGHT;

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

        public void MoveCameraUp() { 
            camPosY -= hexConstants.CameraMoveSpeedY;
            if(camPosY < 0) {
                camPosY = 0;
            }
        }

        public void MoveCameraDown() { 
            camPosY += hexConstants.CameraMoveSpeedY;
        }

        public void MoveCameraLeft() { 
            camPosX -= hexConstants.CameraMoveSpeedX;
            if(camPosX < 0) {
                camPosX = 0;
            }
        }

        public void MoveCameraRight() { 
            camPosX += hexConstants.CameraMoveSpeedX; 
        }

        public void ZoomIn() {
            float scaleOld = hexConstants.GetScale();
            hexConstants.ZoomIn();
            float scaleNew = hexConstants.GetScale();
            FocusCamera();
        }
        public void ZoomOut() {
            float scaleOld = hexConstants.GetScale();
            hexConstants.ZoomOut();
            float scaleNew = hexConstants.GetScale();
            FocusCamera();
        }

        public void FocusCamera() {
            Vector2 position = HexToPixelAbsolute(citizens.CurrentPlayer.transform.Coords.Item1, citizens.CurrentPlayer.transform.Coords.Item2);

            camPosX = (int)position.X - (GameConstants.WINDOW_WIDTH / 2) + (5 * TextureInfo.BORDER_WIDTH / 2);
            camPosY = (int)position.Y - (GameConstants.WINDOW_HEIGHT / 2) + (3 * TextureInfo.BORDER_HEIGHT / 2);

            camPosX = Max(0, camPosX);
            camPosY = Max(0, camPosY);
        }

        public int Max(int x, int y) {
            if(x > y) return x;
            return y;
        }

    }
}
