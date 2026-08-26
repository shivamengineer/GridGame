using GridGame.Constants.Viruses.Covid;
using GridGame.Units.UnitClasses;
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

        public int ID;

        public float infectChance;
        public float mortalityRate;
        public float virusStrength;
        public float limitCitizenPercent = 0f;

        public float TimeToSpread;
        public float BaseDuration;
        public float AsymptomaticTime;

        private float elapsedTime = 0f;
        private float virusTime = 0f;

        private bool asymptomatic = true;
        public bool recovered = false;

        public float CitizenStrength() {
            return limitCitizenPercent;
        }

        public float GetCitizenProductivity(int maxProductivity) {
            float min = limitCitizenPercent * maxProductivity;
            float c = (4 * maxProductivity * virusStrength) / (BaseDuration * BaseDuration);
            float productivity = c * MathF.Pow(virusTime - (BaseDuration / 2), 2);
            productivity += min;
                                         
            return productivity;
        }

        public bool IsAsymptomatic() {
            return asymptomatic;
        }

        public bool IsRecovered() {
            return recovered;
        }

        public void Update(GameTime gameTime) {
            UpdateTime(gameTime);

            TryUpdateEvent();
            TryShowSymptoms();

            if(virusTime >= BaseDuration) {
                OnVirusDurationEnd();
            }
        }

        public abstract void UpdateEvent();

        public abstract void OnVirusDurationEnd();

        public abstract IVirus NewInstance(Citizen citizen);

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
