using Labyrintspill.Sprites;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrintspill.Core {
    public class Camera {
        public Matrix Transform { get; private set; }

        public void Follow(Sprite target) {
            var position = Matrix.CreateTranslation(
              -target.Position.X - (target.Rectangle.Width / 2),
              -target.Position.Y - (target.Rectangle.Height / 2),
              0);

            var offset = Matrix.CreateTranslation(
                GameMain.ScreenWidth / 2,
                GameMain.ScreenHeight / 2,
                0);

            Transform = position * offset;
        }
    }
}
