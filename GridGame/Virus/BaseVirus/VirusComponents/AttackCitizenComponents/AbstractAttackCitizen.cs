using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.BaseVirus.VirusComponents.AttackCitizenComponents {
    public abstract class AbstractAttackCitizen : IAttackCitizen {

        public float elapsedTime = 0f;

        public float mortalityRate;
        public float virusStrength;
        public float limitCitizenPercent = 0f;

        public float TimeToSpread;
        public float BaseDuration;
        public float AsymptomaticTime;

        public bool Asymptomatic = true;
        public bool Recovered = false;

        public bool IsAsymptomatic() { return Asymptomatic; }

        public bool IsRecovered() { return Recovered; }

        public abstract float GetProductivity();

        public void Update(GameTime gameTime) {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            TryShowSymptoms();
        }

        private void TryShowSymptoms() {
            if(Asymptomatic && elapsedTime >= AsymptomaticTime) {
                Asymptomatic = false;
            }
        }

    }
}
