using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;

namespace Labyrintspill {
    public class Game1 : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private TiledMap _map;
        private TiledMapRenderer _mapRenderer;
        private OrthographicCamera _camera;
        private Vector2 _camPos;

        public Game1() {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        private Vector2 GetMovementDirection() {
            var movementDirection = Vector2.Zero;
            var state = Keyboard.GetState();
            if(state.IsKeyDown(Keys.S)) {
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

            if(movementDirection != Vector2.Zero) {
                movementDirection.Normalize();
            }

            return movementDirection;
        }

        private void MoveCam(GameTime gameTime) {
            var speed = 200;
            var seconds = gameTime.GetElapsedSeconds();
            var movementDirection = GetMovementDirection();
            _camPos += speed * movementDirection * seconds;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here
            var viewportadapter = new BoxingViewportAdapter(Window, GraphicsDevice, 800, 600);
            _camera = new OrthographicCamera(viewportadapter);

            base.Initialize();
        }

        protected override void LoadContent() {
            _map = Content.Load<TiledMap>("Map");
            _mapRenderer = new TiledMapRenderer(GraphicsDevice, _map);

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MoveCam(gameTime);
            _camera.LookAt(_camPos);

            // TODO: Add your update logic here

            _mapRenderer.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            _mapRenderer.Draw(_camera.GetViewMatrix());
            base.Draw(gameTime);
        }
    }
}
