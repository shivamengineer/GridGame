using GridGame.Constants.Viruses.Covid;
using GridGame.Hexagons;
using GridGame.Hexagons.Managers;
using GridGame.Hexagons.StaticClasses;
using GridGame.Units.UnitClasses;
using GridGame.Virus.BaseVirus.VirusComponents.AttackCitizenComponents.AttackClasses;
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
        private CitizenManager citizenManager;

        private VirusNames virusName;

        public Coronavirus(CitizenManager citizenManager, Citizen citizen, float strength) {
            this.citizen = citizen;
            this.citizenManager = citizenManager;

            virusStrength = strength;
            limitCitizenPercent = 1f - strength;

            BaseDuration = CovidStats.VIRUS_BASE_DURATION;
            AsymptomaticTime = BaseDuration / 3;

            virusName = VirusNames.Coronavirus;
            Infect = new AirborneInfect(citizenManager, citizen, this);
            AttackCitizen = new DefaultAttackCitizen(citizenManager, citizen, strength);
        }

        public override IVirus NewInstance(Citizen citizen) {
            return new Coronavirus(citizenManager, citizen, virusStrength);
        }

    }
}
