using GridGame.Constants;
using GridGame.Constants.TechTreeGraph;
using GridGame.Resources;
using GridGame.TechTree.Backend;
using GridGame.TechTree.Visual.TechnologyBlocks;
using GridGame.TextureLoading;
using GridGame.TextureLoading.TextureEnums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace GridGame.TechTree {
    public class TechnologyController {

        public int CameraX { get; set; }

        private TechProgress TechProgress;
        private HashSet<ITechBlock> TechBlockRoots;
        private List<Dictionary<TechnologyTypes, ITechBlock>> TechBlockPositions;
        private List<Dictionary<TechnologyTypes, ITechBlock>> ActiveBlocks;
        private NewTechBlock NewTech;
        private Texture2D Background;
        private Rectangle destRect;

        private PlayerResources playerResources;

        private int NumBlocks;
        private int FirstBlock;
        private int LastBlock;

        public TechnologyController(ContentLoader content, PlayerResources playerResources) {
            TechProgress = new TechProgress();
            TechBlockPositions = new List<Dictionary<TechnologyTypes, ITechBlock>>();
            NewTech = new NewTechBlock(content, playerResources);
            Background = content.GetTexture(TextureNames.BLANK_RECTANGLE);
            destRect = new Rectangle(0, 0, GameConstants.WINDOW_WIDTH, GameConstants.WINDOW_HEIGHT);

            this.playerResources = playerResources;

            InitializeGraph();
            InitializePositions();
        
            foreach(ITechBlock techBlock in TechBlockRoots) {
                SetBlockPositionsInList(techBlock);
            }

            SetYPositions();
            UpdateCamera();
            ActiveBlocks = GetActiveBlocks();
        }

        private void InitializeGraph() {
            TechBlockRoots = TechTreeStarter.StartingVisibleTechs(NewTech);
            HashSet<TechnologyTypes> AddedBlocks = new HashSet<TechnologyTypes>();
            Queue<ITechBlock> blocks = new Queue<ITechBlock>();
            foreach(ITechBlock block in TechBlockRoots) {
                blocks.Enqueue(block);
                AddedBlocks.Add(block.TechType);
            }
            while(blocks.Count > 0) {
                ITechBlock currentBlock = blocks.Dequeue();
                foreach(TechnologyTypes type in currentBlock.NextTechs) {
                    if(!AddedBlocks.Contains(type)) {
                        ITechBlock nextBlock = NewTech.GetTechnology(type);
                        blocks.Enqueue(nextBlock);
                        AddedBlocks.Add(type);
                        currentBlock.NextTechBlocks.Add(type, nextBlock);
                    }
                }
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

        private void SetYPositions() {
            foreach(var map in TechBlockPositions) {
                int j = 1;
                int count = map.Count + 1;
                foreach(ITechBlock techBlock in map.Values) {
                    techBlock.SetYPosition((float)j / count);
                    j++;
                }
            }
        }

        public void UpdateCamera() {
            NumBlocks = GameConstants.WINDOW_WIDTH / (TechTreeGraph.BLOCK_WIDTH + TechTreeGraph.BLOCK_SPACING);
            FirstBlock = CameraX / (TechTreeGraph.BLOCK_WIDTH + TechTreeGraph.BLOCK_SPACING);
            LastBlock = FirstBlock + NumBlocks;

            if(FirstBlock < 0) FirstBlock = 0;
            if(LastBlock >= TechBlockPositions.Count) LastBlock = TechBlockPositions.Count - 1;

            ActiveBlocks = GetActiveBlocks();
        }

        public List<Dictionary<TechnologyTypes, ITechBlock>> GetActiveBlocks() {
            return TechBlockPositions.GetRange(FirstBlock, LastBlock + 1);
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Background, destRect, Color.LightGray);

            for(int i = 0; i < ActiveBlocks.Count; i++) {
                foreach(ITechBlock techBlock in TechBlockPositions[i].Values) {
                    techBlock.Draw(spriteBatch, CameraX);
                }
            }

        }

    }
}
