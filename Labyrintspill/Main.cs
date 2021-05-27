using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LabyrintSpill {
    public class Main : Game {
        GraphicsDeviceManager graphics;
        
        GamePlay gamePlay;
        MainMenu mainMenu;
        WinScreen winScreen;

        public Main() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            Globals.screenWidth = 1280;
            Globals.screenHeight = 720;

            graphics.PreferredBackBufferWidth = Globals.screenWidth;
            graphics.PreferredBackBufferHeight = Globals.screenHeight;

            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent() {
            Globals.content = this.Content;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

            Globals.mouse = new MouseControl();

            gamePlay = new GamePlay(ChangeGameState);
            winScreen = new WinScreen(ChangeGameState);
            mainMenu = new MainMenu(ChangeGameState, ExitGame);
        }

        protected override void Update(GameTime gameTime) {
            Globals.gameTime = gameTime;

            Globals.keyboardState = Keyboard.GetState();
            Globals.mouse.Update();

            if(Globals.gameState == 0)
                mainMenu.Update();
            else if(Globals.gameState == 1)
                gamePlay.Update();
            else if(Globals.gameState == 2)
                winScreen.Update();

            Globals.mouse.UpdateOld();

            base.Update(gameTime);
        }

        public virtual void ChangeGameState(object Info) {
            Globals.gameState = Convert.ToInt32(Info);
        }

        public virtual void ExitGame(object Info) {
            Exit();
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            // Start drawing texture on screen.
            Globals.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

            if(Globals.gameState == 0)
                mainMenu.Draw();
            else if(Globals.gameState == 1)
                gamePlay.Draw();
            else if(Globals.gameState == 2)
                winScreen.Draw();
            
            Globals.spriteBatch.End();
            // Stop drawing texture on screen.

            base.Draw(gameTime);
        }
    }

    public static class Program {
        [STAThread]
        static void Main() {
            using (var game = new Main())
                game.Run();
        }
    }
}
