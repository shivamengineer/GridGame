using GridGame.Hexagons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Commands.CameraCommands {
    public class MouseDownCommand : ICommand {

        private HexagonMap hexagonMap;

        private Vector2 pos;

        public MouseDownCommand(HexagonMap hexagonMap, int x, int y) {
            this.hexagonMap = hexagonMap;
            pos = new Vector2(x, y);
        }

        public void Execute() {
            (int, int) clickedHex = hexagonMap.HexMath.PixelToHex(pos);
            hexagonMap.SetSelected(clickedHex.Item1, clickedHex.Item2);
        }

    }
}
