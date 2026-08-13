using GridGame.Hexagons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Commands.MouseCommands {
    public class ScrollDownCommand : ICommand {

        private HexagonMap hexagonMap;

        public ScrollDownCommand(HexagonMap hexagonMap) {
            this.hexagonMap = hexagonMap;
        }

        public void Execute() {
            //
        }

    }
}
