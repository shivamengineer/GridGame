using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Controllers {
    public class MouseController : IController {

        private MouseState lastMouseState;

        public MouseController() {
            lastMouseState = Mouse.GetState();
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
            //
        }

        public void OnLeftMouseStay(MouseState mouseState) {
            //
        }

        public void OnLeftMouseUp(MouseState mouseState) {
            //
        }

    }
}
