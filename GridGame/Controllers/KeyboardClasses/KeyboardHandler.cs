using GridGame.GameManagers;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Controllers.KeyboardClasses {
    public class KeyboardHandler {

        public KeyboardController GameKeyInput { get; private set; }
        public KeyboardController MenuKeyInput { get; private set; }

        public KeyboardHandler(GameManager gameManager) {
            GameKeyInput = new KeyboardController();
            MenuKeyInput = new KeyboardController();

            KeyboardBindings.InitializeBindings(GameKeyInput, gameManager.hexagonMap);
            KeyboardBindings.InitializeMenuBindings(MenuKeyInput, gameManager);
        }

        public void Update(GameTime gameTime, bool paused) {
            if(!paused) {
                GameKeyInput.Update(gameTime);
            }
            MenuKeyInput.Update(gameTime);
        }

    }
}
