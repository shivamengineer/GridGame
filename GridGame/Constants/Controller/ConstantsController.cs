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

        private string currentFile;

        private List<string> Filenames;
        private Dictionary<string, ConstantsFile> ConstantsFiles;

        public ConstantsController() {
            currentFile = "";
            Filenames = ConstantsDictionaryLoader.GetFilenames();
            Initialize();
        }

        private void Initialize() {
            ConstantsFiles = new Dictionary<string, ConstantsFile>();
            foreach(var file in Filenames) {
                ConstantsFiles[file] = new ConstantsFile(file);
            }
        }

        public void SaveCurrentFile() {
            foreach(var file in ConstantsFiles) {
                ConstantsFiles[currentFile].WriteConstantsToFile(currentFile);
            }
        }

        public void Save(string filename) {
            foreach(var file in ConstantsFiles) {
                ConstantsFiles[file.Key].WriteConstantsToFile(filename);
            }
        }

        public bool TrySetColor(ConstColors Color, string input) {
            return ConstantsFiles[currentFile].TrySetColor(Color, input);
        }

        public bool TrySetGameInt(ConstGameInt gameInt, string input) {
            return ConstantsFiles[currentFile].TrySetGameInt(gameInt, input);
        }

        public bool TrySetGameFloat(ConstGameFloat gameFloat, string input) {
            return ConstantsFiles[currentFile].TrySetGameFloat(gameFloat, input);
        }

        public bool TrySetUIInt(ConstUserInterface UIInt, string input) {
            return ConstantsFiles[currentFile].TrySetUIInt(UIInt, input);
        }

        public Dictionary<ConstColors, Color> GetColors() {
            return ConstantsFiles[currentFile].GetColors();
        }

        public Dictionary<ConstGameInt, int> GetGameInts() {
            return ConstantsFiles[currentFile].GetGameInts();
        }

        public Dictionary<ConstGameFloat, float> GetGameFloats() {
            return ConstantsFiles[currentFile].GetGameFloats();
        }

        public Dictionary<ConstUserInterface, int> GetUIInts() {
            return ConstantsFiles[currentFile].GetUIInts();
        }

    }
}
