using GridGame.Constants;
using GridGame.Tiles.Buildings;
using GridGame.UI.Button;
using GridGame.UI.Elements.Buttons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame.UI.Overlay.SelectActions {
    public class ButtonDisplay {

        private List<Rectangle> buildingButtonBackgrounds;
        private Dictionary<BuildingType, IButton> buildingButtons;

        private Rectangle buttonBackground;
        private Texture2D blankTexture;

        private SpriteFont font;

        public ButtonDisplay(Texture2D blankTexture, SpriteFont font) {
            this.blankTexture = blankTexture;
            this.font = font;

            buildingButtonBackgrounds = new List<Rectangle>();
            InitializeBuildingTypes();
            InitializeButtonBackgrounds();

            buttonBackground = new Rectangle(0, GameConstants.WINDOW_HEIGHT - UIOverlayDetails.RESOURCE_BAR_HEIGHT, 
                GameConstants.WINDOW_WIDTH, UIOverlayDetails.RESOURCE_BAR_HEIGHT);
        }

        private void InitializeBuildingTypes() {
            buildingButtons = new Dictionary<BuildingType, IButton> {
                [BuildingType.Farm] = new FarmButton(),
                [BuildingType.Bank] = new BankButton(),
                [BuildingType.Hospital] = new HospitalButton(),
                [BuildingType.Factory] = new FactoryButton(),
                [BuildingType.Laboratory] = new LaboratoryButton(),
            };
        }

        private void InitializeButtonBackgrounds() {
            int index = 0;
            int spacing = GameConstants.WINDOW_WIDTH / buildingButtons.Count;

            int height = UIOverlayDetails.RESOURCE_BAR_HEIGHT - (2 * UIOverlayDetails.RESOURCE_BAR_ITEM_Y);
            int y = GameConstants.WINDOW_HEIGHT - height - UIOverlayDetails.RESOURCE_BAR_ITEM_Y;

            foreach(var item in buildingButtons) {
                Rectangle background = new Rectangle((spacing * index) + UIOverlayDetails.RESOURCE_BAR_ITEM_MARGIN_X, y,
                    spacing - (2 * UIOverlayDetails.RESOURCE_BAR_ITEM_MARGIN_X), height);
                buildingButtonBackgrounds.Add(background);
                //buildingButtons.
                index++;
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(blankTexture, buttonBackground, Color.Gray);

            foreach(var rect in buildingButtonBackgrounds) {
                spriteBatch.Draw(blankTexture, rect, Color.LightGray);
            }
        }

    }
}
