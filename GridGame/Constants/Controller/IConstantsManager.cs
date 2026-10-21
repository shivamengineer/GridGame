using GridGame.Constants.Controller.ConstantsEnums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Controller {
    public interface IConstantsManager {

        public bool ReadConstantsFromFile(string filename);
        public void WriteConstantsToFile(string filename);
        public void ResetConstants();

        public Dictionary<ConstColors, Color> GetColors();
        public Dictionary<ConstGameInt, int> GetGameInts();
        public Dictionary<ConstGameFloat, float> GetGameFloats();
        public Dictionary<ConstUserInterface, int> GetUIInts();

    }
}
