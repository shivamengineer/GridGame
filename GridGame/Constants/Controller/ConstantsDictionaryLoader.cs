using GridGame.Constants.Controller.ConstantsClasses;
using GridGame.Constants.Controller.ConstantsEnums;
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
                //NEED TO ADD DEFAULT COLOR CONSTANTS
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
