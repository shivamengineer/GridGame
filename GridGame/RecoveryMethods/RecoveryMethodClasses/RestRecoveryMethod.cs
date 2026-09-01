using GridGame.HealthEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.RecoveryMethods.RecoveryMethodClasses {
    public class RestRecoveryMethod : AbstractRecoveryMethod {

        public RestRecoveryMethod() {
            IntendedHealthEffects = new List<IHealthEffect>() {
                //ADD HEALTH IMPROVEMENTS
            };
            SideEffects = new List<IHealthEffect>() {
                //ADD SIDE EFFECTS
            };
        }

        public override bool CanPerformOtherActions() {
            return false;
        }

    }
}
