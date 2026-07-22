using GridGame.Commands;
using GridGame.Hexagons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Controllers {
    public class KeyboardBindings {

        private KeyboardController keyboardController;
        private HexagonMap hexagonMap;

        public KeyboardBindings(HexagonMap hexagonMap) {
            keyboardController = new KeyboardController();
            this.hexagonMap = hexagonMap;
            InitializeBindings();
        }

        public void InitializeBindings() {
            keyboardController.AddHeldBinding(Keys.Left, new MoveCameraLeftCommand(hexagonMap));
            keyboardController.AddHeldBinding(Keys.Right, new MoveCameraRightCommand(hexagonMap));
            keyboardController.AddHeldBinding(Keys.Up, new MoveCameraUpCommand(hexagonMap));
            keyboardController.AddHeldBinding(Keys.Down, new MoveCameraDownCommand(hexagonMap));
        }

        public void Update(GameTime gameTime) {
            keyboardController.Update(gameTime);
        }

    }
}
