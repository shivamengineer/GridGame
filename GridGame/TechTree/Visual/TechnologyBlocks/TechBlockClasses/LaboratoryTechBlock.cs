using GridGame.Constants.TechTreeInfo;
using GridGame.TechTree.Backend.Technology.TechnologyClasses;
using GridGame.TechTree.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridGame.Constants.Controller.ConstantsEnums;

namespace GridGame.TechTree.Visual.TechnologyBlocks.TechBlockClasses {
    public class LaboratoryTechBlock : AbstractTechBlock {

        public LaboratoryTechBlock() {
            Cost = TechCost.LABORATORY_COST;
            text = "LABORATORY";
            NextTechBlocks = new Dictionary<TechnologyTypes, ITechBlock>();
            TechType = TechnologyTypes.LABORATORY;
            Technology = new LaboratoryTechnology();
            InitializeConnectedTechBlocks();
        }

        private void InitializeConnectedTechBlocks() {
            Prerequisites = new HashSet<TechnologyTypes>() {
                TechnologyTypes.MEDICAL_TENT,
            };
            NextTechs = new HashSet<TechnologyTypes>() {
                TechnologyTypes.HOSPITAL,
                TechnologyTypes.BANK,
            };
        }

        public override void SetCost() {
            Cost = Constants.GetGameInts()[ConstGameInt.LaboratoryScienceCost];
        }

        public override ITechBlock NewInstance() {
            ITechBlock block = new LaboratoryTechBlock();
            block.SetContent(content, Constants, playerResources);
            return block;
        }

    }
}
