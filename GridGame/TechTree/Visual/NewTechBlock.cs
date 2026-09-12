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

namespace GridGame.TechTree.Backend {
    public class NewTechBlock {

        private Dictionary<TechnologyTypes, ITechBlock> TechBlockMap;
        private NewTechnology NewTech;
        private ContentLoader content;

        public NewTechBlock(ContentLoader content) {
            NewTech = new NewTechnology();
            this.content = content;
            TechBlockMap = new Dictionary<TechnologyTypes, ITechBlock>() {
                [TechnologyTypes.FACEMASK] = new FacemaskTechBlock(),
                [TechnologyTypes.SOAP] = new SoapTechBlock(),

            };
            foreach(ITechBlock block in TechBlockMap.Values) {
                block.SetContent(content);
            }
        }

        public ITechBlock GetTechnology(TechnologyTypes type) {
            ITechBlock block = TechBlockMap[type].NewInstance();
            block.Technology = NewTech.GetTechnology(type);
            return block;
        }

    }
}
