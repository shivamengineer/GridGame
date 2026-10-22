using GridGame.Constants.Interface;
using GridGame.GameManagers;
using GridGame.Hexagons;
using GridGame.TechTree.Backend;
using GridGame.TechTree.Visual.TechnologyBlocks;
using GridGame.TechTree;
using GridGame.Tiles.Buildings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridGame.Constants.Interface.InterfacePages;
using GridGame.Constants.Interface.ConstantBlocks;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace GridGame.Controllers.MouseClasses {
    public class ConstantsInterfaceMouseDownHandler : IMouseHandler {

        private DisplayManager displayManager;
        private ConstantsInterfaceController interfaceController;

        public ConstantsInterfaceMouseDownHandler(DisplayManager displayManager) {
            this.displayManager = displayManager;
            interfaceController = displayManager.interfaceController;
        }

        public bool OnMouseDown(int x, int y) {
            IConstantsInterfacePage currentPage = interfaceController.GetCurrentPage();
            currentPage.OnClick(displayManager, x, y);
            return false;
        }

    }
}
