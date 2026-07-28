using GridGame.Commands.CameraCommands;
using GridGame.Hexagons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GridGame.Controllers {
    public class MouseController : IController {

        private MouseState lastMouseState;
        private HexagonMap hexagonMap;

        public MouseController(HexagonMap hexagonMap) {
            lastMouseState = Mouse.GetState();
            this.hexagonMap = hexagonMap;
        }

        public void Update(GameTime gameTime) {
            MouseState mouseState = Mouse.GetState();

            if(mouseState.LeftButton == ButtonState.Pressed) {
                if(lastMouseState.LeftButton == ButtonState.Released) {
                    OnLeftMouseDown(mouseState);
                } else {
                    OnLeftMouseStay(mouseState);
                }
            } else if(lastMouseState.LeftButton == ButtonState.Pressed){
                OnLeftMouseUp(mouseState);
            }

            lastMouseState = mouseState;
        }

        public void OnLeftMouseDown(MouseState mouseState) {
            //(int, int) clickedHex = hexagonMap.PixelToHex(new Vector2(mouseState.X, mouseState.Y));
            Commands.ICommand command = new MouseDownCommand(hexagonMap, mouseState.X, mouseState.Y);
            command.Execute();
        }

        public void OnLeftMouseStay(MouseState mouseState) {
            //
        }

        public void OnLeftMouseUp(MouseState mouseState) {
            //
        }

    }
}
