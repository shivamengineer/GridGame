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

        private UnitColor unitColor;

        public Citizen((int, int) pos, HexagonMap hexagonMap) {
            transform = new Transform(pos);
            unitColor = new UnitColor();

            viruses = new Dictionary<InfectType, IVirus>();
            virusesImmune = new HashSet<VirusNames>();

            this.hexagonMap = hexagonMap;

            movement = new Movement(hexagonMap, transform);
        }

        public override void Update(GameTime gameTime) {
            if(transform.moving) {
                movement.UpdatePos(gameTime);
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

            Vector2 position = Vector2.Lerp(posBefore, targetPos, movement.progress);
            transform.SetDestRectDimensions(position, hexMath);

            DrawCitizen(spriteBatch);
        }

        private void DrawStationary(SpriteBatch spriteBatch, HexagonMath hexMath) {
            Vector2 position = hexMath.HexToPixel(transform.Coords);
            transform.SetDestRectDimensions(position, hexMath);

            DrawCitizen(spriteBatch);
        }

        private void DrawCitizen(SpriteBatch spriteBatch) {
            DrawCitizenBase(spriteBatch);
            DrawInfectedBar(spriteBatch);
        }

        private void DrawCitizenBase(SpriteBatch spriteBatch) {
            if(transform.active) spriteBatch.Draw(texture, transform.destRect, unitColor.Active);
            else spriteBatch.Draw(texture, transform.destRect, unitColor.Inactive);
        }

        private void DrawInfectedBar(SpriteBatch spriteBatch) {
            if(!viruses.ContainsKey(InfectType.CITIZEN_INFECT)) return;
            if(virusesImmune.Contains(VirusNames.Coronavirus)) return;
            if(viruses[InfectType.CITIZEN_INFECT].IsAsymptomatic()) {
                spriteBatch.Draw(texture, transform.infectedDestRect, Color.Blue); //shows if citizen is sick but asymptomatic
                return;
            }
            spriteBatch.Draw(texture, transform.infectedDestRect, unitColor.Infected);
        }

    }
}
