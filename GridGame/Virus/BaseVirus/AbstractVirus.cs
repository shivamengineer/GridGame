using GridGame.Constants.Viruses.Covid;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.BaseVirus {
    public abstract class AbstractVirus : IVirus {

        public InfectType infectType;

        public int ID;

        public float infectChance;
        public float mortalityRate;
        public float limitCitizenPercent = 0f;

        public float TimeToSpread;
        public float BaseDuration;
        public float AsymptomaticTime;

        private float elapsedTime = 0f;
        private float virusTime = 0f;

        private bool asymptomatic = true;

        public float CitizenStrength() {
            return limitCitizenPercent;
        }

        public bool IsAsymptomatic() {
            return asymptomatic;
        }

        public void Update(GameTime gameTime) {
            UpdateTime(gameTime);

            TryUpdateEvent();
            TryShowSymptoms();

            if(virusTime >= BaseDuration) {
                //Virus dies or becomes inactive
            }
        }

        public abstract void UpdateEvent();

        private void UpdateTime(GameTime gameTime) {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            virusTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        private void TryUpdateEvent() {
            if(elapsedTime >= TimeToSpread) {
                elapsedTime -= TimeToSpread;
                UpdateEvent();
            }
        }

        private void TryShowSymptoms() {
            if(asymptomatic && virusTime >= AsymptomaticTime) {
                asymptomatic = false;
            }
        }

    }
}
