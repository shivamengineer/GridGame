using GridGame.Constants.Interface;
using GridGame.Constants.Interface.InterfacePages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Commands.DebugCommands {
    public class TypeCommand : ICommand {

        private ConstantsInterfaceController interfaceController;
        private char c;

        public TypeCommand(ConstantsInterfaceController interfaceController, char c) {
            this.interfaceController = interfaceController;
            this.c = c;
        }

        public void Execute() {
            interfaceController.GetCurrentPage().TypeLetter(c);
        }

    }
}
