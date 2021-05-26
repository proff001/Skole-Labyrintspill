using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LabyrintSpill{
    public class UI {

        public SpriteFont font;
    
        public UI() {
            font = Globals.content.Load<SpriteFont>("Fonts/Arial12");
        }

        public void Update(World world) {

        }

        public void Draw(World world) {
            string tempString = "Collected Item: " + (world.collectedItem ? "[X]" : "[  ]");
            Vector2 strDims = font.MeasureString(tempString);
            Globals.spriteBatch.DrawString(font, tempString, new Vector2(Globals.screenWidth - 140f, 20f), Color.Black);
        }
    }
}
