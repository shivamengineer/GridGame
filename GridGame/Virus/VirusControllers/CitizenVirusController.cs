using GridGame.Hexagons;
using GridGame.Hexagons.Managers;
using GridGame.Units.UnitClasses;
using GridGame.Virus.BaseVirus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.VirusControllers {
    public class CitizenVirusController : AbstractVirusController {

        private HexagonMap hexagonMap;
        private CitizenManager citizenManager;

        public CitizenVirusController(HexagonMap hexagonMap) {
            this.hexagonMap = hexagonMap;
            citizenManager = hexagonMap.citizenManager;
        }

        public override void InitialInfect() {
            int citizenIndex = Random.Shared.Next(citizenManager.Citizens.Count);
            Citizen infectedCitizen = citizenManager.Citizens[citizenIndex];

            Random random = new Random();
            float strength = 0.25f + (float)(random.NextDouble() * 0.5);
            infectedCitizen.viruses.Add(new Coronavirus(strength));
        }

        public override void Spread() {
            // 
        }

        public override InfectType GetInfectType() {
            return InfectType.CITIZEN_INFECT;
        }

    }
}
