using GridGame.Constants;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.GameManagers {
    public static class GraphicsManager {

        public static void InitializeGraphics(GraphicsDeviceManager graphics, Game1 game) {
            graphics = new GraphicsDeviceManager(game);

            graphics.PreferredBackBufferWidth = GameConstants.WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = GameConstants.WINDOW_HEIGHT;
        }

    }
}
