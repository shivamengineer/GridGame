using GridGame.Commands.CameraCommands;
using GridGame.Commands.OptionsCommands;
using GridGame.Commands.PlayerMovementCommands;
using GridGame.GameManagers;
using GridGame.Hexagons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Controllers.KeyboardClasses {
    public static class KeyboardBindings {

        public static void InitializeBindings(KeyboardController keyboardController, HexagonMap hexagonMap) {
            keyboardController.AddOnPressBinding(Keys.Q, new MoveUpLeftCommand(hexagonMap));
            keyboardController.AddOnPressBinding(Keys.W, new MoveUpCommand(hexagonMap));
            keyboardController.AddOnPressBinding(Keys.E, new MoveUpRightCommand(hexagonMap));
            keyboardController.AddOnPressBinding(Keys.A, new MoveDownLeftCommand(hexagonMap));
            keyboardController.AddOnPressBinding(Keys.S, new MoveDownCommand(hexagonMap));
            keyboardController.AddOnPressBinding(Keys.D, new MoveDownRightCommand(hexagonMap));

            keyboardController.AddOnPressBinding(Keys.K, new SwitchPlayerRightCommand(hexagonMap));
            keyboardController.AddOnPressBinding(Keys.J, new SwitchPlayerLeftCommand(hexagonMap));

            keyboardController.AddOnPressBinding(Keys.T, new AddCitizenCommand(hexagonMap));
        }

        public static void InitializeMenuBindings(KeyboardController keyboardController, GameManager gameManager) {
            HexagonMap hexagonMap = gameManager.hexagonMap;

            keyboardController.AddOnPressBinding(Keys.D1, new PauseCommand(gameManager));

            keyboardController.AddHeldBinding(Keys.Left, new MoveCameraLeftCommand(hexagonMap));
            keyboardController.AddHeldBinding(Keys.Right, new MoveCameraRightCommand(hexagonMap));
            keyboardController.AddHeldBinding(Keys.Up, new MoveCameraUpCommand(hexagonMap));
            keyboardController.AddHeldBinding(Keys.Down, new MoveCameraDownCommand(hexagonMap));

            keyboardController.AddHeldBinding(Keys.P, new ZoomInCommand(hexagonMap));
            keyboardController.AddHeldBinding(Keys.O, new ZoomOutCommand(hexagonMap));

            keyboardController.AddOnPressBinding(Keys.Space, new CenterCameraCommand(hexagonMap));

        }

    }
}
