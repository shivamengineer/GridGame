using GridGame.Constants.Viruses.Covid;
using GridGame.Units.UnitClasses;
using GridGame.Virus.BaseVirus.VirusComponents.AttackCitizenComponents;
using GridGame.Virus.BaseVirus.VirusComponents.InfectComponents;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.BaseVirus {
    public abstract class AbstractVirus : IVirus {

        public InfectType infectType;

        public IInfect Infect { get; set; }
        public IAttackCitizen AttackCitizen { get; set; }

        public float infectChance;
        public float mortalityRate;
        public float virusStrength;
        public float limitCitizenPercent = 0f;

        public float TimeToSpread;
        public float BaseDuration;
        public float AsymptomaticTime;

        private float virusTime = 0f;

        private bool asymptomatic = true;
        public bool recovered = false;

        public void Update(GameTime gameTime) {
            Infect.Update(gameTime);
            AttackCitizen.Update(gameTime);
        }

        public abstract IVirus NewInstance(Citizen citizen);

    }
}
