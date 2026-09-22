using GridGame.Constants;
using GridGame.GameManagers;
using GridGame.Hexagons.StaticClasses;
using GridGame.Hexagons;
using GridGame.Tiles.Buildings;
using GridGame.UI.Button;
using GridGame.UI.Elements;
using GridGame.UI.Overlay.ResourcesDisplay;
using GridGame.UI.Overlay.SelectActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using GridGame.TechTree.Visual.TechnologyBlocks;
using GridGame.TechTree;

namespace GridGame.Controllers.MouseClasses {
    public class TechTreeMouseDownHandler : IMouseHandler {

        private ResourceDisplay resourceDisplay;
        private TechnologyController technologyController;

        private ITechBlock SelectedBlock;

        public TechTreeMouseDownHandler(DisplayManager displayManager) {
            resourceDisplay = displayManager.resourceManager.resourceDisplay;
            technologyController = displayManager.technologyController;
        }

        public void OnMouseDown(int x, int y, HexagonMap hexagonMap) {
            Point point = new Point(x, y);

            if(resourceDisplay.MouseOnDisplay(point)) {
                SelectResource(point);
            } else {
                SelectTechBlock(point);
            }
        }

        private void SelectResource(Point point) {
            IItem item = resourceDisplay.GetSelectedResource(point);
        }

        private void SelectTechBlock(Point point) {
            var BlockLists = technologyController.GetActiveBlocks();
            for(int i = 0; i < BlockLists.Count; i++) {
                foreach(ITechBlock techBlock in BlockLists[i].Values) {
                    if(techBlock.Background.Contains(point)) {
                        techBlock.TryResearch();
                        return;
                    }
                }
            }
        }

    }
}
