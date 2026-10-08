using GridGame.Constants.Controller.ConstantsEnums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Controller.ConstantsClasses {
    public class ColorConstantsManager : AbstractConstantsManager {

        private Dictionary<ConstColors, Color> DefaultColors;
        private Dictionary<ConstColors, Color> Colors;

        public ColorConstantsManager() {
            //
        }

        public override void ResetConstants() {
            //
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

        public override void Write(string filename) {
            //
        }

        public override Dictionary<ConstColors, Color> GetColors() { return Colors; }
        public override Dictionary<ConstGame, int> GetGameInts() { return null; }
        public override Dictionary<ConstGame, float> GetGameFloats() { return null; }
        public override Dictionary<ConstUserInterface, int> GetUIInts() { return null; }

    }
}
