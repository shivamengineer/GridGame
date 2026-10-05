using GridGame.Constants;
using GridGame.Constants.TechTreeGraph;
using GridGame.Resources;
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
using System.Windows.Forms.VisualStyles;

namespace GridGame.TechTree.Visual.TechnologyBlocks {
    public abstract class AbstractTechBlock : ITechBlock {

        public TechnologyTypes TechType { get; set; }
        public Rectangle Background { get; set; }
        public int Position { get; set; }

        public ITechnology Technology { get; set; }

        public HashSet<TechnologyTypes> Prerequisites { get; set; }
        public HashSet<TechnologyTypes> NextTechs { get; set; }

        public TechnologyStatus TechStatus = new TechnologyStatus();
        public HashSet<TechnologyTypes> ResearchedPrerequisites = new HashSet<TechnologyTypes>();
        public Dictionary<TechnologyTypes, ITechBlock> NextTechBlocks { get; set; }

        public Texture2D backgroundTexture;
        public SpriteFont font;

        public Color BackgroundColor = Color.Gray;

        public string text;

        public int CameraX = 0;

        public ContentLoader content;

        public PlayerResources playerResources;
        public int Cost;

        public void SetContent(ContentLoader content, PlayerResources playerResources) {
            this.content = content;
            this.playerResources = playerResources;
            backgroundTexture = content.GetTexture(TextureNames.BLANK_RECTANGLE);
            font = content.GetFont(FontNames.ARIAL);
            TechStatus.Visible = true;
        }

        public void UpdatePosition(int position) {
            Position = Math.Max(Position, position);
            UpdatePositionFromCamera();
        }

        public void SetVisible() {
            TechStatus.Visible = true;
        }

        public void Unlock() {
            TechStatus.CanResearch = true;
            BackgroundColor = Color.LightBlue;
        }

        public void TryUnlock(TechnologyTypes unlockedTech) {
            if(Prerequisites.Contains(unlockedTech) && !ResearchedPrerequisites.Contains(unlockedTech)) {
                ResearchedPrerequisites.Add(unlockedTech);
            }

            if(ResearchedPrerequisites.Count == Prerequisites.Count) {
                TechStatus.CanResearch = true;
                BackgroundColor = Color.LightBlue;
            }
        }

        public bool TryResearch() {
            if(!TechStatus.CanResearch || !playerResources.TrySubtractResource(ResourceType.Science, Cost)) return false;

            TechStatus.Researched = true;

            BackgroundColor = Color.LightSeaGreen;

            SetNextVisible();
            TryUnlockNextTechs();
            return true;
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

        private void SetBackgroundPos(int x, int y) {
            Background = new Rectangle(x, y, Background.Width, Background.Height);
        }

        public void SetYPosition(float position) {
            SetBackgroundPos(Background.X, (int)(position * GameConstants.WINDOW_HEIGHT));
        }

        public void UpdatePositionFromCamera() {
            SetBackgroundPos(TechTreeGraph.BLOCK_SPACING + (Position * (TechTreeGraph.BLOCK_WIDTH + TechTreeGraph.BLOCK_SPACING)) - CameraX, Background.Y);
        }

        public void Draw(SpriteBatch spriteBatch, int CameraPosition) {
            if(CameraX != CameraPosition) {
                CameraX = CameraPosition;
                UpdatePositionFromCamera();
            }

            spriteBatch.Draw(backgroundTexture, Background, BackgroundColor);
            if(!TechStatus.Visible) return;
            string drawText = Cost + "S | " + text;
            spriteBatch.DrawString(font, drawText, new Vector2(Background.X + 10, Background.Y + 10), Color.Red);
        }

        public abstract ITechBlock NewInstance();

    }
}
