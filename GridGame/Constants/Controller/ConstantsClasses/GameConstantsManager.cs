using GridGame.Constants.Controller.ConstantsEnums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            if(Enum.TryParse<ConstGame>(variable, out ConstGame input)) {
                if(GameInts.ContainsKey(input)) {
                    if(int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int result)) {
                        GameInts[input] = result;
                    }
                } else if(GameFloats.ContainsKey(input)) {
                    if(float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out float result)) {
                        GameFloats[input] = result;
                    }
                }
            }
        }

        public override void Write(string filename) {
            //
        }

        public override Dictionary<ConstColors, Color> GetColors() { return null; }
        public override Dictionary<ConstGame, int> GetGameInts() { return GameInts; }
        public override Dictionary<ConstGame, float> GetGameFloats() { return GameFloats; }
        public override Dictionary<ConstUserInterface, int> GetUIInts() { return null; }

    }
}
