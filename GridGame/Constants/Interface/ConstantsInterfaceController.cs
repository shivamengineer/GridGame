using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
using GridGame.Constants.Interface.ConstantBlockClasses;
using GridGame.TextureLoading;
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

        private ContentLoader Content;
        private ConstantsController Constants;

        public ConstantsInterfaceController(ContentLoader Content, ConstantsController Constants) {
            this.Content = Content;
            this.Constants = Constants;
            Initialize();
        }

        private void Initialize() {
            FilColorList();
            FillGameIntList();
            FillGameFloatList();
            FillUIIntList();
        }

        private void FilColorList() {
            ColorConstBlocks = new List<IConstantBlock>();
            int i = 0;
            foreach(var constVar in Constants.GetColors()) {
                //
            }
        }

        private void FillGameIntList() {
            GameIntConstBlocks = new List<IConstantBlock>();
            int i = 0;
            foreach(var constVar in Constants.GetGameInts()) {
                //
            }
        }

        private void FillGameFloatList() {
            GameFloatConstBlocks = new List<IConstantBlock>();
            int i = 0;
            foreach(var constVar in Constants.GetGameFloats()) {
                //
            }
        }

        private void FillUIIntList() {
            UIIntConstBlocks = new List<IConstantBlock>();
            int i = 0;
            foreach(var constVar in Constants.GetUIInts()) {
                //
            }
        }

    }
}
