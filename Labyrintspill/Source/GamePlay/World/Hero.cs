using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LabyrintSpill {
    public class Hero : Basic2D {
        public float speed;
        public Basic2D blinder;

        public Hero(string Path, Vector2 Pos, Vector2 Dems) : base(Path, Pos, Dems) {
            blinder = new Basic2D("2D/Blinder", pos, new Vector2(Globals.screenWidth + 100, Globals.screenHeight + 100));
            speed = 2.0f;
        }

        public void Update(Vector2 OffSet, Map map, PassObject changeGameState, PassObject resetWorld) {
            Vector2 oldPos = pos;

            if(Globals.keyboardState.IsKeyDown(Keys.A))
                pos = new Vector2(pos.X - speed, pos.Y);
            if(Globals.keyboardState.IsKeyDown(Keys.D))
                pos = new Vector2(pos.X + speed, pos.Y);
            if(Globals.keyboardState.IsKeyDown(Keys.W))
                pos = new Vector2(pos.X, pos.Y - speed);
            if(Globals.keyboardState.IsKeyDown(Keys.S))
                pos = new Vector2(pos.X, pos.Y + speed);

            if(map.IsColliding(pos))
                pos = oldPos;

            if(map.IsColliding(pos, true)) {
                changeGameState(0);
                resetWorld(null);
            }

            if(oldPos != pos)
                Globals.CheckScroll(pos);

            blinder.pos = pos;
            base.Update();
        }
    }
}
