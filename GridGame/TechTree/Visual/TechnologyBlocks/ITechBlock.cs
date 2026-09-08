using GridGame.TechTree.Backend;
using GridGame.TechTree.Backend.Technology;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.TechTree.Visual.TechnologyBlocks {
    public interface ITechBlock {

        public TechnologyTypes TechType { get; protected set; }
        public int Position { get; protected set; }

        public ITechnology Technology { get; set; }

        public HashSet<TechnologyTypes> Prerequisites { get; protected set; }
        public HashSet<TechnologyTypes> NextTechs { get; protected set; }

        public void InitializeGraph(NewTechBlock newTech);

        public void UpdatePosition(int position);

        public void SetVisible();
        public void TryUnlock(TechnologyTypes unlockedTech);
        public void TryResearch();

        public void OnClick();

        public void Draw(SpriteBatch spriteBatch, int CameraPosition);

        public ITechBlock NewInstance();

    }
}
