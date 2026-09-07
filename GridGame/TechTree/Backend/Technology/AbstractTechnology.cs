using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Backend.Technology {
    public abstract class AbstractTechnology : ITechnology {

        public TechnologyTypes TechType { get; set; }

        public HashSet<TechnologyTypes> Prerequisites { get; set; }
        public HashSet<ITechnology> NextTechs { get; set; }

        public abstract ITechnology NewInstance();

    }
}
