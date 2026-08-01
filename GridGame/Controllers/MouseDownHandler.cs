using GridGame.UI.Overlay.ResourcesDisplay;
using GridGame.UI.Overlay.SelectActions;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Controllers {
    public class MouseDownHandler {

        private ResourceDisplay resourceDisplay;
        private ButtonDisplay buttonDisplay;

        public MouseDownHandler(ResourceDisplay resourceDisplay, ButtonDisplay buttonDisplay) {
            this.resourceDisplay = resourceDisplay;
            this.buttonDisplay = buttonDisplay;
        }

        public void OnMouseDown(int x, int y) {
            Point point = new Point(x, y);

            if(resourceDisplay.MouseOnDisplay(point)) {
                //
            } else if(buttonDisplay.MouseOnDisplay(point)) {
                //
            } else {
                //
            }
        }

    }
}
