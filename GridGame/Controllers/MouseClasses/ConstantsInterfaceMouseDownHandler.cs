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

        private ConstantsInterfaceController interfaceController;

        public ConstantsInterfaceMouseDownHandler(ConstantsInterfaceController interfaceController) {
            this.interfaceController = interfaceController;
        }

        public void OnMouseDown(int x, int y) {
            Point point = new Point(x, y);
            IConstantsInterfacePage currentPage = interfaceController.GetCurrentPage();
            List<IConstantBlock> BlockLists = currentPage.GetActiveBlocks();
            foreach(IConstantBlock constBlock  in BlockLists) {
                if(constBlock.Background.Contains(point)) {
                    constBlock.OnClick();
                }
            }
        }

    }
}
