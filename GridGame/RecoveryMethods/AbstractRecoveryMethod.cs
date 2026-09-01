using GridGame.HealthEffects;
using GridGame.Recovery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.RecoveryMethods {
    public abstract class AbstractRecoveryMethod : IRecoveryMethod {

        public List<IHealthEffect> IntendedHealthEffects;
        public List<IHealthEffect> SideEffects;

        public abstract bool CanPerformOtherActions();

    }
}
