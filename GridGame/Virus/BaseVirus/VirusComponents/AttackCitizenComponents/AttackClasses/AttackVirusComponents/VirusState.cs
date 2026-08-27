using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.BaseVirus.VirusComponents.AttackCitizenComponents.AttackClasses.AttackVirusComponents {
    public struct VirusState {
        public bool Asymptomatic;
        public bool Recovered;

        public VirusState() {
            Asymptomatic = true;
            Recovered = false;
        }
    }
}
