using GridGame.GameManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Controllers.Keyboard {
    public class KeyboardHandler {

        public KeyboardController GameKeyInput { get; private set; }
        public KeyboardController MenuKeyInput { get; private set; }

        public KeyboardHandler(GameManager gameManager) {
            GameKeyInput = new KeyboardController();
            MenuKeyInput = new KeyboardController();
        }

    }
}
