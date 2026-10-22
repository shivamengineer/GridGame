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

namespace GridGame.Controllers.MouseClasses {
    public class ConstantsInterfaceMouseDownHandler : IMouseHandler {

        private GameManager gameManager;
        private ConstantsInterfaceController interfaceController;

        public ConstantsInterfaceMouseDownHandler(GameManager gameManager) {
            this.gameManager = gameManager;
            this.interfaceController = gameManager.displayManager.interfaceController;
        }

        public bool OnMouseDown(int x, int y) {
            IConstantsInterfacePage currentPage = interfaceController.GetCurrentPage();
            if(currentPage.OnClick(x, y)) gameManager.ToggleTyping();
            return false;
        }

    }
}
