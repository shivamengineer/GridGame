using GridGame.Hexagons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Commands.MouseCommands {
    public class ScrollUpCommand : ICommand {

        private HexagonMap hexagonMap;

        public ScrollUpCommand(HexagonMap hexagonMap) {
            this.hexagonMap = hexagonMap;
        }

        public void Execute() {
            //
        }

    }
}
