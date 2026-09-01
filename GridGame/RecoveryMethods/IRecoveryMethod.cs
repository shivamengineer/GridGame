using GridGame.RecoveryMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Recovery {
    public interface IRecoveryMethod {

        public RecoveryMethod GetRecoveryMethod();

        public bool CanPerformOtherActions();

    }
}
