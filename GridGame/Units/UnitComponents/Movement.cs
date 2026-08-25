using GridGame.Constants;
using GridGame.Hexagons;
using GridGame.Tiles.Terrain;
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

        public void MoveUp() {
            if(transform.moving) return;

            transform.SetTargetCoords(0, -1);
            if(hexagonMap.citizenManager.HasOtherCitizenAtPos(transform.TargetCoords)) return;
            SetMoving();
        }

        public void MoveDown() {
            if(transform.moving) return;

            transform.SetTargetCoords(0, 1);
            if(hexagonMap.citizenManager.HasOtherCitizenAtPos(transform.TargetCoords)) return;
            SetMoving();
        }

        public void MoveUpRight() {
            if(transform.moving) return;

            transform.SetTargetCoords(1, -1);
            if(hexagonMap.citizenManager.HasOtherCitizenAtPos(transform.TargetCoords)) return;
            SetMoving();
        }

        public void MoveDownRight() {
            if(transform.moving) return;

            transform.SetTargetCoords(1, 0);
            if(hexagonMap.citizenManager.HasOtherCitizenAtPos(transform.TargetCoords)) return;
            SetMoving();
        }

        public void MoveUpLeft() {
            if(transform.moving) return;

            transform.SetTargetCoords(-1, 0);
            if(hexagonMap.citizenManager.HasOtherCitizenAtPos(transform.TargetCoords)) return;

            SetMoving();
        }

        public void MoveDownLeft() {
            if(transform.moving) return;

            transform.SetTargetCoords(-1, 1);

            if(hexagonMap.citizenManager.HasOtherCitizenAtPos(transform.TargetCoords)) return;
            SetMoving();
        }

        public void SetMoving() {
            if(hexagonMap.hexMap.Tiles[transform.TargetCoords].GetTerrainType() == TerrainType.Ocean) return;

            transform.moving = true;
            ResetTime();
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
