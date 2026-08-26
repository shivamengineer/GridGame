using GridGame.Constants.Viruses.Covid;
using GridGame.Hexagons;
using GridGame.Hexagons.Managers;
using GridGame.Hexagons.StaticClasses;
using GridGame.Units.UnitClasses;
using GridGame.Virus.BaseVirus.VirusComponents.InfectComponents;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.BaseVirus {
    public class Coronavirus : AbstractVirus {

        private Citizen citizen;
        private HexagonMap hexagonMap;

        private VirusNames virusName;

        public Coronavirus(HexagonMap hexagonMap, Citizen citizen, float strength) {
            this.citizen = citizen;
            this.hexagonMap = hexagonMap;

            virusStrength = strength;
            limitCitizenPercent = 1f - strength;

            BaseDuration = CovidStats.VIRUS_BASE_DURATION;
            AsymptomaticTime = BaseDuration / 3;

            virusName = VirusNames.Coronavirus;
            Infect = new AirborneInfect(hexagonMap.citizenManager, citizen, this);
        }

        public override void UpdateEvent() {
            //
        }

        public override void OnVirusDurationEnd() {
            Random random = new Random();
            float rand = (float)random.NextDouble();
            if(rand <= CovidStats.MORTALITY_RATE) {
                hexagonMap.citizenManager.ToRemoveCitizens.Push(citizen);
            } else {
                citizen.virusController.virusesImmune.Add(VirusNames.Coronavirus);
                recovered = true;
            }
        }

        public override IVirus NewInstance(Citizen citizen) {
            return new Coronavirus(hexagonMap, citizen, virusStrength);
        }

    }
}
