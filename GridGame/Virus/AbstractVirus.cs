using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus {
    public abstract class AbstractVirus : IVirus {

        public InfectType infectType;

        public float infectChance;
        public float mortalityRate;
        public float limitCitizenPercent;



    }
}
