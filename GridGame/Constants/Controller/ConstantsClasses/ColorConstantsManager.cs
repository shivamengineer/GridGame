using GridGame.Constants.Controller.ConstantsEnums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Controller.ConstantsClasses {
    public class ColorConstantsManager : AbstractConstantsManager {

        private Dictionary<ConstColors, Color> DefaultColors;
        private Dictionary<ConstColors, Color> Colors;

        public ColorConstantsManager(string filename) {
            DefaultColors = ConstantsDictionaryLoader.GetDefaultColorConstants();
            Colors = new Dictionary<ConstColors, Color>();
            ReadConstantsFromFile(filename);
            FillUndeclaredConstants();
        }

        public override void ResetConstants() {
            Colors = ConstantsDictionaryLoader.GetDefaultColorConstants();
        }

        public override void Read(string variable, string value) {
            if(Enum.TryParse<ConstColors>(variable, out ConstColors colorVariable)) {
                PropertyInfo property = typeof(Color).GetProperty(value, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase);

                Color inputColor;
                if(property != null) {
                    inputColor = (Color)property.GetValue(null, null);
                } else {
                    inputColor = DefaultColors[colorVariable];
                }

                Colors[colorVariable] = inputColor;
            }
        }

        private void FillUndeclaredConstants() {
            if(Colors.Count >= DefaultColors.Count) return;

            HashSet<ConstColors> TypesToAdd = new HashSet<ConstColors>();
            foreach(ConstColors type in DefaultColors.Keys) {
                if(!Colors.ContainsKey(type)) {
                    TypesToAdd.Add(type);
                }
            }
            foreach(ConstColors type in TypesToAdd) {
                Colors.Add(type, DefaultColors[type]);
            }
        }

        public override void WriteConstantsToFile(string filename) {
            string file = filename + "ConstantColor.txt";
            string[] ColorConstants = printLines();

            File.WriteAllLines(file, ColorConstants);
        }

        private string[] printLines() {
            string[] lines = new string[Colors.Count];

            int i = 0;
            foreach(var color in Colors) {
                lines[i] = color.Key.ToString() + "=" + color.Value.ToString();
                i++;
            }

            return lines;
        }

        public override Dictionary<ConstColors, Color> GetColors() { return Colors; }
        public override Dictionary<ConstGame, int> GetGameInts() { return null; }
        public override Dictionary<ConstGame, float> GetGameFloats() { return null; }
        public override Dictionary<ConstUserInterface, int> GetUIInts() { return null; }

    }
}
