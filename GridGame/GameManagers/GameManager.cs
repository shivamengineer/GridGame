using GridGame.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.GameManagers {
    public class GameManager {

        private List<IController> Controllers;
        
        public GameManager() {
            //
        }

        public void Update(GameTime gameTime) {
            foreach(var Controller in Controllers) {
                Controller.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            //
        }

    }
}
