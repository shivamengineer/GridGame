using GridGame.Constants.Controller.ConstantsEnums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            if(Enum.TryParse<ConstUserInterface>(variable, out ConstUserInterface input)) {
                if(UserInterfaceValues.ContainsKey(input)) {
                    if(int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int result)) {
                        UserInterfaceValues[input] = result;
                    }
                }
            }
        }

        public override void Write(string filename) {
            //
        }

        public override Dictionary<ConstColors, Color> GetColors() { return null; }
        public override Dictionary<ConstGame, int> GetGameInts() { return null; }
        public override Dictionary<ConstGame, float> GetGameFloats() { return null; }
        public override Dictionary<ConstUserInterface, int> GetUIInts() { return UserInterfaceValues; }

    }
}
