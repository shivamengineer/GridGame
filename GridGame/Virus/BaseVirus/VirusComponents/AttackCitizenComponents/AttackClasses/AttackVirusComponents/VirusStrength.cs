using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.BaseVirus.VirusComponents.AttackCitizenComponents.AttackClasses.AttackVirusComponents {
    public struct VirusStrength {
        public float mortalityRate;
        public float virusStrength;
        public float limitCitizenPercent;

        public VirusStrength(float mortalityRate, float virusStrength) {
            this.mortalityRate = mortalityRate;
            this.virusStrength = virusStrength;
            limitCitizenPercent = 1f - virusStrength;
        }
    }
}
