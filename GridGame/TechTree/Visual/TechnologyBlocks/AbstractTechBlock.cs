using GridGame.Constants;
using GridGame.Constants.TechTreeGraph;
using GridGame.TechTree.Backend;
using GridGame.TechTree.Backend.Technology;
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

namespace GridGame.TechTree.Visual.TechnologyBlocks {
    public abstract class AbstractTechBlock : ITechBlock {

        public TechnologyTypes TechType { get; set; }
        public int Position { get; set; }

        public ITechnology Technology { get; set; }

        public HashSet<TechnologyTypes> Prerequisites { get; set; }
        public HashSet<TechnologyTypes> NextTechs { get; set; }

        public TechnologyStatus TechStatus = new TechnologyStatus();
        public HashSet<TechnologyTypes> ResearchedPrerequisites = new HashSet<TechnologyTypes>();
        public Dictionary<TechnologyTypes, ITechBlock> NextTechBlocks { get; set; }

        public Rectangle Background;
        public Texture2D backgroundTexture;
        public SpriteFont font;

        public string text;

        public int CameraX = 0;

        public ContentLoader content;

        public void SetContent(ContentLoader content) {
            this.content = content;
            backgroundTexture = content.GetTexture(TextureNames.BLANK_RECTANGLE);
            font = content.GetFont(FontNames.ARIAL);
        }

        public void InitializeGraph(NewTechBlock newTechBlock) {
            foreach(TechnologyTypes Type in NextTechs) {
                if(!NextTechBlocks.ContainsKey(Type)) {
                    NextTechBlocks[Type] = newTechBlock.GetTechnology(Type);
                }
                NextTechBlocks[Type].InitializeGraph(newTechBlock);
            }
        }

        public void UpdatePosition(int position) {
            Position = Math.Max(Position, position);
            UpdateNextPosition();
        }

        public void SetYPosition(float position) {
            Background.Y = (int)(position * GameConstants.WINDOW_HEIGHT);
        }

        public void SetVisible() {
            TechStatus.Visible = true;
        }

        public void TryUnlock(TechnologyTypes unlockedTech) {
            if(TechStatus.CanResearch) return;

            if(Prerequisites.Contains(unlockedTech) && !ResearchedPrerequisites.Contains(unlockedTech)) {
                ResearchedPrerequisites.Add(unlockedTech);
            }

            if(ResearchedPrerequisites.Count == Prerequisites.Count) TechStatus.CanResearch = true;
        }

        public void TryResearch() {
            if(TechStatus.CanResearch) TechStatus.Researched = true;
            else return;

            SetNextVisible();
            TryUnlockNextTechs();
        }

        private void UpdateNextPosition() {
            foreach(ITechBlock nextTech in NextTechBlocks.Values) {
                nextTech.UpdatePosition(Position + 1);
            }
        }

        private void SetNextVisible() {
            foreach(ITechBlock nextTech in NextTechBlocks.Values) {
                nextTech.SetVisible();
            }
        }

        private void TryUnlockNextTechs() {
            foreach(ITechBlock nextTech in NextTechBlocks.Values) {
                nextTech.TryUnlock(Technology.TechType);
            }
        }

        public void OnClick() {
            TryResearch();
        }

        public void SetRectangle() {
            Background = new Rectangle(0, Background.Y, TechTreeGraph.BLOCK_WIDTH, TechTreeGraph.BLOCK_HEIGHT);
            UpdatePositionFromCamera();
        }

        public void UpdatePositionFromCamera() {
            Background.X = (Position * (TechTreeGraph.BLOCK_WIDTH + TechTreeGraph.BLOCK_SPACING)) - CameraX;
        }

        public void Draw(SpriteBatch spriteBatch, int CameraPosition) {
            if(CameraX != CameraPosition) {
                CameraX = CameraPosition;
                UpdatePositionFromCamera();
            }

            spriteBatch.Draw(backgroundTexture, Background, Color.Gray);
            if(!TechStatus.Visible) return;
            string drawText = text;
            spriteBatch.DrawString(font, drawText, new Vector2(Background.X + 10, Background.Y), Color.Red);
        }

        public abstract ITechBlock NewInstance();

    }
}
