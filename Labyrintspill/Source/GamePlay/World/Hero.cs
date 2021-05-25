using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LabyrintSpill {
    public class Hero : Basic2D {
        public float speed;
        public Hero(string Path, Vector2 Pos, Vector2 Dems) : base(Path, Pos, Dems) {
            speed = 2.0f;
        }

        public override void Update() {
            KeyboardState state = Keyboard.GetState();

            if(state.IsKeyDown(Keys.A))
                pos = new Vector2(pos.X - speed, pos.Y);
            if(state.IsKeyDown(Keys.D))
                pos = new Vector2(pos.X + speed, pos.Y);
            if(state.IsKeyDown(Keys.W))
                pos = new Vector2(pos.X, pos.Y - speed);
            if(state.IsKeyDown(Keys.S))
                pos = new Vector2(pos.X, pos.Y + speed);

            base.Update();
        }

        public override void Draw(Vector2 OffSet) {
            base.Draw(OffSet);
        }
    }
}
