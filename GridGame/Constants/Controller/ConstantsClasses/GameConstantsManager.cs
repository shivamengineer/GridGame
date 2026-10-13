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

        private Dictionary<ConstGame, int> DefaultGameInts;
        private Dictionary<ConstGame, float> DefaultGameFloats;

        private Dictionary<ConstGame, int> GameInts;
        private Dictionary<ConstGame, float> GameFloats;

        public GameConstantsManager(string filename) {
            DefaultGameInts = ConstantsDictionaryLoader.GetDefaultGameInts();
            DefaultGameFloats = ConstantsDictionaryLoader.GetDefaultGameFloats();

            GameInts = new Dictionary<ConstGame, int>();
            GameFloats = new Dictionary<ConstGame, float>();

            ReadConstantsFromFile(filename);
            FillUndeclaredInts();
            FillUndeclaredFloats();
        }

        public override void ResetConstants() {
            GameInts = ConstantsDictionaryLoader.GetDefaultGameInts();
            GameFloats = ConstantsDictionaryLoader.GetDefaultGameFloats();
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

        private void FillUndeclaredInts() {
            if(GameInts.Count >= DefaultGameInts.Count) return;

            HashSet<ConstGame> TypesToAdd = new HashSet<ConstGame>();
            foreach(ConstGame type in DefaultGameInts.Keys) {
                if(!GameInts.ContainsKey(type)) {
                    TypesToAdd.Add(type);
                }
            }
            foreach(ConstGame type in TypesToAdd) {
                GameInts.Add(type, DefaultGameInts[type]);
            }
        }

        private void FillUndeclaredFloats() {
            if(GameFloats.Count >= DefaultGameFloats.Count) return;

            HashSet<ConstGame> TypesToAdd = new HashSet<ConstGame>();
            foreach(ConstGame type in DefaultGameFloats.Keys) {
                if(!GameFloats.ContainsKey(type)) {
                    TypesToAdd.Add(type);
                }
            }
            foreach(ConstGame type in TypesToAdd) {
                GameFloats.Add(type, DefaultGameFloats[type]);
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
