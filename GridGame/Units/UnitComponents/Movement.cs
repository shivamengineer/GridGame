using GridGame.Constants;
using GridGame.Hexagons;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Units.UnitComponents {
    public class Movement(HexagonMap hexagonMap, Transform transform) {

        public float progress = 0f;
        public float TimeElapsed = 0f;
        public float TimeElapsedWorking = 0f;

        private HexagonMap hexagonMap = hexagonMap;
        private Transform transform = transform;

        public void ResetTime() {
            TimeElapsed = 0f;
            TimeElapsedWorking = 0f;
        }

        public void UpdatePos(GameTime gameTime) {
            TimeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            progress = TimeElapsed / UnitInfo.UNIT_MOVE_TIME;
            if(progress >= 1.0f) {
                FinishMoving();
                UpdateHexagonMap();
            }
        }

        private void FinishMoving() {
            progress = 1.0f;
            transform.Coords = transform.TargetCoords;
            transform.moving = false;
        }

        private void UpdateHexagonMap() {
            hexagonMap.citizenManager.UpdatePos();
            hexagonMap.hexMap.UpdateVision(transform.Coords, UnitInfo.UNIT_VISION_RADIUS);
            hexagonMap.hexMap.HexMath.FocusCamera();
            hexagonMap.SetHover(hexagonMap.hexMap.HoveredTile);
        }
    }
}
