using GridGame.Constants.Viruses.Covid;
using GridGame.Hexagons;
using GridGame.Hexagons.Managers;
using GridGame.Units.UnitClasses;
using GridGame.Virus.BaseVirus.VirusComponents.AttackCitizenComponents.AttackClasses.AttackVirusComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.BaseVirus.VirusComponents.AttackCitizenComponents.AttackClasses {
    public class DefaultAttackCitizen : AbstractAttackCitizen {

        private CitizenManager citizenManager;
        private Citizen citizen;

        public DefaultAttackCitizen(CitizenManager citizenManager, Citizen citizen, float strength) {
            this.citizenManager = citizenManager;
            this.citizen = citizen;

            Strength.virusStrength = strength;
            Strength.limitCitizenPercent = 1f - strength;

            Time.Duration = CovidStats.VIRUS_BASE_DURATION;
            Time.AsymptomaticTime = Time.Duration / 3;

            State = new VirusState();
        }

        public override float GetProductivity(int maxProductivity) {
            float min = Strength.limitCitizenPercent * maxProductivity;
            float c = (4 * maxProductivity * Strength.virusStrength) / (Time.Duration * Time.Duration);
            float productivity = c * MathF.Pow(elapsedTime - (Time.Duration / 2), 2);
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
                State.Recovered = true;
            }
        }

    }
}
