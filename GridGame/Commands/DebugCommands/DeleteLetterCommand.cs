using GridGame.Constants.Interface.InterfacePages;
using GridGame.Constants.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Commands.DebugCommands {
    public class DeleteLetterCommand : ICommand {

        private ConstantsInterfaceController interfaceController;

        public DeleteLetterCommand(ConstantsInterfaceController interfaceController) {
            this.interfaceController = interfaceController;
        }

        public void Execute() {
            interfaceController.GetCurrentPage().DeleteLetter();
        }

    }
}
