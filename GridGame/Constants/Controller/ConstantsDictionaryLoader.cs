using GridGame.Constants.Colors;
using GridGame.Constants.Controller.ConstantsClasses;
using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.Tiles.Buildings.BuildingClasses;
using GridGame.Tiles.Terrain.TerrainClasses;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Controller {
    public static class ConstantsDictionaryLoader {

        public static Dictionary<ConstantTypes, string> GetFilenames() {
            return new Dictionary<ConstantTypes, string>() {
                [ConstantTypes.COLOR] = "ConstantColor.txt",
                [ConstantTypes.GAME] = "ConstantGame.txt",
                [ConstantTypes.USER_INTERFACE] = "ConstantUserInterface.txt",
            };
        }

        public static Dictionary<ConstantTypes, IConstantsManager> GetConstantsManagers() {
            return new Dictionary<ConstantTypes, IConstantsManager>() {
                [ConstantTypes.COLOR] = new ColorConstantsManager(),
                [ConstantTypes.GAME] = new GameConstantsManager(),
                [ConstantTypes.USER_INTERFACE] = new UserInterfaceConstantsManager()
            };
        }

        public static Dictionary<ConstColors, Color> GetDefaultColorConstants() {
            return new Dictionary<ConstColors, Color>() {
                [ConstColors.Bank] = BuildingColors.BankColor,
                [ConstColors.CityCenter] = BuildingColors.CityCenterColor,
                [ConstColors.Tile_Empty] = BuildingColors.EmptyColor,
                [ConstColors.Factory] = BuildingColors.FactoryColor,
                [ConstColors.Farm] = BuildingColors.FarmColor,
                [ConstColors.Hospital] = BuildingColors.HospitalColor,
                [ConstColors.Laboratory] = BuildingColors.LaboratoryColor,
                [ConstColors.Tile_NIL] = BuildingColors.NILColor,

                [ConstColors.Citizen_Active] = CitizenColors.ActiveColor,
                [ConstColors.Citizen_Inactive] = CitizenColors.InactiveColor,
                [ConstColors.Citizen_Infected] = CitizenColors.InfectColor,

                [ConstColors.Ocean] = TerrainColors.OceanColor,
                [ConstColors.Land] = TerrainColors.LandColor,
                [ConstColors.Coast] = TerrainColors.CoastColor,
                [ConstColors.LandRiver] = TerrainColors.Land_RiverColor,
                [ConstColors.Unknown] = TerrainColors.UnknownColor,
                [ConstColors.UnknownBorder] = TerrainColors.UnknownBorderColor,

                [ConstColors.OceanHover] = TerrainColors.OceanHoverColor,
                [ConstColors.LandHover] = TerrainColors.LandHoverColor,
                [ConstColors.CoastHover] = TerrainColors.CoastHoverColor,
                [ConstColors.LandRiverHover] = TerrainColors.Land_RiverHoverColor,
                [ConstColors.DefaultHover] = TerrainColors.DefaultHoverColor,

                [ConstColors.CanBuild] = TerrainColors.CanBuildColor,
                [ConstColors.CannotBuild] = TerrainColors.CannotBuildColor,
            };
        }

        public static Dictionary<ConstGame, int> GetDefaultGameInts() {
            return new Dictionary<ConstGame, int>() {
                //NEED TO ADD DEFAULT GAME INT CONSTANTS
            };
        }

        public static Dictionary<ConstGame, float> GetDefaultGameFloats() {
            return new Dictionary<ConstGame, float>() {
                //NEED TO ADD DEFAULT GAME FLOAT CONSTANTS
            };
        }

        public static Dictionary<ConstUserInterface, int> GetDefaultUserInterfaceValues() {
            return new Dictionary<ConstUserInterface, int>() {
                //NEED TO ADD DEFAULT USER INTERFACE CONSTANTS
            };
        }

    }
}
