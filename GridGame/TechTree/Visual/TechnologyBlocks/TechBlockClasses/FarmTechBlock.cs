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
    public class FarmTechBlock : AbstractTechBlock {

        public FarmTechBlock() {
            Cost = TechCost.FARM_COST;
            text = "FARM";
            NextTechBlocks = new Dictionary<TechnologyTypes, ITechBlock>();
            TechType = TechnologyTypes.FARM;
            Technology = new FarmTechnology();
            InitializeConnectedTechBlocks();
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

        public override void SetCost() {
            Cost = Constants.GetGameInts()[ConstGameInt.FarmScienceCost];
        }

        public override ITechBlock NewInstance() {
            ITechBlock block = new FarmTechBlock();
            block.SetContent(content, Constants, playerResources);
            return block;
        }

    }
}
