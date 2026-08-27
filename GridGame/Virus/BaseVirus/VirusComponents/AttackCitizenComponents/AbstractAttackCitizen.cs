using GridGame.Virus.BaseVirus.VirusComponents.AttackCitizenComponents.AttackClasses.AttackVirusComponents;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.BaseVirus.VirusComponents.AttackCitizenComponents {
    public abstract class AbstractAttackCitizen : IAttackCitizen {

        public float elapsedTime = 0f;

        public VirusStrength Strength;
        public VirusTime Time;
        public VirusState State;

        public bool IsAsymptomatic() { return State.Asymptomatic; }

        public bool IsRecovered() { return State.Recovered; }

        public abstract float GetProductivity(int maxProductivity);

        public abstract void OnVirusDurationEnd();

        public void Update(GameTime gameTime) {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            TryShowSymptoms();

            if(elapsedTime >= Time.Duration) {
                OnVirusDurationEnd();
            }
        }

        private void TryShowSymptoms() {
            if(State.Asymptomatic && elapsedTime >= Time.AsymptomaticTime) {
                State.Asymptomatic = false;
            }
        }

    }
}
