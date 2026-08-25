using GridGame.Constants.Viruses.Covid;
using GridGame.Hexagons;
using GridGame.Hexagons.Managers;
using GridGame.Units.UnitClasses;
using GridGame.Virus.BaseVirus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.VirusControllers {
    public class CitizenVirusController : AbstractVirusController {

        private HexagonMap hexagonMap;
        private CitizenManager citizenManager;
        private float timeElapsed = 0f;
        private int virusID;

        public CitizenVirusController(HexagonMap hexagonMap) {
            this.hexagonMap = hexagonMap;
            citizenManager = hexagonMap.citizenManager;
        }

        public override void InitialInfect() {
            int citizenIndex = Random.Shared.Next(citizenManager.Citizens.Count);
            Citizen infectedCitizen = citizenManager.Citizens[citizenIndex];

            Random random = new Random();
            float strength = CovidStats.MIN_STRENGTH + (float)(random.NextDouble() * CovidStats.STRENGTH_RANGE);
            if(infectedCitizen.virusController.viruses.ContainsKey(InfectType.CITIZEN_INFECT)) return;

            string id = "covid" + virusID;
            infectedCitizen.virusController.viruses.Add(InfectType.CITIZEN_INFECT, new Coronavirus(hexagonMap, infectedCitizen, strength, id));
        }

        public override void Spread() {
            // 
        }

        public override InfectType GetInfectType() {
            return InfectType.CITIZEN_INFECT;
        }

        

    }
}
