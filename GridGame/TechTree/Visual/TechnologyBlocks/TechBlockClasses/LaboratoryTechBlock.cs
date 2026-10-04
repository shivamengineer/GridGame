using GridGame.Constants.TechTreeGraph;
using GridGame.TechTree.Backend.Technology.TechnologyClasses;
using GridGame.TechTree.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Visual.TechnologyBlocks.TechBlockClasses {
    public class LaboratoryTechBlock : AbstractTechBlock {

        public LaboratoryTechBlock() {
            Cost = TechCost.LABORATORY_COST;
            text = "LABORATORY " + Cost;
            NextTechBlocks = new Dictionary<TechnologyTypes, ITechBlock>();
            TechType = TechnologyTypes.LABORATORY;
            Technology = new LaboratoryTechnology();
            InitializeConnectedTechBlocks();
            SetRectangle();
        }

        private void InitializeConnectedTechBlocks() {
            Prerequisites = new HashSet<TechnologyTypes>() {
                TechnologyTypes.MEDICAL_TENT,
            };
            NextTechs = new HashSet<TechnologyTypes>() {
                //
            };
        }

        public override ITechBlock NewInstance() {
            ITechBlock block = new LaboratoryTechBlock();
            block.SetContent(content);
            return block;
        }

    }
}
