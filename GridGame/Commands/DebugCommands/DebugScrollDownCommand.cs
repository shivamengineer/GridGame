using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.Constants.Controller;
using GridGame.Constants.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Commands.DebugCommands {
    public class DebugScrollDownCommand : ICommand {

        private ConstantsInterfaceController interfaceController;
        private int scrollSpeed;

        public DebugScrollDownCommand(ConstantsInterfaceController interfaceController, ConstantsController Constants) {
            this.interfaceController = interfaceController;
            scrollSpeed = Constants.GetUIInts()[ConstUserInterface.TechTreeScrollSpeed];
        }

        public void Execute() {
            interfaceController.Scroll(scrollSpeed);
        }

    }
}
