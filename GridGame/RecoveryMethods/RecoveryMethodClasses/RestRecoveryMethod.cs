using GridGame.Constants.Treatment;
using GridGame.HealthEffects;
using GridGame.HealthEffects.HealthEffectClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.RecoveryMethods.RecoveryMethodClasses {
    public class RestRecoveryMethod : AbstractRecoveryMethod {

        public RestRecoveryMethod() {
            recoveryMethod = RecoveryMethod.REST;
            IntendedHealthEffects = new List<IHealthEffect>() {
                //ADD HEALTH IMPROVEMENTS
            };
            SideEffects = new List<IHealthEffect>() {
                new DrowsyEffect(HealthEffectStats.DROWSY_STRENGTH)
            };
        }

        public override bool CanPerformOtherActions() {
            return false;
        }

    }
}
