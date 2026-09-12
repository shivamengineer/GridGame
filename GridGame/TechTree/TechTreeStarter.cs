using GridGame.TechTree.Backend;
using GridGame.TechTree.Visual.TechnologyBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree {
    public static class TechTreeStarter {

        public static HashSet<ITechBlock> StartingVisibleTechs(NewTechBlock NewTech) {
            HashSet<ITechBlock> StartingVisible = new HashSet<ITechBlock>() {
                NewTech.GetTechnology(TechnologyTypes.FACEMASK),
                NewTech.GetTechnology(TechnologyTypes.SOAP),
                NewTech.GetTechnology(TechnologyTypes.MEDICAL_TENT),
            };
            foreach(ITechBlock techBlock in StartingVisible) {
                techBlock.SetVisible();
            }
            return StartingVisible;
        }

    }
}
