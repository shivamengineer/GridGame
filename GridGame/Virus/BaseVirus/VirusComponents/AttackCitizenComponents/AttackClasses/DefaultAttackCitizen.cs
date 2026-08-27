using GridGame.Constants.Viruses.Covid;
using GridGame.Hexagons;
using GridGame.Hexagons.Managers;
using GridGame.Units.UnitClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.BaseVirus.VirusComponents.AttackCitizenComponents.AttackClasses {
    public class DefaultAttackCitizen : AbstractAttackCitizen {

        private CitizenManager citizenManager;
        private Citizen citizen;

        private VirusNames virusName;

        public DefaultAttackCitizen(CitizenManager citizenManager, Citizen citizen, float strength) {
            this.citizenManager = citizenManager;
            this.citizen = citizen;

            virusStrength = strength;
            limitCitizenPercent = 1f - strength;

            BaseDuration = CovidStats.VIRUS_BASE_DURATION;
            AsymptomaticTime = BaseDuration / 3;

            virusName = VirusNames.Coronavirus;
        }

        public override float GetProductivity(int maxProductivity) {
            float min = limitCitizenPercent * maxProductivity;
            float c = (4 * maxProductivity * virusStrength) / (BaseDuration * BaseDuration);
            float productivity = c * MathF.Pow(elapsedTime - (BaseDuration / 2), 2);
            productivity += min;

            return productivity;
        }

        public override void OnVirusDurationEnd() {
            Random random = new Random();
            float rand = (float)random.NextDouble();
            if(rand <= CovidStats.MORTALITY_RATE) {
                citizenManager.ToRemoveCitizens.Push(citizen);
            } else {
                citizen.virusController.virusesImmune.Add(VirusNames.Coronavirus);
                Recovered = true;
            }
        }

    }
}
