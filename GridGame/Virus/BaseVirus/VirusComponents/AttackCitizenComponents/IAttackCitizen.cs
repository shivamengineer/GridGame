using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.BaseVirus.VirusComponents.AttackCitizenComponents {
    public interface IAttackCitizen {

        public bool IsAsymptomatic();

        public bool IsRecovered();

        public float GetProductivity();

        public void Update(GameTime gameTime);

    }
}
