using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.BaseVirus {
    public interface IVirus {

        public float CitizenStrength();

        public bool IsAsymptomatic();

        public void Update(GameTime gameTime);

        public void UpdateEvent();

    }
}
