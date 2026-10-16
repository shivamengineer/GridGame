using GridGame.Constants.Controller.ConstantsClasses;
using GridGame.Constants.Controller.ConstantsEnums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Controller {
    public class ConstantsController {

        private Dictionary<ConstantTypes, string> Filenames;
        private Dictionary<ConstantTypes, IConstantsManager> ConstantsFiles;

        public ConstantsController() {
            Filenames = ConstantsDictionaryLoader.GetFilenames();
            ConstantsFiles = ConstantsDictionaryLoader.GetConstantsManagers(Filenames);
            Initialize();
        }

        private void Initialize() {
            foreach(var file in Filenames) {
                ConstantsFiles[file.Key].ReadConstantsFromFile(file.Value);
            }

        }

        public void Save(string filename) {
            foreach(var file in ConstantsFiles) {
                ConstantsFiles[file.Key].WriteConstantsToFile(filename);
            }
        }

        public Dictionary<ConstColors, Color> GetColors() {
            return ConstantsFiles[ConstantTypes.COLOR].GetColors();
        }

        public Dictionary<ConstGame, int> GetGameInts() {
            return ConstantsFiles[ConstantTypes.GAME].GetGameInts();
        }

        public Dictionary<ConstGame, float> GetGameFloats() {
            return ConstantsFiles[ConstantTypes.GAME].GetGameFloats();
        }

        public Dictionary<ConstUserInterface, int> GetUIInts() {
            return ConstantsFiles[ConstantTypes.USER_INTERFACE].GetUIInts();
        }

    }
}
