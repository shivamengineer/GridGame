using GridGame.Hexagons;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Commands.MouseCommands {
    public class HoverTileCommand : ICommand {

        private HexagonMap hexagonMap;
        private Point point;

        public HoverTileCommand(HexagonMap hexagonMap, Point point) {
            this.hexagonMap = hexagonMap;
            this.point = point;
        }

        public void Execute() {
            (int, int) clickedHex = hexagonMap.hexMap.HexMath.PixelToHex(new Vector2(point.X + 10, point.Y - 6));
            hexagonMap.SetHover(clickedHex.Item1 - 1, clickedHex.Item2);
        }

    }
}
