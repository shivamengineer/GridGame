using GridGame.TechTree.Backend;
using GridGame.TechTree.Backend.Technology;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Visual {
    public abstract class AbstractTechBlock : ITechBlock {

        public TechnologyTypes TechType { get; set; }
        public int Position { get; set; }

        public ITechnology Technology { get; set; }

        public HashSet<TechnologyTypes> Prerequisites { get; set; }
        public HashSet<ITechBlock> NextTechs { get; set; }

        public TechnologyStatus TechStatus;
        public HashSet<TechnologyTypes> ResearchedPrerequisites = new HashSet<TechnologyTypes>();

        public Rectangle Background;

        public void UpdatePosition(int position) {
            Position = Math.Max(Position, position);
            UpdateNextPosition();
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
            foreach(ITechBlock nextTech in NextTechs) {
                nextTech.UpdatePosition(Position + 1);
            }
        }

        private void SetNextVisible() {
            foreach(ITechBlock nextTech in NextTechs) {
                nextTech.SetVisible();
            }
        }

        private void TryUnlockNextTechs() {
            foreach(ITechBlock nextTech in NextTechs) {
                nextTech.TryUnlock(Technology.TechType);
            }
        }

        public void OnClick() {
            TryResearch();
        }

        public abstract void Draw(SpriteBatch spriteBatch);

    }
}
