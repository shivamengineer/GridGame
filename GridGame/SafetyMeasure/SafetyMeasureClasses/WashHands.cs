using GridGame.HealthEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.SafetyMeasure.SafetyMeasureClasses {
    public class WashHands : AbstractSafetyMeasure {

        public WashHands() {
            SafetyMeasure = SafetyMeasureType.WASH_HANDS;
            IntendedHealthEffects = new List<IHealthEffect>() {
                //ADD INTENDED HEALTH EFFECTS
            };
            SideEffects = new List<IHealthEffect>() {
                //ADD SIDE EFFECTS
            };
        }

    }
}
