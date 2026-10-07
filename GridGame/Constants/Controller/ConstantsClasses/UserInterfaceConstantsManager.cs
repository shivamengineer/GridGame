using GridGame.Constants.Controller.ConstantsEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Controller.ConstantsClasses {
    public class UserInterfaceConstantsManager : AbstractConstantsManager {

        private Dictionary<ConstUserInterface, int> UserInterfaceValues;

        public UserInterfaceConstantsManager() {
            UserInterfaceValues = new Dictionary<ConstUserInterface, int>();
        }

        public override void ResetConstants() {
            //
        }

        public override void Read(string variable, string value) {
            //
        }

        public override void Write(string filename) {
            //
        }

    }
}
