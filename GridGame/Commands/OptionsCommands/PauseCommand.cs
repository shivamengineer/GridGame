using GridGame.GameManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Commands.OptionsCommands {
    public class PauseCommand : ICommand {

        private GameManager gameManager;

        public PauseCommand(GameManager gameManager) {
            this.gameManager = gameManager;
        }

        public void Execute() {
            gameManager.TogglePaused();
        }
    }
}
