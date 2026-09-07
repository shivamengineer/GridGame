using GridGame.TechTree.Backend.Technology;
using GridGame.TechTree.Backend.Technology.TechnologyClasses;
using GridGame.TechTree.Visual.TechnologyBlocks.TechBlockClasses;
using GridGame.TechTree.Visual.TechnologyBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Backend {
    public class NewTechBlock {

        private Dictionary<TechnologyTypes, ITechBlock> TechBlockMap;
        private NewTechnology NewTech; 

        public NewTechBlock() {
            TechBlockMap = new Dictionary<TechnologyTypes, ITechBlock>() {
                [TechnologyTypes.FACEMASK] = new FacemaskTechBlock(),
            };
        }

        public ITechBlock GetTechnology(TechnologyTypes type) {
            ITechBlock block = TechBlockMap[type].NewInstance();
            block.Technology = NewTech.GetTechnology(type);
            return block;
        }

    }
}
