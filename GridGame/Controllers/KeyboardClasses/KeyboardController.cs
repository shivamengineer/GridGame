using GridGame.Commands;
using GridGame.GameManagers;
using GridGame.Hexagons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GridGame.Controllers {
    public class KeyboardController : IController {

        private KeyboardState previousKeyboardState;
        private KeyboardState currentKeyboardState;

        private Dictionary<Keys, ICommand> OnPressMapping;
        private Dictionary<Keys, ICommand> HeldMapping;
        private Dictionary<Keys, ICommand> OnReleaseMapping;

        public KeyboardController(/*GameManager gameManager*/) {
            OnPressMapping = new Dictionary<Keys, ICommand>();
            HeldMapping = new Dictionary<Keys, ICommand>();
            OnReleaseMapping = new Dictionary<Keys, ICommand>();

            //KeyboardBindings.InitializeBindings(this, gameManager.hexagonMap);
            //KeyboardBindings.InitializeMenuBindings(this, gameManager);
        }

        public void AddOnPressBinding(Keys key, ICommand command) {
            OnPressMapping.Add(key, command);
        }

        public void AddHeldBinding(Keys key, ICommand command) {
            HeldMapping.Add(key, command);
        }

        public void AddOnReleaseBinding(Keys key, ICommand command) {
            OnReleaseMapping.Add(key, command);
        }

        public void Update(GameTime gameTime) {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            IEnumerable<Keys> pressedBefore = previousKeyboardState.GetPressedKeys();
            IEnumerable<Keys> pressedNow = currentKeyboardState.GetPressedKeys();

            IEnumerable<Keys> OnPressKeys = pressedNow.Except(pressedBefore);
            IEnumerable<Keys> HeldKeys = pressedNow.Intersect(pressedBefore);
            IEnumerable<Keys> OnReleaseKeys = pressedBefore.Except(pressedNow);

            ExecuteCommands(OnPressMapping, OnPressKeys);
            ExecuteCommands(HeldMapping, HeldKeys);
            ExecuteCommands(OnReleaseMapping, OnReleaseKeys);
        }

        private void ExecuteCommands(Dictionary<Keys, ICommand> Mappings, IEnumerable<Keys> keys) {
            foreach(Keys key in keys) {
                if(Mappings.TryGetValue(key, out ICommand command)) command.Execute();
            }
        }

    }
}
