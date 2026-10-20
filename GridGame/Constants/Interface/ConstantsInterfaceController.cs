using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Constants.Interface {
    public class ConstantsInterfaceController {

        public Rectangle Background;
        public List<IConstantBlock> ColorConstBlocks;
        public List<IConstantBlock> GameIntConstBlocks;
        public List<IConstantBlock> GameFloatConstBlocks;
        public List<IConstantBlock> UIIntConstBlocks;

        public ConstantsInterfaceController() {
            Initialize();
        }

        private void Initialize() {
            ColorConstBlocks = new List<IConstantBlock>();
            GameIntConstBlocks = new List<IConstantBlock>();
            GameFloatConstBlocks = new List<IConstantBlock>();
            UIIntConstBlocks = new List<IConstantBlock>();
            FillLists();
        }

        private void FillLists() {
            //
        }

    }
}
