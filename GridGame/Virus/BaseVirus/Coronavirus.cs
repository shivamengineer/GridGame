using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.BaseVirus {
    public class Coronavirus : AbstractVirus {

        private float strength;

        public Coronavirus(float strength) {
            this.strength = strength;
        }

    }
}
