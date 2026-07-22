using GridGame.Hexagons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Commands {
    public class ZoomOutCommand : ICommand {

        private HexagonMap hexagonMap;

        public ZoomOutCommand(HexagonMap hexagonMap) {
            this.hexagonMap = hexagonMap;
        }

        public void Execute() {
            hexagonMap.ZoomOut();
        }

    }
}
