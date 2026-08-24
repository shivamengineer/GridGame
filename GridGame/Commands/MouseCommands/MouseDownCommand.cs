using GridGame.Hexagons;
using GridGame.Tiles.Buildings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Commands.MouseCommands {
    public class MouseDownCommand : ICommand {

        private HexagonMap hexagonMap;

        private Vector2 pos;

        private BuildingType buildingType;

        public MouseDownCommand(HexagonMap hexagonMap, BuildingType buildingType, int x, int y) {
            this.hexagonMap = hexagonMap;
            this.buildingType = buildingType;
            pos = new Vector2(x, y);
        }

        public void Execute() {
            (int, int) clickedHex = hexagonMap.hexMap.HexMath.PixelToHex(pos);
            clickedHex.Item1--;
            hexagonMap.SetSelected(buildingType, clickedHex);
        }

    }
}
