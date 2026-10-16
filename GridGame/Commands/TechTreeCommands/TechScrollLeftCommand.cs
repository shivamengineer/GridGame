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
    public class TechScrollLeftCommand : ICommand {

        private TechnologyController techController;
        private int scrollSpeed;

        public TechScrollLeftCommand(TechnologyController techController, ConstantsController Constants) {
            this.techController = techController;
            scrollSpeed = Constants.GetUIInts()[ConstUserInterface.TechTreeScrollSpeed];
        }

        public void Execute() {
            techController.CameraX -= scrollSpeed;
            if(techController.CameraX < 0) techController.CameraX = 0;
            techController.UpdateCamera();
        }

    }
}
