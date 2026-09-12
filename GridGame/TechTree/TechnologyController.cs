using GridGame.Constants;
using GridGame.Constants.TechTreeGraph;
using GridGame.TechTree.Backend;
using GridGame.TechTree.Visual.TechnologyBlocks;
using GridGame.TextureLoading;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace GridGame.TechTree {
    public class TechnologyController {

        private int CameraX;

        private TechProgress TechProgress;
        private HashSet<ITechBlock> TechBlockRoots;
        private List<Dictionary<TechnologyTypes, ITechBlock>> TechBlockPositions;
        private NewTechBlock NewTech;

        public TechnologyController(ContentLoader content) {
            TechProgress = new TechProgress();
            TechBlockPositions = new List<Dictionary<TechnologyTypes, ITechBlock>>();
            NewTech = new NewTechBlock(content);
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
            int numX = GameConstants.WINDOW_WIDTH / (TechTreeGraph.BLOCK_WIDTH + TechTreeGraph.BLOCK_SPACING);
            int pos = CameraX / (TechTreeGraph.BLOCK_WIDTH + TechTreeGraph.BLOCK_SPACING);
            int endPos = numX;

            for(int i = pos; i < endPos; i++) {
                foreach(ITechBlock techBlock in TechBlockPositions[i].Values) {
                    techBlock.Draw(spriteBatch, CameraX);
                }
            }
        }

    }
}
