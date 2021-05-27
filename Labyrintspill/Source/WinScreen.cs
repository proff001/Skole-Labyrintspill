using Microsoft.Xna.Framework;

namespace LabyrintSpill {
    public class WinScreen {
        public Basic2D bkg;
        PassObject changeGameState;
        public Button2D menuButton;

        public WinScreen(PassObject ChangeGameState) {
            changeGameState = ChangeGameState;

            bkg = new Basic2D("2D/Menu/YouWin", new Vector2(Globals.screenWidth/2, Globals.screenHeight/2), new Vector2(Globals.screenWidth, Globals.screenHeight));

            menuButton = new Button2D("2D/Menu/Button", new Vector2(0, 0), new Vector2(180, 60), "Fonts/Arial12", "Menu", changeGameState, 0);
        }

        public virtual void Update() {
            menuButton.Update(new Vector2(120, 360));
        }

        public virtual void Draw() {
            bkg.Draw(Vector2.Zero);
            menuButton.Draw(new Vector2(120, 360));
        }
    }
}