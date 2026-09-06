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

        public TechnologyStatus TechStatus;
        public HashSet<TechnologyTypes> ResearchedPrerequisites = new HashSet<TechnologyTypes>();

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
