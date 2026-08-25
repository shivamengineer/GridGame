using GridGame.Constants;
using GridGame.Constants.Resources;
using GridGame.Hexagons;
using GridGame.Virus.BaseVirus;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
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

        public Builder(HexagonMap hexagonMap, Transform transform, VirusController virusController) {
            this.hexagonMap = hexagonMap;
            this.transform = transform;
            this.virusController = virusController;
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
            if(TimeElapsed >= GameConstants.RESOURCE_TICK_SPEED) {
                TimeElapsed -= GameConstants.RESOURCE_TICK_SPEED;
                return true;
            }
            return false;
        }

        private void GrowHungry() {
            productivity -= FoodStats.PRODUCTIVITY_BASE_LOSS; // grow hungry if working
            if(productivity < 0) productivity = 0;
        }

        private void BuildBuilding() {
            int production = productivity * CityBaseStats.CITIZEN_BASE_PRODUCTIVITY;
            if(!virusController.virusesImmune.Contains(VirusNames.Coronavirus) && virusController.viruses.ContainsKey(InfectType.CITIZEN_INFECT)) {
                production = (int)virusController.viruses[InfectType.CITIZEN_INFECT].GetCitizenProductivity(production);
            }
            hexagonMap.BuildBuilding(transform.Coords, productivity * CityBaseStats.CITIZEN_BASE_PRODUCTIVITY);
        }

    }
}
