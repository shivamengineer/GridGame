using GridGame.Hexagons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Commands.CameraCommands {
    public class MoveCameraDownCommand : ICommand {

        private HexagonMap hexagonMap;

        public MoveCameraDownCommand(HexagonMap hexagonMap) {
            this.hexagonMap = hexagonMap;
        }

        public void Execute() {
            hexagonMap.HexMath.MoveCameraDown();
        }

    }
}
