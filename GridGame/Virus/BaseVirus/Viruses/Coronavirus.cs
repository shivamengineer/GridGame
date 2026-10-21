using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.Constants.Viruses.Covid;
using GridGame.Hexagons;
using GridGame.Hexagons.Managers;
using GridGame.Hexagons.StaticClasses;
using GridGame.Units.UnitClasses;
using GridGame.Virus.BaseVirus.VirusComponents.AttackCitizenComponents.AttackClasses;
using GridGame.Virus.BaseVirus.VirusComponents.AttackCitizenComponents.AttackClasses.AttackVirusComponents;
using GridGame.Virus.BaseVirus.VirusComponents.InfectComponents;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.BaseVirus.Viruses {
    public class Coronavirus : AbstractVirus {

        private Citizen citizen;
        private CitizenManager citizenManager;

        private VirusNames virusName;

        private ConstantsController Constants;
        private Dictionary<ConstGameInt, int> GameInts;
        private Dictionary<ConstGameFloat, float> GameFloats;

        public Coronavirus(CitizenManager citizenManager, Citizen citizen, float strength, ConstantsController Constants) {
            this.citizen = citizen;
            this.citizenManager = citizenManager;
            this.Constants = Constants;

            GameInts = Constants.GetGameInts();
            GameFloats = Constants.GetGameFloats();

            virusStrength = strength;
            virusName = VirusNames.Coronavirus;

            Infect = new AirborneInfect(citizenManager, citizen, this, Constants);
            AttackCitizen = new DefaultAttackCitizen(citizenManager, citizen, strength);

            VirusStrength attackStrength = new VirusStrength(GameFloats[ConstGameFloat.VirusMortalityRate], strength);
            VirusTime attackTime = new VirusTime(GameFloats[ConstGameFloat.VirusTimeBeforeSpread], GameFloats[ConstGameFloat.VirusBaseDuration]);
            AttackCitizen.SetStats(attackStrength, attackTime);
        }

        public override IVirus NewInstance(Citizen citizen) {
            return new Coronavirus(citizenManager, citizen, virusStrength, Constants);
        }

    }
}
