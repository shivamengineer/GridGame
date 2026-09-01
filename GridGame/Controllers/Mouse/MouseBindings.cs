using GridGame.Commands.CameraCommands;
using GridGame.Commands.MouseCommands;
using GridGame.Hexagons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Controllers {
    public static class MouseBindings {

        public static void InitializeBindings(MouseController mouseController, HexagonMap hexagonMap) {
            mouseController.AddBinding(MouseEventTypes.SCROLL_UP, new ZoomOutCommand(hexagonMap));
            mouseController.AddBinding(MouseEventTypes.SCROLL_DOWN, new ZoomInCommand(hexagonMap));
        }

    }
}
