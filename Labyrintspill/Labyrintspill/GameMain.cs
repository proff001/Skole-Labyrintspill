using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.ViewportAdapters;

namespace Labyrintspill {
    public class GameMain : Game {

        // Definerer forskjelige variabler med spesifike typer.
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private TiledMap map;
        private TiledMapRenderer mapRenderer;
        private ViewportAdapter viewportAdapter;
        private OrthographicCamera cam;
        private Vector2 camPos;

        // Hovedfunksjonen som blir kjørt av Program.cs
        public GameMain() {
            // Kode som følger med MonoGame Templaten
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        private Vector2 GetMovementDirection(KeyboardState keyStates) {
            var movementDirection = Vector2.Zero;
            if (keyStates.IsKeyDown(Keys.S)) {
                movementDirection += Vector2.UnitY;
            }
            if (keyStates.IsKeyDown(Keys.W)) {
                movementDirection -= Vector2.UnitY;
            }
            if (keyStates.IsKeyDown(Keys.A)) {
                movementDirection -= Vector2.UnitX;
            }
            if (keyStates.IsKeyDown(Keys.D)) {
                movementDirection += Vector2.UnitX;
            }

            // Can't normalize the zero vector so test for it before normalizing
            if (movementDirection != Vector2.Zero) {
                movementDirection.Normalize();
            }

            return movementDirection;
        }

        private void MoveCamera(GameTime gameTime, KeyboardState keyStates) {
            var speed = 200f;
            var seconds = gameTime.GetElapsedSeconds();
            var movementDirection = GetMovementDirection(keyStates);
            camPos += speed * movementDirection * seconds;
        }

        protected override void Initialize() {
            viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, 800, 600);
            cam = new OrthographicCamera(viewportAdapter);

            Window.AllowUserResizing = true;
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent() {
            map = Content.Load<TiledMap>("map");
            mapRenderer = new TiledMapRenderer(GraphicsDevice, map);
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime) {
            var keyStates = Keyboard.GetState();

            if (keyStates.IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            MoveCamera(gameTime, keyStates);
            cam.LookAt(camPos);

            mapRenderer.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.DimGray);

            // TODO: Add your drawing code here

            GraphicsDevice.BlendState = BlendState.AlphaBlend;
            GraphicsDevice.SamplerStates[0] = SamplerState.PointClamp;
            GraphicsDevice.RasterizerState = RasterizerState.CullNone;

            var viewMatrix = cam.GetViewMatrix();
            var projectionMatrix = Matrix.CreateOrthographicOffCenter(0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, 0, 0f, -1f);

            mapRenderer.Draw(ref viewMatrix, ref projectionMatrix, null);
            
            base.Draw(gameTime);
        }
    }
}
