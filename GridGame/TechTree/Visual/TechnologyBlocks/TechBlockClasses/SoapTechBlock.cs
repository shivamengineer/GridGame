using GridGame.TechTree.Backend.Technology.TechnologyClasses;
using GridGame.TechTree.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Visual.TechnologyBlocks.TechBlockClasses {
    public class SoapTechBlock : AbstractTechBlock {

        public SoapTechBlock() {
            text = "SOAP";
            NextTechBlocks = new Dictionary<TechnologyTypes, ITechBlock>();
            TechType = TechnologyTypes.SOAP;
            Technology = new SoapTechnology();
            InitializeConnectedTechBlocks();
            SetRectangle();
        }

        private void InitializeConnectedTechBlocks() {
            Prerequisites = new HashSet<TechnologyTypes>() {
                //
            };
            NextTechs = new HashSet<TechnologyTypes>() {
                //
            };
        }

        public override ITechBlock NewInstance() {
            ITechBlock block = new SoapTechBlock();
            block.SetContent(content);
            return block;
        }

    }
}
