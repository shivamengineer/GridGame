using GridGame.Commands;
using GridGame.Commands.CameraCommands;
using GridGame.Constants;
using GridGame.GameManagers;
using GridGame.Hexagons;
using GridGame.Hexagons.StaticClasses;
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

        private bool builtCityCenter = false;
        private BuildingType selectedBuilding = BuildingType.CityCenter;

        private IButton selectedButton;

        public MouseDownHandler(DisplayManager displayManager) {
            resourceDisplay = displayManager.resourceManager.resourceDisplay;
            buttonDisplay = displayManager.buttonDisplay;
            selectedButton = buttonDisplay.GetButton(selectedBuilding);
            selectedButton.SetRectSelected(true);
        }

        public void OnMouseDown(int x, int y, HexagonMap hexagonMap) {
            Point point = new Point(x, y);

            if(resourceDisplay.MouseOnDisplay(point)) {
                SelectResource(point);
            } else if(buttonDisplay.MouseOnDisplay(point)) {
                SelectButton(point);
            } else if(selectedBuilding != BuildingType.NIL){
                TryBuild(x, y, hexagonMap);
            }
        }

        private void SelectResource(Point point) {
            IItem item = resourceDisplay.GetSelectedResource(point);
        }

        private void SelectButton(Point point) {
            if(!builtCityCenter) return;

            if(selectedButton != null) selectedButton.SetRectSelected(false);

            IButton button = buttonDisplay.GetSelectedButton(point);
            if(button.GetBuildingType() == BuildingType.CityCenter) return;

            if(button != null) {
                selectedButton = button;
                selectedBuilding = selectedButton.GetBuildingType();
                selectedButton.SetRectSelected(true);
            }
        }

        private void TryBuild(int x, int y, HexagonMap hexagonMap) {
            (int, int) clickedHex = hexagonMap.hexMap.HexMath.PixelToHex(new Vector2(x + 10, y - 6));
            (int, int) playerPos = hexagonMap.citizenManager.CurrentPlayer.transform.Coords;
            playerPos.Item1++;

            int distanceFromPlayer = DiscoverTiles.DistanceBetweenTiles(clickedHex, playerPos);
            int distanceFromCityCenter = 0;
            if(builtCityCenter) {
                (int, int) offsetClicked = (clickedHex.Item1 - 1, clickedHex.Item2);
                distanceFromCityCenter = DiscoverTiles.DistanceBetweenTiles(offsetClicked, hexagonMap.playerData.buildingManager.city);
            }

            if(distanceFromPlayer > BuildingLimits.BUILDING_RADIUS_FROM_PLAYER) return; //player must be adjacent or on tile
            if(distanceFromCityCenter > BuildingLimits.BUILDING_RADIUS_FROM_CITY) return;

            clickedHex.Item1--;
            if(hexagonMap.SetSelected(selectedBuilding, clickedHex)) {
                if(!builtCityCenter) {
                    builtCityCenter = true;
                }
                selectedBuilding = BuildingType.NIL;
                selectedButton.SetRectSelected(false);
            }
        }

    }
}
