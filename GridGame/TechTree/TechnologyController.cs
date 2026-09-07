using GridGame.TechTree.Backend;
using GridGame.TechTree.Visual.TechnologyBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree {
    public class TechnologyController {

        private TechProgress TechProgress;
        private HashSet<ITechBlock> TechBlockRoots;
        private NewTechBlock NewTech;

        public TechnologyController() {
            TechProgress = new TechProgress();
            NewTech = new NewTechBlock();
            InitializeGraph();
        }

        private void InitializeGraph() {
            TechBlockRoots = TechTreeStarter.StartingVisibleTechs(NewTech);
            foreach(ITechBlock techBlock in TechBlockRoots) {
                techBlock.InitializeGraph(NewTech);
            }
        }

    }
}
