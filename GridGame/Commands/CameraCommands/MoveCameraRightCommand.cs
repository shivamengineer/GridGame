using GridGame.Hexagons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Commands.CameraCommands {
    public class MoveCameraRightCommand : ICommand {

        private HexagonMap hexagonMap;

        public MoveCameraRightCommand(HexagonMap hexagonMap) {
            this.hexagonMap = hexagonMap;
        }

        public void Execute() {
            hexagonMap.hexMap.HexMath.MoveCameraRight();
        }

    }
}
