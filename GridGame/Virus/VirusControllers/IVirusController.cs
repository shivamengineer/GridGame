using GridGame.Virus.BaseVirus;
using Microsoft.Xna.Framework;
using SharpDX.XAudio2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.Virus.VirusControllers {
    public interface IVirusController {

        public void InitialInfect();

        public InfectType GetInfectType();

        public void Update(GameTime gameTime);

    }
}
