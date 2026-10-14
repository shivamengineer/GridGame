using GridGame.Constants;
using GridGame.Constants.Controller;
using GridGame.Constants.Controller.ConstantsEnums;
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

        public ButtonDisplay(Texture2D blankTexture, SpriteFont font, ConstantsController Constants) {
            this.blankTexture = blankTexture;
            this.font = font;

            Dictionary<ConstUserInterface, int> UIInts = Constants.ConstantsFiles[ConstantTypes.USER_INTERFACE].GetUIInts();

            InitializeBuildingTypes();
            InitializeButtonBackgrounds(Constants, UIInts);

            buttonBackground = new Rectangle(0, UIInts[ConstUserInterface.WindowHeight] - UIInts[ConstUserInterface.ResourcesOverlayHeight],
                UIInts[ConstUserInterface.WindowWidth], UIInts[ConstUserInterface.ResourcesOverlayHeight]);
        }

        private void InitializeBuildingTypes() {
            buildingButtons = new Dictionary<BuildingType, IButton> {
                [BuildingType.CityCenter] = new CityCenterButton(blankTexture, font),
                [BuildingType.Farm] = new FarmButton(blankTexture, font),
                [BuildingType.Bank] = new BankButton(blankTexture, font),
                [BuildingType.Hospital] = new HospitalButton(blankTexture, font),
                [BuildingType.Factory] = new FactoryButton(blankTexture, font),
                [BuildingType.Laboratory] = new LaboratoryButton(blankTexture, font),
            };
        }

        private void InitializeButtonBackgrounds(ConstantsController Constants, Dictionary<ConstUserInterface, int> UIInts) {
            int index = 0;
            int spacing = UIInts[ConstUserInterface.WindowWidth] / buildingButtons.Count;

            int height = UIInts[ConstUserInterface.ResourcesOverlayHeight] - (2 * UIInts[ConstUserInterface.ResourcesOverlayElementY]);
            int y = UIInts[ConstUserInterface.WindowHeight] - height - UIInts[ConstUserInterface.ResourcesOverlayElementY];

            foreach(var item in buildingButtons) {
                Rectangle background = new Rectangle((spacing * index) + UIInts[ConstUserInterface.ResourcesOverlayElementMarginX], y,
                    spacing - (2 * UIInts[ConstUserInterface.ResourcesOverlayElementMarginX]), height);

                item.Value.SetColors(Constants);
                item.Value.SetPosition(background.X + UIInts[ConstUserInterface.ResourcesOverlayElementMarginX], y + (UIInts[ConstUserInterface.ResourcesOverlayElementY] * 2));
                item.Value.SetRect(background);
                index++;
            }
        }

        public bool MouseOnDisplay(Point point) {
            return buttonBackground.Contains(point);
        }

        public IButton GetSelectedButton(Point point) {
            foreach(var item in buildingButtons) {
                if(item.Value.GetRect().Contains(point)) {
                    return item.Value;
                }
            }
            return null;
        }

        public IButton GetButton(BuildingType type) {
            return buildingButtons[type];
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(blankTexture, buttonBackground, Color.Gray);

            foreach(var button in buildingButtons) {
                button.Value.Draw(spriteBatch);
            }
        }

    }
}
