using GridGame.TechTree.Backend;
using GridGame.TechTree.Backend.Technology.TechnologyClasses;
using GridGame.TechTree.Visual.TechnologyBlocks;
using GridGame.TextureLoading;
using GridGame.TextureLoading.TextureEnums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Taskbar;

namespace GridGame.TechTree.Visual.TechnologyBlocks.TechBlockClasses {
    public class FacemaskTechBlock : AbstractTechBlock {

        public FacemaskTechBlock() {
            text = "FACEMASK";
            NextTechBlocks = new Dictionary<TechnologyTypes, ITechBlock>();
            TechType = TechnologyTypes.FACEMASK;
            Technology = new FacemaskTechnology();
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
            ITechBlock block = new FacemaskTechBlock();
            block.SetContent(content);
            return block;
        }

    }
}
