using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.ViewportAdapters;

namespace Labyrintspill {
    public class Game1 : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private TiledMap _map;
        private TiledMapRenderer _mapRenderer;

        private OrthographicCamera _cam;
        private Vector2 _camPos;

        public Game1() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        private Vector2 GetMovementDirection() {
            var movementDirection = Vector2.Zero;
            var state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.S)) {
                movementDirection += Vector2.UnitY;
            }
            if (state.IsKeyDown(Keys.W)) {
                movementDirection -= Vector2.UnitY;
            }
            if (state.IsKeyDown(Keys.A)) {
                movementDirection -= Vector2.UnitX;
            }
            if (state.IsKeyDown(Keys.D)) {
                movementDirection += Vector2.UnitX;
            }

            // Can't normalize the zero vector so test for it before normalizing
            if (movementDirection != Vector2.Zero) {
                movementDirection.Normalize();
            }

            return movementDirection;
        }

        private void MoveCamera(GameTime gameTime) {
            var speed = 200;
            var seconds = gameTime.GetElapsedSeconds();
            var movementDirection = GetMovementDirection();
            _camPos += speed * movementDirection * seconds;
        }

        protected override void Initialize() {
            var viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, 800, 600);
            _cam = new OrthographicCamera(viewportAdapter);

            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent() {
            _map = Content.Load<TiledMap>("map");
            _mapRenderer = new TiledMapRenderer(GraphicsDevice, _map);
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            MoveCamera(gameTime);
            _cam.LookAt(_camPos);

            _mapRenderer.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.DimGray);

            // TODO: Add your drawing code here

            _mapRenderer.Draw(_cam.GetViewMatrix());
            base.Draw(gameTime);
        }
    }
}
