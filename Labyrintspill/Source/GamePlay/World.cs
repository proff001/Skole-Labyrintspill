using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LabyrintSpill {
    public class World {
        public Vector2 offSet = new Vector2(0, 0);
        public UI ui;

        public Hero hero;
        
        public bool collectedItem = false;

        Map map;
        
        PassObject resetWorld, changeGameState;
        
        public World(PassObject ResetWorld, PassObject ChangeGameState) {
            resetWorld = ResetWorld;
            changeGameState = ChangeGameState;

            collectedItem = true;
            hero = new Hero("2D/Player", new Vector2(664, 384), new Vector2(64, 64));
            ui = new UI();
            map = new Map();

            Globals.CheckScroll = CheckScroll;
        }

        public virtual void Update() {
            if (Globals.keyboardState.IsKeyDown(Keys.E))
                collectedItem = !collectedItem;

            if (Globals.keyboardState.IsKeyDown(Keys.Escape)) {
                changeGameState(0);
                resetWorld(null);
            }

            hero.Update(offSet, map, changeGameState, resetWorld);
            ui.Update(this);
        }

        public virtual void CheckScroll(object Info) {
            Vector2 tempPos = (Vector2)Info;

            if(tempPos.X < -offSet.X + (Globals.screenWidth * .48f))
                offSet = new Vector2(offSet.X + hero.speed, offSet.Y);
            if(tempPos.X > -offSet.X + (Globals.screenWidth * .52f))
                offSet = new Vector2(offSet.X - hero.speed, offSet.Y);
            if(tempPos.Y < -offSet.Y + (Globals.screenHeight * .48f))
                offSet = new Vector2(offSet.X, offSet.Y + hero.speed);
            if(tempPos.Y > -offSet.Y + (Globals.screenHeight * .52f))
                offSet = new Vector2(offSet.X, offSet.Y - hero.speed);
        }

        public virtual void Draw(Vector2 OffSet) {
            map.Draw(offSet);
            hero.Draw(offSet);
            hero.blinder.Draw(offSet);
            ui.Draw(this);
        }
    }
}
