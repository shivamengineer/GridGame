using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsClasses;
using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.Constants.TechTreeInfo;
using GridGame.TechTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Commands.TechTreeCommands {
    public class TechScrollRightCommand : ICommand {

        private TechnologyController techController;
        private int scrollSpeed;

        public TechScrollRightCommand(TechnologyController techController, IConstantsManager constantsManager) {
            this.techController = techController;
            scrollSpeed = constantsManager.GetUIInts()[ConstUserInterface.TechTreeScrollSpeed];
        }

        public void Execute() {
            techController.CameraX += scrollSpeed;
            techController.UpdateCamera();
        }

    }
}
