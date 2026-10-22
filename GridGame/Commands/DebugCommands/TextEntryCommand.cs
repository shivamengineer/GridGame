using GridGame.GameManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Commands.DebugCommands {
    public class TextEntryCommand : ICommand {

        private GameManager gameManager;

        public TextEntryCommand(GameManager gameManager) {
            this.gameManager = gameManager;
        }

        public void Execute() {
            gameManager.displayManager.ToggleTyping();
        }

    }
}
