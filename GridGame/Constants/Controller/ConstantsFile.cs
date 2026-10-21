using GridGame.Constants.Controller.ConstantsEnums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Controller {
    public class ConstantsFile {

        public Dictionary<ConstantTypes, IConstantsManager> ConstantsManagers { get; private set; }

        public ConstantsFile(string filename) {
            ConstantsManagers = ConstantsDictionaryLoader.GetConstantsManagers(filename);
            ReadConstantsFromFile(filename);
        }

        public void ReadConstantsFromFile(string filename) {
            foreach(var ConstantsManager in ConstantsManagers.Values) {
                ConstantsManager.ReadConstantsFromFile(filename);
            }
        }

        public void WriteConstantsToFile(string filename) {
            foreach(var ConstantsManager in ConstantsManagers.Values) {
                ConstantsManager.WriteConstantsToFile(filename);
            }
        }

        public Dictionary<ConstColors, Color> GetColors() {
            return ConstantsManagers[ConstantTypes.COLOR].GetColors();
        }

        public Dictionary<ConstGameInt, int> GetGameInts() {
            return ConstantsManagers[ConstantTypes.GAME_INT].GetGameInts();
        }

        public Dictionary<ConstGameFloat, float> GetGameFloats() {
            return ConstantsManagers[ConstantTypes.GAME_FLOAT].GetGameFloats();
        }

        public Dictionary<ConstUserInterface, int> GetUIInts() {
            return ConstantsManagers[ConstantTypes.USER_INTERFACE].GetUIInts();
        }

    }
}
