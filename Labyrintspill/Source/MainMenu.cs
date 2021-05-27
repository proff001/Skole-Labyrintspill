using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace LabyrintSpill {
    public class MainMenu {
        public Basic2D bkg;
        public PassObject playClick, exitClick;
        public List<Button2D> buttons = new List<Button2D>();

        public MainMenu(PassObject PlayClick, PassObject ExitClick) {
            playClick = PlayClick;
            exitClick = ExitClick;

            bkg = new Basic2D("2D/Menu/Background", new Vector2(Globals.screenWidth/2, Globals.screenHeight/2), new Vector2(Globals.screenWidth, Globals.screenHeight));

            buttons.Add(new Button2D("2D/Menu/Button", new Vector2(0, 0), new Vector2(120, 30), "Fonts/Arial12", "Play", playClick, 1));
            buttons.Add(new Button2D("2D/Menu/Button", new Vector2(0, 0), new Vector2(120, 30), "Fonts/Arial12", "Exit", exitClick, 0));
        }

        public virtual void Update() {
            for(int i = 0; i < buttons.Count; i++) {
                buttons[i].Update(new Vector2(120, 399 + 45 * i));
            }
        }

        public virtual void Draw() {
            bkg.Draw(Vector2.Zero);

            for(int i = 0; i < buttons.Count; i++) {
                buttons[i].Draw(new Vector2(120, 399 + 45 * i));
            }
        }
    }
}