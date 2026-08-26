using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.BaseVirus.VirusComponents.AttackCitizenComponents {
    public abstract class AbstractAttackCitizen : IAttackCitizen {

        public float elapsedTime = 0f;

        public bool Asymptomatic;
        public bool Recovered = true;

        public abstract bool IsAsymptomatic();

        public abstract bool IsRecovered();

        public abstract float GetProductivity();

        public void Update(GameTime gameTime) {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

        }

    }
}
