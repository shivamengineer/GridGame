using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Backend.Technology {
    public interface ITechnology {

        public TechnologyTypes TechType { get; protected set; }

        public HashSet<TechnologyTypes> Prerequisites { get; protected set; }
        public HashSet<ITechnology> NextTechs { get; protected set; }

        public ITechnology NewInstance();

    }
}
