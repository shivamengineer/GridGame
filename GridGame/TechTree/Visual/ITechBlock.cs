using GridGame.TechTree.Backend;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Visual {
    public interface ITechBlock {

        public ITechnology Technology { get; protected set; }

        public HashSet<TechnologyTypes> Prerequisites { get; set; }
        public HashSet<ITechBlock> NextTechs { get; set; }

        public void SetVisible();
        public void TryUnlock(TechnologyTypes unlockedTech);
        public void TryResearch();

        public void OnClick();

        public void Draw(SpriteBatch spriteBatch);

    }
}
