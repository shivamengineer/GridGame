using GridGame.Constants.TechTreeGraph;
using GridGame.TechTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Commands.TechTreeCommands {
    public class TechScrollLeftCommand : ICommand {

        private TechnologyController techController;

        public TechScrollLeftCommand(TechnologyController techController) {
            this.techController = techController;
        }

        public void Execute() {
            techController.CameraX -= TechTreeGraph.SCROLL_SPEED;
        }

    }
}
