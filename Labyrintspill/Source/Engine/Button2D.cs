using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LabyrintSpill {
    public class Button2D : Basic2D {
        public bool isPressed, isHovered;
        public string text;
        public SpriteFont font;
        public object info;
        PassObject buttonClicked;

        public Button2D(string Path, Vector2 Pos, Vector2 Dems, string FontPath, string Text, PassObject ButtonClicked, object Info) : base(Path, Pos, Dems) {
            info = Info;
            text = Text;
            buttonClicked = ButtonClicked;

            if(FontPath != "")
                font = Globals.content.Load<SpriteFont>(FontPath);

            isPressed = false;
        }

        public void Update(Vector2 OffSet) {
            if(Hover(OffSet)) {
                isHovered = true;

                if(Globals.mouse.LeftClick()) {
                    isHovered = false;
                    isPressed = true;
                } else if(Globals.mouse.LeftClickRelease()) {
                    if(buttonClicked != null) {
                        buttonClicked(info);
                    }

                    isHovered = false;
                    isPressed = false;
                } else {
                    isHovered = false;   
                }

                if(!Globals.mouse.LeftClick() && !Globals.mouse.LeftClickHold()) {
                    isPressed = false;
                }
            }

            base.Update();
        }

        public override void Draw(Vector2 OffSet, float rot = 0.0f) {
            Color tempColor = Color.White;

            if(isHovered)
                tempColor = Color.Black;
            if(isPressed)
                tempColor = Color.Red;

            base.Draw(OffSet);
            Vector2 strDims = font.MeasureString(text);
            Globals.spriteBatch.DrawString(font, text, pos + OffSet +new Vector2(-strDims.X/2, -strDims.Y/2), tempColor);
        }
    }
}