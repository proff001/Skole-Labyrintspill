using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LabyrintSpill {
    public class GamePlay {
        World world;
        PassObject changeGameState;

        public GamePlay(PassObject ChangeGameState) {
            changeGameState = ChangeGameState;
            ResetWorld(null);
        }

        public virtual void Update() {
            world.Update();
        }

        public virtual void ResetWorld(object Info) {
            world = new World(ResetWorld, changeGameState);
        }

        public virtual void Draw() {
            world.Draw(Vector2.Zero);
        }
    }
}