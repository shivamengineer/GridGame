using GridGame.Hexagons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Commands.PlayerMovementCommands {
    public class SwitchPlayerLeftCommand : ICommand {

        private HexagonMap hexagonMap;

        public SwitchPlayerLeftCommand(HexagonMap hexagonMap) {
            this.hexagonMap = hexagonMap;
        }

        public void Execute() {
            hexagonMap.citizenManager.ChangeCitizenLeft();
        }
    }
}
