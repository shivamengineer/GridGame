using GridGame.Constants;
using GridGame.Hexagons;
using GridGame.TextureLoading;
using GridGame.TextureLoading.TextureEnums;
using GridGame.Tiles.Terrain;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Units {
    public abstract class AbstractUnit : IUnit {

        public Texture2D texture;

        public (int, int) Coords;
        public (int, int) TargetCoords;

        public bool moving = false;
        public float progress = 0f;
        public float timeElapsed = 0f;

        public Rectangle destRect;

        public Vector2 origin;
        public HexagonMap hexagonMap;

        public void SetTexture(ContentLoader Content) {
            texture = Content.GetTexture(TextureLoading.TextureEnums.TextureNames.BLANK_RECTANGLE);
            Texture2D BorderTexture = Content.GetTexture(TextureNames.BLANK_HEXAGON_BORDER);
            origin = new Vector2(BorderTexture.Width / 3, BorderTexture.Height / 3);
        }

        public void MoveTo(int q, int r) {
            //
        }

        public void MoveUp() {
            if(moving) return;

            TargetCoords = Coords;
            TargetCoords.Item2--;

            SetMoving();
        }

        public void MoveDown() {
            if(moving) return;

            TargetCoords = Coords;
            TargetCoords.Item2++;

            if(hexagonMap.playerData.CitizenPositions.Contains(TargetCoords)) return;

            SetMoving();
        }

        public void MoveUpRight() {
            if(moving) return;

            TargetCoords = (Coords.Item1 + 1, Coords.Item2 - 1);

            if(hexagonMap.playerData.CitizenPositions.Contains(TargetCoords)) return;

            SetMoving();
        }

        public void MoveDownRight() {
            if(moving) return;

            TargetCoords = Coords;
            TargetCoords.Item1++;

            if(hexagonMap.playerData.CitizenPositions.Contains(TargetCoords)) return;

            SetMoving();
        }

        public void MoveUpLeft() {
            if(moving) return;

            TargetCoords = Coords;
            TargetCoords.Item1--;

            if(hexagonMap.playerData.CitizenPositions.Contains(TargetCoords)) return;

            SetMoving();
        }

        public void MoveDownLeft() {
            if(moving) return;

            TargetCoords = (Coords.Item1 - 1, Coords.Item2 + 1);

            if(hexagonMap.playerData.CitizenPositions.Contains(TargetCoords)) return;

            SetMoving();
        }

        public void SetMoving() {
            if(hexagonMap.hexMap.Tiles[TargetCoords].GetTerrainType() == TerrainType.Ocean) return;

            moving = true;
            timeElapsed = 0f;
        }

        public void UpdatePos(GameTime gameTime) {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            progress = timeElapsed / UnitInfo.UNIT_MOVE_TIME;
            if(progress > 1.0f) {
                progress = 1.0f;
                Coords = TargetCoords;
                moving = false;

                hexagonMap.UpdateVision(Coords, UnitInfo.UNIT_VISION_RADIUS);
            }
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch, HexagonMath hexMath); 

    }
}
