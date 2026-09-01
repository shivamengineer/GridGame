using GridGame.Recovery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Treatment {
    public abstract class AbstractTreatment : ITreatment {

        public List<IRecoveryMethod> recoveryMethods = new List<IRecoveryMethod>();

    }
}
