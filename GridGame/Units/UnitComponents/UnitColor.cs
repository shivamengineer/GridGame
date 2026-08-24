using GridGame.Constants.Colors;
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

        public UnitColor() {
            Inactive = CitizenColors.InactiveColor;
            Active = CitizenColors.ActiveColor;
            Infected = CitizenColors.InfectColor;
        }

    }
}
