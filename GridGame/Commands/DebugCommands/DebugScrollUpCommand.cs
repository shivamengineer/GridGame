using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.Constants.Controller;
using GridGame.TechTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridGame.Constants.Interface;

namespace GridGame.Commands.DebugCommands {
    public class DebugScrollUpCommand : ICommand {

        private ConstantsInterfaceController interfaceController;
        private int scrollSpeed;

        public DebugScrollUpCommand(ConstantsInterfaceController interfaceController, ConstantsController Constants) {
            this.interfaceController = interfaceController;
            scrollSpeed = Constants.GetUIInts()[ConstUserInterface.ConstGraphScrollSpeed];
        }

        public void Execute() {
            interfaceController.Scroll(-scrollSpeed);
        }

    }
}
