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
    public class BankTechBlock : AbstractTechBlock {

        public BankTechBlock() {
            Cost = TechCost.BANK_COST;
            text = "BANK";
            NextTechBlocks = new Dictionary<TechnologyTypes, ITechBlock>();
            TechType = TechnologyTypes.BANK;
            Technology = new BankTechnology();
            InitializeConnectedTechBlocks();
        }

        private void InitializeConnectedTechBlocks() {
            Prerequisites = new HashSet<TechnologyTypes>() {
                TechnologyTypes.LABORATORY,
                TechnologyTypes.FARM,
            };
            NextTechs = new HashSet<TechnologyTypes>() {
                TechnologyTypes.FACTORY,
            };
        }

        public override void SetCost() {
            Cost = Constants.GetGameInts()[ConstGameInt.BankScienceCost];
        }

        public override ITechBlock NewInstance() {
            ITechBlock block = new BankTechBlock();
            block.SetContent(content, Constants, playerResources);
            return block;
        }

    }
}
