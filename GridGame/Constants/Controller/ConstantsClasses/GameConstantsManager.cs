using GridGame.Constants.Controller.ConstantsEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Controller.ConstantsClasses {
    public class GameConstantsManager : AbstractConstantsManager {

        private Dictionary<ConstGame, int> GameInts;
        private Dictionary<ConstGame, float> GameFloats;

        public GameConstantsManager() {
            GameInts = new Dictionary<ConstGame, int>();
            GameFloats = new Dictionary<ConstGame, float>();
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
