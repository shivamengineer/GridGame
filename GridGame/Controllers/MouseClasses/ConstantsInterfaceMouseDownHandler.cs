using GridGame.Constants.Interface;
using GridGame.Hexagons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Controllers.MouseClasses {
    public class ConstantsInterfaceMouseDownHandler : IMouseHandler {

        private ConstantsInterfaceController interfaceController;

        public ConstantsInterfaceMouseDownHandler(ConstantsInterfaceController interfaceController) {
              
        }

        public void OnMouseDown(int x, int y) {
            //
        }

    }
}
