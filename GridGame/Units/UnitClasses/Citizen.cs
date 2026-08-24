using GridGame.Constants;
using GridGame.Constants.Colors;
using GridGame.Constants.Resources;
using GridGame.Hexagons;
using GridGame.Units.UnitComponents;
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
        private Color infectRectColor;

        public Citizen((int, int) pos, HexagonMap hexagonMap) {
            transform = new Transform(pos);
            unitColorInactive = CitizenColors.InactiveColor;
            unitColorActive = CitizenColors.ActiveColor;
            infectRectColor = CitizenColors.InfectColor;

            viruses = new Dictionary<InfectType, IVirus>();
            virusesImmune = new HashSet<VirusNames>();

            //transform.destRect = new Rectangle(0, 0, UnitInfo.UNIT_WIDTH, UnitInfo.UNIT_HEIGHT);
            //transform.infectedDestRect = new Rectangle(0, 0, UnitInfo.INFECTED_WIDTH, UnitInfo.INFECTED_HEIGHT);
            this.hexagonMap = hexagonMap;
        }

        public override void Update(GameTime gameTime) {
            if(transform.moving) {
                UpdatePos(gameTime);
            } else {
                WorkAtBuilding(gameTime);
            }
            foreach(var virus in viruses.Values) {
                if(!virus.IsRecovered()) virus.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, HexagonMath hexMath) {
            if(transform.moving) DrawMoving(spriteBatch, hexMath);
            else DrawStationary(spriteBatch, hexMath);
        }

        private void DrawMoving(SpriteBatch spriteBatch, HexagonMath hexMath) {
            Vector2 posBefore = hexMath.HexToPixel(transform.Coords);
            Vector2 targetPos = hexMath.HexToPixel(transform.TargetCoords);

            Vector2 position = Vector2.Lerp(posBefore, targetPos, progress);
            SetDestRectDimensions(position, hexMath);

            DrawCitizen(spriteBatch);
        }

        private void DrawStationary(SpriteBatch spriteBatch, HexagonMath hexMath) {
            Vector2 position = hexMath.HexToPixel(transform.Coords);
            SetDestRectDimensions(position, hexMath);

            DrawCitizen(spriteBatch);
        }

        private void DrawCitizen(SpriteBatch spriteBatch) {
            DrawCitizenBase(spriteBatch);
            DrawInfectedBar(spriteBatch);
        }

        private void DrawCitizenBase(SpriteBatch spriteBatch) {
            if(transform.active) spriteBatch.Draw(texture, transform.destRect, unitColorActive);
            else spriteBatch.Draw(texture, transform.destRect, unitColorInactive);
        }

        private void DrawInfectedBar(SpriteBatch spriteBatch) {
            if(!viruses.ContainsKey(InfectType.CITIZEN_INFECT)) return;
            if(virusesImmune.Contains(VirusNames.Coronavirus)) return;
            if(viruses[InfectType.CITIZEN_INFECT].IsAsymptomatic()) {
                spriteBatch.Draw(texture, transform.infectedDestRect, Color.Blue); //shows if citizen is sick but asymptomatic
                return;
            }
            spriteBatch.Draw(texture, transform.infectedDestRect, infectRectColor);
        }

        private void SetDestRectDimensions(Vector2 pos, HexagonMath hexMath) {
            float scale = hexMath.GetScale();

            transform.destRect.Width = (int)(UnitInfo.UNIT_WIDTH * scale);
            transform.destRect.Height = (int)(UnitInfo.UNIT_HEIGHT * scale);

            transform.infectedDestRect.Width = (int)(UnitInfo.INFECTED_WIDTH * scale);
            transform.infectedDestRect.Height = (int)(UnitInfo.INFECTED_HEIGHT * scale);

            float centerX = ((origin.X * scale) / 2f) - (transform.destRect.Width / 2);
            float centerY = ((origin.Y * scale) / 2f) - (transform.destRect.Height / 2);

            transform.destRect.X = (int)(pos.X + centerX);
            transform.destRect.Y = (int)(pos.Y + centerY);

            int diffWidth = transform.infectedDestRect.Width - transform.destRect.Width;

            transform.infectedDestRect.X = transform.destRect.X - (diffWidth / 2);
            transform.infectedDestRect.Y = transform.destRect.Y - transform.infectedDestRect.Height;
        }

    }
}
