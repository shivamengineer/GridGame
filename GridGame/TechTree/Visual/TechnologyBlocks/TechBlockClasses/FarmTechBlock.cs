using GridGame.Constants.TechTreeGraph;
using GridGame.TechTree.Backend.Technology.TechnologyClasses;
using GridGame.TechTree.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Visual.TechnologyBlocks.TechBlockClasses {
    public class FarmTechBlock : AbstractTechBlock {

        public FarmTechBlock() {
            Cost = TechCost.FARM_COST;
            text = "FARM";
            NextTechBlocks = new Dictionary<TechnologyTypes, ITechBlock>();
            TechType = TechnologyTypes.FARM;
            Technology = new FarmTechnology();
            InitializeConnectedTechBlocks();
            SetRectangle();
        }

        private void InitializeConnectedTechBlocks() {
            Prerequisites = new HashSet<TechnologyTypes>() {
                //
            };
            NextTechs = new HashSet<TechnologyTypes>() {
                TechnologyTypes.FACTORY,
                TechnologyTypes.BANK,
            };
        }

        public override ITechBlock NewInstance() {
            ITechBlock block = new FarmTechBlock();
            block.SetContent(content, playerResources);
            return block;
        }

    }
}
