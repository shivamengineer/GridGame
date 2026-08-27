using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.BaseVirus.VirusComponents.AttackCitizenComponents.AttackClasses.AttackVirusComponents {
    public struct VirusTime {
        public float TimeToSpread;
        public float Duration;
        public float AsymptomaticTime;

        public VirusTime(float TimeToSpread, float Duration) {
            this.TimeToSpread = TimeToSpread;
            this.Duration = Duration;
            AsymptomaticTime = Duration / 3;
        }
    }
}
