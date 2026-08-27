using GridGame.Units.UnitClasses;
using GridGame.Virus.BaseVirus.VirusComponents.AttackCitizenComponents;
using GridGame.Virus.BaseVirus.VirusComponents.InfectComponents;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.BaseVirus {
    public interface IVirus {

        public IInfect Infect { get; set; }
        public IAttackCitizen AttackCitizen { get; set; }

        public void Update(GameTime gameTime);

        public IVirus NewInstance(Citizen citizen);

    }
}
