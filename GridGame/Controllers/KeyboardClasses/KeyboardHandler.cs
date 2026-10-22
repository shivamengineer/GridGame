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
        public KeyboardController DebugKeyInput { get; private set; }
        public KeyboardController TypingKeyInput { get; private set; }

        public KeyboardHandler(GameManager gameManager) {
            GameKeyInput = new KeyboardController();
            MenuKeyInput = new KeyboardController();
            DebugKeyInput = new KeyboardController();
            TypingKeyInput = new KeyboardController();

            KeyboardBindings.InitializeBindings(GameKeyInput, gameManager.hexagonMap);
            KeyboardBindings.InitializeMenuBindings(MenuKeyInput, gameManager);
            KeyboardBindings.InitializeDebugBindings(DebugKeyInput, gameManager);
            KeyboardBindings.InitializeTypingBindings(TypingKeyInput, gameManager);
        }

        public void Update(GameTime gameTime, bool paused, bool debug, bool typing) {
            if(!paused && !debug) {
                GameKeyInput.Update(gameTime);
            }
            if(debug && !typing) {
                DebugKeyInput.Update(gameTime);
            } else if(debug) {
                TypingKeyInput.Update(gameTime);
            }
            MenuKeyInput.Update(gameTime);
        }

    }
}
