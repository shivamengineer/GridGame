using GridGame.TechTree.Backend;
using GridGame.TechTree.Backend.Technology.TechnologyClasses;
using GridGame.TechTree.Visual.TechnologyBlocks;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Visual.TechnologyBlocks.TechBlockClasses {
    public class FacemaskTechBlock : AbstractTechBlock {

        public FacemaskTechBlock() {
            TechType = TechnologyTypes.FACEMASK;
            Technology = new FacemaskTechnology();
            InitializeConnectedTechBlocks();

        }

        private void InitializeConnectedTechBlocks() {
            Prerequisites = new HashSet<TechnologyTypes>() {
                //
            };
            NextTechs = new HashSet<TechnologyTypes>() {
                //
            };
        }



        public override void Draw(SpriteBatch spriteBatch) {
            //
        }

        public override ITechBlock NewInstance() {
            return new FacemaskTechBlock();
        }

    }
}
