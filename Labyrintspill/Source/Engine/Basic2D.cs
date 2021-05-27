using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LabyrintSpill {
    // Class for drawing simple 2D textures
    public class Basic2D {
        public Vector2 pos, dims;
        public Texture2D sprite;

        public Basic2D(string Path, Vector2 Pos, Vector2 Dims) {
            pos = new Vector2(Pos.X, Pos.Y);
            dims = new Vector2(Dims.X, Dims.Y);;
            sprite = Globals.content.Load<Texture2D>(Path);
        }

        public virtual void Update() {

        }

        public virtual bool Hover(Vector2 OffSet) {
            Vector2 mousePos = new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y);
            return (mousePos.X >= (pos.X + OffSet.X) - dims.X / 2 && mousePos.X <= (pos.X + OffSet.X) + dims.X / 2 && mousePos.Y >= (pos.Y + OffSet.Y) - dims.Y / 2 && mousePos.Y <= (pos.Y + OffSet.Y) + dims.Y / 2);
        }

        public virtual void Draw(Vector2 OffSet, float rot = 0.0f) {
            if(sprite != null) {
                Globals.spriteBatch.Draw(sprite, new Rectangle((int)(pos.X + OffSet.X), (int)(pos.Y + OffSet.Y), (int)(dims.X), (int)(dims.Y)), null, Color.White, rot, new Vector2(sprite.Bounds.Width / 2, sprite.Bounds.Height / 2), new SpriteEffects(), 0);
            }
        }

        public virtual void Draw(Vector2 OffSet, Vector2 Orgin, Color Color, float rot = 0.0f) {
            if (sprite != null) {
                Globals.spriteBatch.Draw(sprite, new Rectangle((int)(pos.X + OffSet.X), (int)(pos.Y + OffSet.Y), (int)(dims.X), (int)(dims.Y)), null, Color, rot, new Vector2(Orgin.X, Orgin.Y), new SpriteEffects(), 0);
            }
        }
    }
}
