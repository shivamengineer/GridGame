using GridGame.Constants.Colors;
using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Units.UnitComponents {
    public struct UnitColor {

        public Color Inactive;
        public Color Active;
        public Color Infected;
        public Color Asymptomatic;

        public UnitColor(ConstantsController Constants) {
            Dictionary<ConstColors, Color> Colors = Constants.GetColors();
            Inactive = Colors[ConstColors.Citizen_Inactive];
            Active = Colors[ConstColors.Citizen_Active];
            Infected = Colors[ConstColors.Citizen_Infected];
            Asymptomatic = Colors[ConstColors.Citizen_Asymptomatic];
        }

    }
}
