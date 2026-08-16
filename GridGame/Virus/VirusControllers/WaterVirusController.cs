using GridGame.Hexagons;
using GridGame.Units;
using GridGame.Virus.BaseVirus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.VirusControllers {
    public class WaterVirusController : AbstractVirusController {

        private HexagonMap hexagonMap;

        public WaterVirusController(HexagonMap hexagonMap) {
            this.hexagonMap = hexagonMap;

            infectedTiles = new HashSet<(int, int)>();
            infectedPeople = new HashSet<IUnit>();
        }

        public override void InitialInfect() {
            //
        }

        public override void Spread() {
            //
        }

        public override InfectType GetInfectType() {
            return InfectType.WATER_INFECT;
        }

    }
}
