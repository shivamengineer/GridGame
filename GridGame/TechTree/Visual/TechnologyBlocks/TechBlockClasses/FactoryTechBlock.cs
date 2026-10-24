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
    public class FactoryTechBlock : AbstractTechBlock {

        public FactoryTechBlock() {
            Cost = TechCost.FACTORY_COST;
            text = "FACTORY";
            NextTechBlocks = new Dictionary<TechnologyTypes, ITechBlock>();
            TechType = TechnologyTypes.FACTORY;
            Technology = new FactoryTechnology();
            InitializeConnectedTechBlocks();
        }

        private void InitializeConnectedTechBlocks() {
            Prerequisites = new HashSet<TechnologyTypes>() {
                TechnologyTypes.FARM,
                TechnologyTypes.BANK,
            };
            NextTechs = new HashSet<TechnologyTypes>() {
                //
            };
        }

        public override void SetCost() {
            Cost = Constants.GetGameInts()[ConstGameInt.FactoryScienceCost];
        }

        public override ITechBlock NewInstance() {
            ITechBlock block = new FactoryTechBlock();
            block.SetContent(content, Constants, playerResources);
            return block;
        }

    }
}
