using GridGame.TechTree.Backend.Technology.TechnologyClasses;
using GridGame.TechTree.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Visual.TechnologyBlocks.TechBlockClasses {
    public class MedicalTentTechBlock : AbstractTechBlock {

        public MedicalTentTechBlock() {
            text = "MEDICAL TENT";
            NextTechBlocks = new Dictionary<TechnologyTypes, ITechBlock>();
            TechType = TechnologyTypes.MEDICAL_TENT;
            Technology = new MedicalTentTechnology();
            InitializeConnectedTechBlocks();
            SetRectangle();
        }

        private void InitializeConnectedTechBlocks() {
            Prerequisites = new HashSet<TechnologyTypes>() {
                //
            };
            NextTechs = new HashSet<TechnologyTypes>() {
                TechnologyTypes.HOSPITAL,
                TechnologyTypes.SOAP,
                TechnologyTypes.FACEMASK,
            };
        }

        public override ITechBlock NewInstance() {
            ITechBlock block = new MedicalTentTechBlock();
            block.SetContent(content);
            return block;
        }

    }
}
