using GridGame.TechTree.Backend;
using GridGame.TechTree.Backend.Technology.TechnologyClasses;
using GridGame.TechTree.Visual.TechnologyBlocks;
using GridGame.TextureLoading;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Visual.TechnologyBlocks.TechBlockClasses {
    public class FacemaskTechBlock : AbstractTechBlock {

        private ContentLoader content;

        public FacemaskTechBlock(ContentLoader content) {
            this.content = content;
            NextTechBlocks = new Dictionary<TechnologyTypes, ITechBlock>();
            TechType = TechnologyTypes.FACEMASK;
            Technology = new FacemaskTechnology();
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



        public override void Draw(SpriteBatch spriteBatch, int CameraPosition) {
            if(CameraX != CameraPosition) {
                CameraX = CameraPosition;
                UpdatePositionFromCamera();
            }
            //
        }

        public override ITechBlock NewInstance() {
            return new FacemaskTechBlock(content);
        }

    }
}
