using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LabyrintSpill {
    // Class for drawing simple 2D textures
    public class Basic2D {
        public Vector2 pos, dems;
        public Texture2D sprite;

        public Basic2D(string Path, Vector2 Pos, Vector2 Dems) {
            pos = Pos;
            dems = Dems;
            sprite = Globals.content.Load<Texture2D>(Path);
        }

        public virtual void Update() {

        }

        public virtual void Draw(Vector2 OffSet) {
            if(sprite != null) {
                Globals.spriteBatch.Draw(sprite, new Rectangle((int)(pos.X + OffSet.X), (int)(pos.Y + OffSet.Y), (int)(dems.X), (int)(dems.Y)), null, Color.White, 0.0f, new Vector2(sprite.Bounds.Width / 2, sprite.Bounds.Height / 2), new SpriteEffects(), 0);
            }
        }

        public virtual void Draw(Vector2 OffSet, Vector2 Orgin) {
            if (sprite != null) {
                Globals.spriteBatch.Draw(sprite, new Rectangle((int)(pos.X + OffSet.X), (int)(pos.Y + OffSet.Y), (int)(dems.X), (int)(dems.Y)), null, Color.White, 0.0f, new Vector2(Orgin.X, Orgin.Y), new SpriteEffects(), 0);
            }
        }
    }
}
