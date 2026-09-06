using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree {
    public abstract class AbstractTechnology : ITechnology {

        public TechnologyTypes TechType { get; set; }

        public HashSet<TechnologyTypes> Prerequisites { get; set; }
        public HashSet<ITechnology> NextTechs { get; set; }

        public bool Visible = false;
        public bool CanResearch = false;
        public bool Researched = false;
        public HashSet<TechnologyTypes> ResearchedPrerequisites = new HashSet<TechnologyTypes>();

        public void SetVisible() {
            Visible = true;
        }

        public void TryUnlock(TechnologyTypes unlockedTech) {
            if(CanResearch) return;

            if(Prerequisites.Contains(unlockedTech) && !ResearchedPrerequisites.Contains(unlockedTech)) {
                ResearchedPrerequisites.Add(unlockedTech);
            }

            if(ResearchedPrerequisites.Count == Prerequisites.Count) CanResearch = true;
        }

        public void TryResearch() {
            if(CanResearch) Researched = true;
            else return;

            SetNextVisible();
            TryUnlockNextTechs();
        }

        private void SetNextVisible() {
            foreach(ITechnology nextTech in NextTechs) {
                nextTech.SetVisible();
            }
        }

        private void TryUnlockNextTechs() {
            foreach(ITechnology nextTech in NextTechs) {
                nextTech.TryUnlock(TechType);
            }
        }

    }
}
