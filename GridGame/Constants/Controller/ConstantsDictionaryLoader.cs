using GridGame.Constants.Controller.ConstantsClasses;
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


    }
}
