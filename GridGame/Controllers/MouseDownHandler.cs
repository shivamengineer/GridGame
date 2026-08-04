using GridGame.Commands;
using GridGame.Commands.CameraCommands;
using GridGame.GameManagers;
using GridGame.Hexagons;
using GridGame.Tiles.Buildings;
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

        private BuildingType selectedBuilding = BuildingType.NIL;

        private IButton selectedButton;

        public MouseDownHandler(DisplayManager displayManager) {
            resourceDisplay = displayManager.resourceManager.GetResourceDisplay();
            buttonDisplay = displayManager.buttonDisplay;
        }

        public void OnMouseDown(int x, int y, HexagonMap hexagonMap) {
            Point point = new Point(x, y);

            if(resourceDisplay.MouseOnDisplay(point)) {
                IItem item = resourceDisplay.GetSelectedResource(point);
            } else if(buttonDisplay.MouseOnDisplay(point)) {
                if(selectedButton != null) selectedButton.SetRectSelected(false);

                IButton button = buttonDisplay.GetSelectedButton(point);

                if(button != null) {
                    selectedButton = button;
                    selectedBuilding = selectedButton.GetBuildingType();
                    selectedButton.SetRectSelected(true);
                }
            } else if(selectedBuilding != BuildingType.NIL){
                ICommand command = new MouseDownCommand(hexagonMap, x, y);
                command.Execute();
            }
        }

    }
}
