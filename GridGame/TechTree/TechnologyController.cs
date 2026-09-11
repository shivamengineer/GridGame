using GridGame.TechTree.Backend;
using GridGame.TechTree.Visual.TechnologyBlocks;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree {
    public class TechnologyController {

        private int CameraX;

        private TechProgress TechProgress;
        private HashSet<ITechBlock> TechBlockRoots;
        private List<Dictionary<TechnologyTypes, ITechBlock>> TechBlockPositions;
        private NewTechBlock NewTech;

        public TechnologyController() {
            TechProgress = new TechProgress();
            TechBlockPositions = new List<Dictionary<TechnologyTypes, ITechBlock>>();
            NewTech = new NewTechBlock();
            InitializeGraph();
            InitializePositions();

            foreach(ITechBlock techBlock in TechBlockRoots) {
                SetBlockPositionsInList(techBlock);
            }
        }

        private void InitializeGraph() {
            TechBlockRoots = TechTreeStarter.StartingVisibleTechs(NewTech);
            foreach(ITechBlock techBlock in TechBlockRoots) {
                techBlock.InitializeGraph(NewTech);
            }
        }

        private void InitializePositions() {
            foreach(ITechBlock techBlock in TechBlockRoots) {
                techBlock.UpdatePosition(0);
            }
        }

        private void SetBlockPositionsInList(ITechBlock techBlock) {
            int position = techBlock.Position;
            if(position >= TechBlockPositions.Count) {
                TechBlockPositions.Add(new Dictionary<TechnologyTypes, ITechBlock>());
            }
            if(!TechBlockPositions[position].ContainsKey(techBlock.TechType)) {
                TechBlockPositions[position].Add(techBlock.TechType, techBlock);
            }

            foreach(ITechBlock nextBlock in techBlock.NextTechBlocks.Values) {
                SetBlockPositionsInList(nextBlock);
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            //
        }

    }
}
