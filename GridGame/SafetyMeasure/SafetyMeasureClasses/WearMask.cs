using GridGame.HealthEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.SafetyMeasure.SafetyMeasureClasses {
    public class WearMask : AbstractSafetyMeasure {

        private MaskType Mask;

        public WearMask(MaskType Mask) {
            this.Mask = Mask;

            SafetyMeasure = SafetyMeasureType.WEAR_MASK;
            IntendedHealthEffects = new List<IHealthEffect>() {
                //ADD INTENDED HEALTH EFFECTS
            };
            SideEffects = new List<IHealthEffect>() {
                //ADD SIDE EFFECTS
            };
        }

    }
}
