using GridGame.Constants.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Commands.DebugCommands {
    public class StopTypingCommand : ICommand {

        private ConstantsInterfaceController interfaceController;

        public StopTypingCommand(ConstantsInterfaceController interfaceController) {
            this.interfaceController = interfaceController;
        }

        public void Execute() {
            interfaceController.StopTyping();
        }

    }
}
