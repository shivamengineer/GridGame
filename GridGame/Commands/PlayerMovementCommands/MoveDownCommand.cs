using GridGame.Hexagons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Commands.PlayerMovementCommands {
    public class MoveDownCommand : ICommand {

        private HexagonMap hexagonMap;

        public MoveDownCommand(HexagonMap hexagonMap) {
            this.hexagonMap = hexagonMap;
        }

        public void Execute() {
            hexagonMap.citizenManager.CurrentPlayer.movement.MoveDown();
        }

    }
}
