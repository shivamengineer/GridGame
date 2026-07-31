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

        private Dictionary<BuildingType, IButton> buildingButtons;

        private Rectangle buttonBackground;
        private Texture2D blankTexture;

        private SpriteFont font;

        public ButtonDisplay(Texture2D blankTexture, SpriteFont font) {
            this.blankTexture = blankTexture;
            this.font = font;

            InitializeBuildingTypes();
            InitializeButtonBackgrounds();

            buttonBackground = new Rectangle(0, GameConstants.WINDOW_HEIGHT - UIOverlayDetails.RESOURCE_BAR_HEIGHT, 
                GameConstants.WINDOW_WIDTH, UIOverlayDetails.RESOURCE_BAR_HEIGHT);
        }

        private void InitializeBuildingTypes() {
            buildingButtons = new Dictionary<BuildingType, IButton> {
                [BuildingType.Farm] = new FarmButton(blankTexture, font),
                [BuildingType.Bank] = new BankButton(blankTexture, font),
                [BuildingType.Hospital] = new HospitalButton(blankTexture, font),
                [BuildingType.Factory] = new FactoryButton(blankTexture, font),
                [BuildingType.Laboratory] = new LaboratoryButton(blankTexture, font),
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

                item.Value.SetPosition(background.X + UIOverlayDetails.RESOURCE_BAR_ITEM_MARGIN_X, y + (UIOverlayDetails.RESOURCE_BAR_ITEM_Y * 2));
                item.Value.SetRect(background);
                index++;
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(blankTexture, buttonBackground, Color.Gray);

            foreach(var button in buildingButtons) {
                button.Value.Draw(spriteBatch);
            }
        }

    }
}
