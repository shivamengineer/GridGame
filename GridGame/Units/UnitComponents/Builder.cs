using GridGame.Constants;
using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.Constants.Resources;
using GridGame.Hexagons;
using GridGame.Virus.BaseVirus;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Units.UnitComponents {
    public class Builder {

        private HexagonMap hexagonMap;
        private Transform transform;
        private VirusController virusController;

        private float TimeElapsed = 0f;

        private int productivity = 10;

        private Dictionary<ConstGame, int> GameInts;
        private Dictionary<ConstGame, float> GameFloats;

        public Builder(HexagonMap hexagonMap, Transform transform, VirusController virusController, ConstantsController Constants) {
            this.hexagonMap = hexagonMap;
            this.transform = transform;
            this.virusController = virusController;
            GameInts = Constants.GetGameInts();
            GameFloats = Constants.GetGameFloats();
        }

        public void Eat() {
            productivity += FoodStats.PRODUCTIVITY_GAIN_FROM_FOOD; //replenish energy
            if(productivity > 10) productivity = 10;
        }

        public void WorkAtBuilding(GameTime gameTime) {
            if(!UpdateTime(gameTime)) return;
            GrowHungry();

            if(!hexagonMap.hexMap.Tiles[transform.Coords].IsBuilding()) hexagonMap.WorkTile(transform.Coords);
            else BuildBuilding();
        }

        private bool UpdateTime(GameTime gameTime) {
            TimeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(TimeElapsed >= GameFloats[ConstGame.CollectResourceInterval]) {
                TimeElapsed -= GameFloats[ConstGame.CollectResourceInterval];
                return true;
            }
            return false;
        }

        private void GrowHungry() {
            productivity -= FoodStats.PRODUCTIVITY_BASE_LOSS; // grow hungry if working
            if(productivity < 0) productivity = 0;
        }

        private void BuildBuilding() {
            int production = productivity * GameInts[ConstGame.CitizenBaseProductivity];
            if(!virusController.virusesImmune.Contains(VirusNames.Coronavirus) && virusController.viruses.ContainsKey(VirusNames.Coronavirus)) {
                IVirus virus = virusController.viruses[VirusNames.Coronavirus];
                production = (int)virus.AttackCitizen.GetProductivity(production);
            }
            hexagonMap.ConstructBuilding(transform.Coords, production * GameInts[ConstGame.CitizenBaseProductivity]);
        }

    }
}
