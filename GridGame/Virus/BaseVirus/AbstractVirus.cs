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

        public float infectChance;
        public float mortalityRate;
        public float limitCitizenPercent;

        private float elapsedTime = 0f;

        public void Update(GameTime gameTime) {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(elapsedTime >= CovidStats.TIME_TO_SPREAD) {
                elapsedTime -= CovidStats.TIME_TO_SPREAD;

                UpdateEvent(gameTime);
            }
        }

        public abstract void UpdateEvent(GameTime gameTime);

    }
}
