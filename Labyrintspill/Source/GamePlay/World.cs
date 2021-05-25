using Microsoft.Xna.Framework;

namespace LabyrintSpill {
    public class World {
        public bool collectedItem;
        public Hero hero;
        public UI ui;
        public World() {
            collectedItem = false;
            hero = new Hero("2D/Player", new Vector2(300, 300), new Vector2(48, 48));
            ui = new UI();
        }

        public virtual void Update() {
            hero.Update();
            ui.Update(this);
        }

        public virtual void Draw(Vector2 OffSet) {
            hero.Draw(OffSet);

            ui.Draw(this);
        }
    }
}
