using GridGame.Units.UnitClasses;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.BaseVirus {
    public interface IVirus {

        public float CitizenStrength();

        public float GetCitizenProductivity(int maxProductivity);

        public bool IsAsymptomatic();

        public bool IsRecovered();

        public void Update(GameTime gameTime);

        public void UpdateEvent();

        public void OnVirusDurationEnd();

        public IVirus NewInstance(Citizen citizen);

    }
}
