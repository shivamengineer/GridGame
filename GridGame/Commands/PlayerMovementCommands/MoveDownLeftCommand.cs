using GridGame.Hexagons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Commands.PlayerMovementCommands {
    public class MoveDownLeftCommand : ICommand {

        private HexagonMap hexagonMap;

        public MoveDownLeftCommand(HexagonMap hexagonMap) {
            this.hexagonMap = hexagonMap;
        }

        public void Execute() {
            hexagonMap.player.MoveDownLeft();
        }

    }
}
