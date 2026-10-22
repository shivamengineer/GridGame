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
    public class UserInterfaceConstantsManager : AbstractConstantsManager {

        private Dictionary<ConstUserInterface, int> DefaultUserInterfaceValues;
        private Dictionary<ConstUserInterface, int> UserInterfaceValues;

        public UserInterfaceConstantsManager(string filename) {
            DefaultUserInterfaceValues = ConstantsDictionaryLoader.GetDefaultUserInterfaceValues();
            UserInterfaceValues = new Dictionary<ConstUserInterface, int>();
            ReadConstantsFromFile(filename);
            FillUndeclaredConstants();
        }

        public override void ResetConstants() {
            UserInterfaceValues = ConstantsDictionaryLoader.GetDefaultUserInterfaceValues();
        }

        public override void Read(string variable, string value) {
            if(Enum.TryParse<ConstUserInterface>(variable, out ConstUserInterface input)) {
                if(UserInterfaceValues.ContainsKey(input)) {
                    if(int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int result)) {
                        UserInterfaceValues[input] = result;
                    }
                }
            }
        }

        private void FillUndeclaredConstants() {
            if(UserInterfaceValues.Count >= DefaultUserInterfaceValues.Count) return;

            HashSet<ConstUserInterface> TypesToAdd = new HashSet<ConstUserInterface>();
            foreach(ConstUserInterface type in DefaultUserInterfaceValues.Keys) {
                if(!UserInterfaceValues.ContainsKey(type)) {
                    TypesToAdd.Add(type);
                }
            }
            foreach(ConstUserInterface type in TypesToAdd) {
                UserInterfaceValues.Add(type, DefaultUserInterfaceValues[type]);
            }
        }

        public override void WriteConstantsToFile(string filename) {
            string file = filename + "ConstantUserInterface.txt";
            string[] UIConstants = printLines();

            File.WriteAllLines(file, UIConstants);
        }

        private string[] printLines() {
            string[] lines = new string[UserInterfaceValues.Count];

            int i = 0;
            foreach(var UIValue in UserInterfaceValues) {
                lines[i] = UIValue.Key.ToString() + "=" + UIValue.Value.ToString();
                i++;
            }

            return lines;
        }

        public override bool TrySetColor(ConstColors Color, string input) { return false; }
        public override bool TrySetGameInt(ConstGameInt gameInt, string input) { return false; }
        public override bool TrySetGameFloat(ConstGameFloat gameFloat, string input) { return false; }
        public override bool TrySetUIInt(ConstUserInterface UIInt, string input) {
            if(UserInterfaceValues.ContainsKey(UIInt)) {
                if(int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out int result)) {
                    UserInterfaceValues[UIInt] = result;
                    return true;
                }
            }
            return false; 
        }

        public override Dictionary<ConstColors, Color> GetColors() { return null; }
        public override Dictionary<ConstGameInt, int> GetGameInts() { return null; }
        public override Dictionary<ConstGameFloat, float> GetGameFloats() { return null; }
        public override Dictionary<ConstUserInterface, int> GetUIInts() { return UserInterfaceValues; }

    }
}
