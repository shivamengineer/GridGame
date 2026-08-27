using GridGame.Virus.BaseVirus.VirusComponents.AttackCitizenComponents.AttackClasses.AttackVirusComponents;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.BaseVirus.VirusComponents.AttackCitizenComponents {
    public interface IAttackCitizen {

        public void SetStats(VirusStrength Strength, VirusTime Time);

        public bool IsAsymptomatic();

        public bool IsRecovered();

        public void OnVirusDurationEnd();

        public float GetProductivity(int maxProductivity);

        public void Update(GameTime gameTime);

    }
}
