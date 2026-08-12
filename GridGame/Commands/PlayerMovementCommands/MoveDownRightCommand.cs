using GridGame.Hexagons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Commands.PlayerMovementCommands {
    public class MoveDownRightCommand : ICommand {

        private HexagonMap hexagonMap;

        public MoveDownRightCommand(HexagonMap hexagonMap) {
            this.hexagonMap = hexagonMap;
        }

        public void Execute() {
            hexagonMap.playerData.CurrentPlayer.MoveDownRight();
        }

    }
}
