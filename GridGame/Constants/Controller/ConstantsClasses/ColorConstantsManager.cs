using GridGame.Constants.Controller.ConstantsEnums;
using Microsoft.Xna.Framework;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Controller.ConstantsClasses {
    public class ColorConstantsManager : AbstractConstantsManager {

        private Dictionary<ConstColors, Color> DefaultColors;
        private Dictionary<ConstColors, Color> Colors;

        private Dictionary<ConstColors, string> DefaultColorStrings;
        private Dictionary<ConstColors, string> ColorStrings;

        public ColorConstantsManager(string filename) {
            DefaultColors = ConstantsDictionaryLoader.GetDefaultColorConstants();
            Colors = new Dictionary<ConstColors, Color>();
            DefaultColorStrings = ConstantsDictionaryLoader.GetDefaultColorConstantsStrings();
            ColorStrings = new Dictionary<ConstColors, string>();
            ReadConstantsFromFile(filename + "ConstantColor.txt");
            FillUndeclaredConstants();
        }

        public override void ResetConstants() {
            Colors = ConstantsDictionaryLoader.GetDefaultColorConstants();
            ColorStrings = ConstantsDictionaryLoader.GetDefaultColorConstantsStrings();
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

                ColorStrings[colorVariable] = value;
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
                ColorStrings.Add(type, DefaultColorStrings[type]);
            }
        }

        public override void WriteConstantsToFile(string filename) {
            string file = "Content/Data/Constants/" + filename + "ConstantColor.txt";
            string[] ColorConstants = printLines();

            File.WriteAllLines(file, ColorConstants);
        }

        private string[] printLines() {
            string[] lines = new string[Colors.Count];

            int i = 0;
            foreach(var color in ColorStrings) {
                lines[i] = color.Key.ToString() + "=" + color.Value;
                i++;
            }

            return lines;
        }

        public override bool TrySetColor(ConstColors Color, string input) {
            PropertyInfo property = typeof(Color).GetProperty(input, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase);

            Color inputColor;
            if(property != null) {
                inputColor = (Color)property.GetValue(null, null);
            } else {  
                return false;
            }

            Colors[Color] = inputColor;
            ColorStrings[Color] = input;
            return true;
        }
        public override bool TrySetGameInt(ConstGameInt gameInt, string input) { return false; }
        public override bool TrySetGameFloat(ConstGameFloat gameFloat, string input) { return false; }
        public override bool TrySetUIInt(ConstUserInterface UIInt, string input) { return false; }

        public override Dictionary<ConstColors, string> GetColorStrings() { return ColorStrings; }
        public override Dictionary<ConstColors, Color> GetColors() { return Colors; }
        public override Dictionary<ConstGameInt, int> GetGameInts() { return null; }
        public override Dictionary<ConstGameFloat, float> GetGameFloats() { return null; }
        public override Dictionary<ConstUserInterface, int> GetUIInts() { return null; }

    }
}
