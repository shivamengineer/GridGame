using GridGame.UI.Button;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.UI.Menu {
    public class Menu {

        private List<IButton> buttons;

        public Menu() {
            buttons = new List<IButton>();
        }

        public void CheckAnyButtonClicked() {
            foreach(var Button in buttons) {
                // Check if clicked
            }
        }

    }
}
