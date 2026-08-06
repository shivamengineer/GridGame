using GridGame.Hexagons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Commands.CameraCommands {
    public class MoveCameraLeftCommand : ICommand {

        private HexagonMap hexagonMap;

        public MoveCameraLeftCommand(HexagonMap hexagonMap) {
            this.hexagonMap = hexagonMap;
        }

        public void Execute() {
            hexagonMap.hexMap.HexMath.MoveCameraLeft();
        }

    }
}
