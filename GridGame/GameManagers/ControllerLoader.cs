using GridGame.Constants.Controller;
using GridGame.Constants.Interface;
using GridGame.Controllers;
using GridGame.Controllers.MouseClasses;
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
        
        public static void LoadMouseController(Dictionary<ControllerTypes, IController> controllers, HexagonMap hexagonMap, DisplayManager displayManager, ConstantsController Constants) {
            MouseDownHandler mouseDownHandler = new MouseDownHandler(displayManager, hexagonMap, Constants);
            controllers.Add(ControllerTypes.MOUSE, new MouseController(hexagonMap, mouseDownHandler));
        }

        public static void LoadPauseMouseController(Dictionary<ControllerTypes, IController> controllers, HexagonMap hexagonMap) {
            TechTreeMouseDownHandler mouseDownHandler = new TechTreeMouseDownHandler(hexagonMap);
            controllers.Add(ControllerTypes.MOUSE, new MouseController(hexagonMap, mouseDownHandler));
        }

        public static void LoadDebugMouseController(Dictionary<ControllerTypes, IController> controllers, GameManager gameManager) {
            ConstantsInterfaceMouseDownHandler mouseDownHandler = new ConstantsInterfaceMouseDownHandler(gameManager.displayManager);
            controllers.Add(ControllerTypes.MOUSE, new MouseController(gameManager.hexagonMap, mouseDownHandler));
        }

    }
}
