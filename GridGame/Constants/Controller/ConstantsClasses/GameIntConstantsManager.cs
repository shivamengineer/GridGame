using GridGame.Constants.Controller.ConstantsEnums;
using Microsoft.Xna.Framework;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Controller.ConstantsClasses {
    public class GameIntConstantsManager : AbstractConstantsManager {

        private Dictionary<ConstGameInt, int> DefaultGameInts;

        private Dictionary<ConstGameInt, int> GameInts;

        private bool ReadingInt = true;

        public GameIntConstantsManager(string filename) {
            DefaultGameInts = ConstantsDictionaryLoader.GetDefaultGameInts();

            GameInts = new Dictionary<ConstGameInt, int>();

            ReadConstantsFromFile(filename);
            FillUndeclaredInts();
        }

        public override void ResetConstants() {
            GameInts = ConstantsDictionaryLoader.GetDefaultGameInts();
        }

        public override void Read(string variable, string value) {
            if(Enum.TryParse<ConstGameInt>(variable, out ConstGameInt input)) {
                if(GameInts.ContainsKey(input)) {
                    if(int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int result)) {
                        GameInts[input] = result;
                    }
                }
            }
        }

        private void FillUndeclaredInts() {
            if(GameInts.Count >= DefaultGameInts.Count) return;

            HashSet<ConstGameInt> TypesToAdd = new HashSet<ConstGameInt>();
            foreach(ConstGameInt type in DefaultGameInts.Keys) {
                if(!GameInts.ContainsKey(type)) {
                    TypesToAdd.Add(type);
                }
            }
            foreach(ConstGameInt type in TypesToAdd) {
                GameInts.Add(type, DefaultGameInts[type]);
            }
        }

        public override void WriteConstantsToFile(string filename) {
            string file = filename + "ConstantGameInt.txt";
            string[] GameConstants = printLines();

            File.WriteAllLines(file, GameConstants);
        }

        private string[] printLines() {
            string[] lines = new string[GameInts.Count];

            int i = 0;
            foreach(var gameConst in GameInts) {
                lines[i] = gameConst.Key.ToString() + "=" + gameConst.Value.ToString();
                i++;
            }

            return lines;
        }

        public override bool TrySetColor(ConstColors Color, string input) { return false; }
        public override bool TrySetGameInt(ConstGameInt gameInt, string input) {
            if(GameInts.ContainsKey(gameInt)) {
                if(int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out int result)) {
                    GameInts[gameInt] = result;
                    return true;
                }
            }
            return false;
        }
        public override bool TrySetGameFloat(ConstGameFloat gameFloat, string input) { return false; }
        public override bool TrySetUIInt(ConstUserInterface UIInt, string input) { return false; }

        public override Dictionary<ConstColors, Color> GetColors() { return null; }
        public override Dictionary<ConstGameInt, int> GetGameInts() { return GameInts; }
        public override Dictionary<ConstGameFloat, float> GetGameFloats() { return null; }
        public override Dictionary<ConstUserInterface, int> GetUIInts() { return null; }

    }
}
