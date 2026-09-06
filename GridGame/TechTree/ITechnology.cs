using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree {
    public interface ITechnology {

        public TechnologyTypes TechType { get; protected set; }
        
        public HashSet<TechnologyTypes> Prerequisites { get; set; }
        public HashSet<ITechnology> NextTechs { get; set; }

        public void SetVisible();
        public void TryUnlock(TechnologyTypes unlockedTech);
        public void TryResearch();

    }
}
