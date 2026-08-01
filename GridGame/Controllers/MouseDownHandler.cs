using GridGame.Commands;
using GridGame.Commands.CameraCommands;
using GridGame.Hexagons;
using GridGame.UI.Button;
using GridGame.UI.Elements;
using GridGame.UI.Overlay.ResourcesDisplay;
using GridGame.UI.Overlay.SelectActions;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Controllers {
    public class MouseDownHandler {

        private ResourceDisplay resourceDisplay;
        private ButtonDisplay buttonDisplay;

        public MouseDownHandler(ResourceDisplay resourceDisplay, ButtonDisplay buttonDisplay) {
            this.resourceDisplay = resourceDisplay;
            this.buttonDisplay = buttonDisplay;
        }

        public void OnMouseDown(int x, int y, HexagonMap hexagonMap) {
            Point point = new Point(x, y);

            if(resourceDisplay.MouseOnDisplay(point)) {
                IItem item = resourceDisplay.GetSelectedResource(point);
            } else if(buttonDisplay.MouseOnDisplay(point)) {
                IButton button = buttonDisplay.GetSelectedButton(point);
            } else {
                ICommand command = new MouseDownCommand(hexagonMap, x, y);
                command.Execute();
            }
        }

    }
}
