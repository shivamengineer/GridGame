using GridGame.Commands.CameraCommands;
using GridGame.Commands.DebugCommands;
using GridGame.Commands.OptionsCommands;
using GridGame.Commands.PlayerMovementCommands;
using GridGame.Commands.TechTreeCommands;
using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsClasses;
using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.Constants.Interface;
using GridGame.GameManagers;
using GridGame.Hexagons;
using GridGame.TechTree;
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

            keyboardController.AddHeldBinding(Keys.Left, new MoveCameraLeftCommand(hexagonMap));
            keyboardController.AddHeldBinding(Keys.Right, new MoveCameraRightCommand(hexagonMap));
            keyboardController.AddHeldBinding(Keys.Up, new MoveCameraUpCommand(hexagonMap));
            keyboardController.AddHeldBinding(Keys.Down, new MoveCameraDownCommand(hexagonMap));

            keyboardController.AddHeldBinding(Keys.P, new ZoomInCommand(hexagonMap));
            keyboardController.AddHeldBinding(Keys.O, new ZoomOutCommand(hexagonMap));

            keyboardController.AddOnPressBinding(Keys.Space, new CenterCameraCommand(hexagonMap));
        }

        public static void InitializeMenuBindings(KeyboardController keyboardController, GameManager gameManager) {
            TechnologyController techController = gameManager.displayManager.technologyController;

            keyboardController.AddOnPressBinding(Keys.B, new PauseCommand(gameManager));
            keyboardController.AddOnPressBinding(Keys.N, new OpenDebugCommand(gameManager));
        }

        public static void InitializeDebugBindings(KeyboardController keyboardController, GameManager gameManager) {
            ConstantsInterfaceController interfaceController = gameManager.displayManager.interfaceController;
            ConstantsController Constants = gameManager.Constants;

            keyboardController.AddOnPressBinding(Keys.Right, new SwitchPageRightCommand(interfaceController));
            keyboardController.AddOnPressBinding(Keys.Left, new SwitchPageLeftCommand(interfaceController));

            keyboardController.AddHeldBinding(Keys.Up, new DebugScrollUpCommand(interfaceController, Constants));
            keyboardController.AddHeldBinding(Keys.Down, new DebugScrollDownCommand(interfaceController, Constants));
        }

        public static void InitializeTypingBindings(KeyboardController keyboardController, GameManager gameManager) {
            ConstantsInterfaceController interfaceController = gameManager.displayManager.interfaceController;

            keyboardController.AddOnPressBinding(Keys.R, new TypeCommand(interfaceController, 'R'));
            keyboardController.AddOnPressBinding(Keys.G, new TypeCommand(interfaceController, 'G'));
            keyboardController.AddOnPressBinding(Keys.B, new TypeCommand(interfaceController, 'B'));
            keyboardController.AddOnPressBinding(Keys.A, new TypeCommand(interfaceController, 'A'));

            keyboardController.AddOnPressBinding(Keys.D0, new TypeCommand(interfaceController, '0'));
            keyboardController.AddOnPressBinding(Keys.D1, new TypeCommand(interfaceController, '1'));
            keyboardController.AddOnPressBinding(Keys.D2, new TypeCommand(interfaceController, '2'));
            keyboardController.AddOnPressBinding(Keys.D3, new TypeCommand(interfaceController, '3'));
            keyboardController.AddOnPressBinding(Keys.D4, new TypeCommand(interfaceController, '4'));
            keyboardController.AddOnPressBinding(Keys.D5, new TypeCommand(interfaceController, '5'));
            keyboardController.AddOnPressBinding(Keys.D6, new TypeCommand(interfaceController, '6'));
            keyboardController.AddOnPressBinding(Keys.D7, new TypeCommand(interfaceController, '7'));
            keyboardController.AddOnPressBinding(Keys.D8, new TypeCommand(interfaceController, '8'));
            keyboardController.AddOnPressBinding(Keys.D9, new TypeCommand(interfaceController, '9'));

            keyboardController.AddOnPressBinding(Keys.OemSemicolon, new TypeCommand(interfaceController, ':'));
            keyboardController.AddOnPressBinding(Keys.OemComma, new TypeCommand(interfaceController, ','));
            keyboardController.AddOnPressBinding(Keys.Space, new TypeCommand(interfaceController, ' '));

            keyboardController.AddOnPressBinding(Keys.Back, new DeleteLetterCommand(interfaceController));
            keyboardController.AddOnPressBinding(Keys.Enter, new StopTypingCommand(interfaceController));
        }

    }
}
