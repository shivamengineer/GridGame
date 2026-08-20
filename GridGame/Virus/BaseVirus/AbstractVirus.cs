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

        private float elapsedTime = 0f;
        private float virusTime = 0f;

        public float CitizenStrength() {
            return limitCitizenPercent;
        }

        public void Update(GameTime gameTime) {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            virusTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(elapsedTime >= TimeToSpread) {
                elapsedTime -= TimeToSpread;

                UpdateEvent(gameTime);
            }

            if(virusTime >= BaseDuration) {

            }
        }

        public abstract void UpdateEvent(GameTime gameTime);

    }
}
