using GridGame.Constants.TechTreeGraph;
using GridGame.TechTree.Backend.Technology.TechnologyClasses;
using GridGame.TechTree.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Visual.TechnologyBlocks.TechBlockClasses {
    public class BankTechBlock : AbstractTechBlock {

        public BankTechBlock() {
            Cost = TechCost.BANK_COST;
            text = "BANK " + Cost;
            NextTechBlocks = new Dictionary<TechnologyTypes, ITechBlock>();
            TechType = TechnologyTypes.BANK;
            Technology = new BankTechnology();
            InitializeConnectedTechBlocks();
            SetRectangle();
        }

        private void InitializeConnectedTechBlocks() {
            Prerequisites = new HashSet<TechnologyTypes>() {
                TechnologyTypes.LABORATORY,
                TechnologyTypes.FARM,
            };
            NextTechs = new HashSet<TechnologyTypes>() {
                //
            };
        }

        public override ITechBlock NewInstance() {
            ITechBlock block = new BankTechBlock();
            block.SetContent(content);
            return block;
        }

    }
}
