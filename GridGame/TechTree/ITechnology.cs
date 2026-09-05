using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree {
    public interface ITechnology {
        
        public HashSet<ITechnology> Prerequisites { get; set; }
        public HashSet<ITechnology> NextTechs { get; set; }

    }
}
