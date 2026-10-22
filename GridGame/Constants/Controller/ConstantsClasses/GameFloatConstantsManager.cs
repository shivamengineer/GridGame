using GridGame.Constants.Controller.ConstantsEnums;
using Microsoft.Xna.Framework;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Controller.ConstantsClasses {
    public class GameFloatConstantsManager : AbstractConstantsManager {

        private Dictionary<ConstGameFloat, float> DefaultGameFloats;

        private Dictionary<ConstGameFloat, float> GameFloats;

        private bool ReadingInt = true;

        public GameFloatConstantsManager(string filename) {
            DefaultGameFloats = ConstantsDictionaryLoader.GetDefaultGameFloats();

            GameFloats = new Dictionary<ConstGameFloat, float>();

            ReadConstantsFromFile(filename + "ConstantGameFloats.txt");
            FillUndeclaredFloats();
        }

        public override void ResetConstants() {
            GameFloats = ConstantsDictionaryLoader.GetDefaultGameFloats();
        }

        public override void Read(string variable, string value) {
            if(Enum.TryParse<ConstGameFloat>(variable, out ConstGameFloat input)) {
                if(GameFloats.ContainsKey(input)) {
                    if(float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out float result)) {
                        GameFloats[input] = result;
                    }
                }
            }
        }

        private void FillUndeclaredFloats() {
            if(GameFloats.Count >= DefaultGameFloats.Count) return;

            HashSet<ConstGameFloat> TypesToAdd = new HashSet<ConstGameFloat>();
            foreach(ConstGameFloat type in DefaultGameFloats.Keys) {
                if(!GameFloats.ContainsKey(type)) {
                    TypesToAdd.Add(type);
                }
            }
            foreach(ConstGameFloat type in TypesToAdd) {
                GameFloats.Add(type, DefaultGameFloats[type]);
            }
        }

        public override void WriteConstantsToFile(string filename) {
            string file = filename + "ConstantGameFloats.txt";
            Debug.WriteLine("WRITING TO " + file);

            string[] GameConstants = printLines();

            File.WriteAllLines(file, GameConstants);
        }

        private string[] printLines() {
            string[] lines = new string[GameFloats.Count];

            int i = 0;
            foreach(var gameConst in GameFloats) {
                lines[i] = gameConst.Key.ToString() + "=" + gameConst.Value.ToString();
                i++;
            }

            return lines;
        }

        public override bool TrySetColor(ConstColors Color, string input) { return false; }
        public override bool TrySetGameInt(ConstGameInt gameInt, string input) { return false; }
        public override bool TrySetGameFloat(ConstGameFloat gameFloat, string input) {
            if(GameFloats.ContainsKey(gameFloat)) {
                if(float.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out float result)) {
                    GameFloats[gameFloat] = result;
                    return true;
                }
            }
            return false; 
        }
        public override bool TrySetUIInt(ConstUserInterface UIInt, string input) { return false; }

        public override Dictionary<ConstColors, Color> GetColors() { return null; }
        public override Dictionary<ConstGameInt, int> GetGameInts() { return null; }
        public override Dictionary<ConstGameFloat, float> GetGameFloats() { return GameFloats; }
        public override Dictionary<ConstUserInterface, int> GetUIInts() { return null; }


    }
}
