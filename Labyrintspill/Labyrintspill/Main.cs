using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Labyrintspill.Classes;

namespace Labyrintspill {
    public class Main : Game {
        Texture2D bg;
        Vector2 bgPos;
        Texture2D thonk;
        Vector2 thonkPos;
        float thonkSpeed;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        public Main() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here

            thonkPos = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
            thonkSpeed = 200f;

            base.Initialize();
        }

        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            bg = Content.Load<Texture2D>("bg");
            thonk = Content.Load<Texture2D>("thonk");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            var kState = Keyboard.GetState();

            if (kState.IsKeyDown(Keys.Up))
                bgPos.Y += thonkSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kState.IsKeyDown(Keys.Down))
                bgPos.Y -= thonkSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kState.IsKeyDown(Keys.Left))
                bgPos.X += thonkSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kState.IsKeyDown(Keys.Right))
                bgPos.X -= thonkSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (bgPos.X > graphics.PreferredBackBufferWidth - thonk.Width / 2)
                bgPos.X = graphics.PreferredBackBufferWidth - thonk.Width / 2;

            else if (bgPos.X < thonk.Width / 2)
                bgPos.X = thonk.Width / 2;

            if (bgPos.Y > graphics.PreferredBackBufferHeight - thonk.Width / 2)
                bgPos.Y = graphics.PreferredBackBufferHeight - thonk.Width / 2;

            else if (bgPos.Y < thonk.Height / 2)
                bgPos.Y = thonk.Height / 2;


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(bg, bgPos, null, Color.White, 0f, new Vector2(bg.Width / 2, bg.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            spriteBatch.Draw(thonk, thonkPos, null, Color.White, 0f, new Vector2(thonk.Width / 2, thonk.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
