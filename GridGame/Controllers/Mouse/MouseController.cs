using GridGame.Commands;
using GridGame.Commands.CameraCommands;
using GridGame.Commands.MouseCommands;
using GridGame.Hexagons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Controllers {
    public class MouseController : IController {

        private MouseState lastMouseState;
        private HexagonMap hexagonMap;
        private MouseDownHandler mouseDownHandler;

        private Dictionary<MouseEventTypes, ICommand> mouseCommands;

        public MouseController(HexagonMap hexagonMap, MouseDownHandler mouseDownHandler) {
            lastMouseState = Mouse.GetState();
            this.hexagonMap = hexagonMap;
            this.mouseDownHandler = mouseDownHandler;

            mouseCommands = new Dictionary<MouseEventTypes, ICommand>();
            MouseBindings.InitializeBindings(this, hexagonMap);
        }

        public void AddBinding(MouseEventTypes type, ICommand command) {
            mouseCommands.Add(type, command);
        }

        public void Update(GameTime gameTime) {
            MouseState mouseState = Mouse.GetState();

            Scroll(mouseState);
            OnMouseMove(mouseState);

            if(mouseState.LeftButton == ButtonState.Pressed) {
                if(lastMouseState.LeftButton == ButtonState.Released) {
                    mouseDownHandler.OnMouseDown(mouseState.X, mouseState.Y, hexagonMap);
                } else {
                    OnLeftMouseStay(mouseState);
                }
            } else if(lastMouseState.LeftButton == ButtonState.Pressed){
                OnLeftMouseUp(mouseState);
            }

            lastMouseState = mouseState;
        }

        public void OnLeftMouseStay(MouseState mouseState) {
            //
        }

        public void OnLeftMouseUp(MouseState mouseState) {
            //
        }

        public void OnMouseMove(MouseState mouseState) {
            if(mouseState.Position == lastMouseState.Position) return;

            ICommand hoverCommand = new HoverTileCommand(hexagonMap, mouseState.Position);
            hoverCommand.Execute();
        }

        public void Scroll(MouseState mouseState) {
            int scrollDifference = mouseState.ScrollWheelValue - lastMouseState.ScrollWheelValue;
            if(scrollDifference > 0) {
                ScrollUp(mouseState);
            } else if(scrollDifference < 0){
                ScrollDown(mouseState);
            }
        }

        public void ScrollUp(MouseState mouseState) {
            mouseCommands[MouseEventTypes.SCROLL_UP].Execute();
        }

        public void ScrollDown(MouseState mouseState) {
            mouseCommands[MouseEventTypes.SCROLL_DOWN].Execute();
        }

    }
}
