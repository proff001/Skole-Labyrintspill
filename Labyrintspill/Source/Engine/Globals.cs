using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LabyrintSpill {
    // Class for global variables i want to use through the code wihout hesetating about accessebility.
    
    public delegate void PassObject(object i);

    public class Globals {
        public static int screenWidth, screenHeight, gameState = 0;

        public static PassObject CheckScroll;

        public static ContentManager content;
        public static SpriteBatch spriteBatch;

        public static KeyboardState keyboardState;
        public static MouseControl mouse;

        public static GameTime gameTime;

    }
}
