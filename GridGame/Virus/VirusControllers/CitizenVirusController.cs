using GridGame.Constants.Controller;
using GridGame.Constants.Viruses.Covid;
using GridGame.Hexagons;
using GridGame.Hexagons.Managers;
using GridGame.Units.UnitClasses;
using GridGame.Virus.BaseVirus;
using GridGame.Virus.BaseVirus.Viruses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.VirusControllers {
    public class CitizenVirusController : AbstractVirusController {

        private CitizenManager citizenManager;
        private ConstantsController Constants;

        public CitizenVirusController(CitizenManager citizenManager, ConstantsController Constants) {
            this.citizenManager = citizenManager;
            this.Constants = Constants;
        }

        public override void InitialInfect() {
            if(citizenManager.Citizens.Count == 0) return;

            Citizen infectedCitizen = GetRandomCitizen();
            InitialCovidInfect(infectedCitizen);
        }

        public override InfectType GetInfectType() {
            return InfectType.CITIZEN_INFECT;
        }

        private Citizen GetRandomCitizen() {
            int citizenIndex = Random.Shared.Next(citizenManager.Citizens.Count);
            return citizenManager.Citizens[citizenIndex];
        }

        private void InitialCovidInfect(Citizen infectedCitizen) {
            float strength = GetCovidStrength();
            if(infectedCitizen.virusController.viruses.ContainsKey(VirusNames.Coronavirus)) return;

            infectedCitizen.virusController.viruses.Add(VirusNames.Coronavirus, new Coronavirus(citizenManager, infectedCitizen, strength, Constants));
        }

        private float GetCovidStrength() {
            Random random = new Random();
            return (CovidStats.MIN_STRENGTH + (float)(random.NextDouble() * CovidStats.STRENGTH_RANGE));
        }

    }
}
