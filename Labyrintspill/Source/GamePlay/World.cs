using Microsoft.Xna.Framework;

namespace LabyrintSpill {
    public class World {
        public bool collectedItem;
        public Hero hero;
        public UI ui;
        public Vector2 offSet;
        public World() {
            collectedItem = true;
            hero = new Hero("2D/Player", new Vector2(300, 300), new Vector2(48, 48));
            ui = new UI();
            Globals.CheckScroll = CheckScroll;
        }

        public virtual void Update() {
            hero.Update();
            ui.Update(this);
        }

        public virtual void CheckScroll(object Info) {
            Vector2 tempPos = (Vector2)(Info);
            if(tempPos.X < -offSet.X + (Globals.screenWidth * .4f)) {
                offSet = new Vector2(offSet.X + hero.speed * 2, offSet.Y);
            }

            if(tempPos.X > -offSet.X + (Globals.screenWidth * .6f)) {
                offSet = new Vector2(offSet.X - hero.speed * 2, offSet.Y);
            }

            if(tempPos.Y < -offSet.Y + (Globals.screenHeight* .4f)) {
                offSet = new Vector2(offSet.X, offSet.Y + hero.speed * 2);
            }

            if(tempPos.Y > -offSet.Y + (Globals.screenHeight * .6f)) {
                offSet = new Vector2(offSet.X, offSet.Y - hero.speed * 2);
            }
        }

        public virtual void Draw(Vector2 OffSet) {
            hero.Draw(OffSet);

            ui.Draw(this);
        }
    }
}
