using GridGame.Constants;
using GridGame.Constants.Colors;
using GridGame.Constants.Resources;
using GridGame.Hexagons;
using GridGame.Virus.BaseVirus;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Units.UnitClasses {
    public class Citizen : AbstractUnit {

        private Color unitColorInactive;
        private Color unitColorActive;

        public Citizen((int, int) pos, HexagonMap hexagonMap) {
            Coords = pos;
            unitColorInactive = CitizenColors.InactiveColor;
            unitColorActive = CitizenColors.ActiveColor;

            viruses = new Dictionary<InfectType, IVirus>();

            destRect = new Rectangle(0, 0, UnitInfo.UNIT_WIDTH, UnitInfo.UNIT_HEIGHT);
            this.hexagonMap = hexagonMap;
        }

        public override void Update(GameTime gameTime) {
            if(moving) {
                UpdatePos(gameTime);
            } else {
                WorkAtBuilding(gameTime);
            }
            foreach(var virus in viruses.Values) {
                virus.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, HexagonMath hexMath) {
            if(moving) {
                DrawMoving(spriteBatch, hexMath);
            } else {
                DrawStationary(spriteBatch, hexMath);
            }
        }

        private void DrawMoving(SpriteBatch spriteBatch, HexagonMath hexMath) {
            Vector2 posBefore = hexMath.HexToPixel(Coords.Item1, Coords.Item2);
            Vector2 targetPos = hexMath.HexToPixel(TargetCoords.Item1, TargetCoords.Item2);

            Vector2 position = Vector2.Lerp(posBefore, targetPos, progress);
            SetDestRectDimensions(position, hexMath);

            DrawCitizen(spriteBatch);
        }

        private void DrawStationary(SpriteBatch spriteBatch, HexagonMath hexMath) {
            Vector2 position = hexMath.HexToPixel(Coords.Item1, Coords.Item2);
            SetDestRectDimensions(position, hexMath);

            DrawCitizen(spriteBatch);
        }

        private void DrawCitizen(SpriteBatch spriteBatch) {
            if(active) spriteBatch.Draw(texture, destRect, unitColorActive);
            else spriteBatch.Draw(texture, destRect, unitColorInactive);
        }

        private void SetDestRectDimensions(Vector2 pos, HexagonMath hexMath) {
            float scale = hexMath.GetScale();

            destRect.Width = (int)(UnitInfo.UNIT_WIDTH * scale);
            destRect.Height = (int)(UnitInfo.UNIT_HEIGHT * scale);

            float centerX = ((origin.X * scale) / 2f) - (destRect.Width / 2);
            float centerY = ((origin.Y * scale) / 2f) - (destRect.Height / 2);

            destRect.X = (int)(pos.X + centerX);
            destRect.Y = (int)(pos.Y + centerY);
        }

    }
}
