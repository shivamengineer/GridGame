using GridGame.TechTree.Backend.Technology.TechnologyClasses;
using GridGame.TechTree.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridGame.Constants.TechTreeGraph;

namespace GridGame.TechTree.Visual.TechnologyBlocks.TechBlockClasses {
    public class HospitalTechBlock : AbstractTechBlock {

        public HospitalTechBlock() {
            Cost = TechCost.HOSPITAL_COST;
            text = "HOSPITAL";
            NextTechBlocks = new Dictionary<TechnologyTypes, ITechBlock>();
            TechType = TechnologyTypes.HOSPITAL;
            Technology = new HospitalTechnology();
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
            ITechBlock block = new HospitalTechBlock();
            block.SetContent(content);
            return block;
        }

    }
}
