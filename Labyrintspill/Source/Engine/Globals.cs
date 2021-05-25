using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LabyrintSpill {
    // Class for global variables i want to use through the code wihout hesetating about accessebility.
    public class Globals {
        public static ContentManager content;
        public static SpriteBatch spriteBatch;
        public static GameTime gameTime;
        public static int screenWidth;
        public static int screenHeight;
    }
}
