using GridGame.TechTree.Backend.Technology;
using GridGame.TechTree.Backend.Technology.TechnologyClasses;
using GridGame.TechTree.Visual.TechnologyBlocks.TechBlockClasses;
using GridGame.TechTree.Visual.TechnologyBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridGame.TextureLoading;
using GridGame.Resources;
using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;

namespace GridGame.TechTree.Backend {
    public class NewTechBlock {

        private Dictionary<TechnologyTypes, ITechBlock> TechBlockMap;
        private NewTechnology NewTech;
        private ContentLoader content;

        public NewTechBlock(ContentLoader content, ConstantsController Constants, PlayerResources playerResources) {
            NewTech = new NewTechnology();
            this.content = content;
            TechBlockMap = new Dictionary<TechnologyTypes, ITechBlock>() {
                [TechnologyTypes.BANK] = new BankTechBlock(),
                [TechnologyTypes.FACEMASK] = new FacemaskTechBlock(),
                [TechnologyTypes.FACTORY] = new FactoryTechBlock(),
                [TechnologyTypes.FARM] = new FarmTechBlock(),
                [TechnologyTypes.SOAP] = new SoapTechBlock(),
                [TechnologyTypes.MEDICAL_TENT] = new MedicalTentTechBlock(),
                [TechnologyTypes.HOSPITAL] = new HospitalTechBlock(),
                [TechnologyTypes.LABORATORY] = new LaboratoryTechBlock(),
            };
            foreach(ITechBlock block in TechBlockMap.Values) {
                block.SetContent(content, Constants, playerResources);
            }
        }

        public ITechBlock GetTechnology(TechnologyTypes type) {
            ITechBlock block = TechBlockMap[type].NewInstance();
            block.Technology = NewTech.GetTechnology(type);
            return block;
        }

    }
}
