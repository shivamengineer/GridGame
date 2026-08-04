using GridGame.Controllers;
using GridGame.GameManagers.ManagerEnums;
using GridGame.Hexagons;
using GridGame.TextureLoading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.GameManagers {
    public static class ControllerLoader {
        
        public static void LoadMouseController(Dictionary<ControllerTypes, IController> controllers, HexagonMap hexagonMap, DisplayManager displayManager) {
            MouseDownHandler mouseDownHandler = new MouseDownHandler(displayManager.resourceManager.GetResourceDisplay(), displayManager.buttonDisplay);
            controllers.Add(ControllerTypes.MOUSE, new MouseController(hexagonMap, mouseDownHandler));
        }

    }
}
