using GridGame.Constants.Controller.ConstantsClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Controller {
    public class ConstantsController {

        public Dictionary<ConstantTypes, string> Filenames;
        public Dictionary<ConstantTypes, IConstantsManager> ConstantsFiles;

        public ConstantsController() {
            Filenames = ConstantsDictionaryLoader.GetFilenames();
            ConstantsFiles = ConstantsDictionaryLoader.GetConstantsManagers();
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

    }
}
