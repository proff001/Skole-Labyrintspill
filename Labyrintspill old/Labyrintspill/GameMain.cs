using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.ViewportAdapters;
using System.Diagnostics;

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
        private Player player;

        // Hovedfunksjonen som blir kjørt av Program.cs
        public GameMain() {
            // Kode som følger med MonoGame Templaten
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            viewportAdapter = new ScalingViewportAdapter(GraphicsDevice, 1280, 720);
            cam = new OrthographicCamera(viewportAdapter);

            Window.AllowUserResizing = true;

            // TODO: Add your initialization logic here
            player = new Player();

            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            player.sprite = Content.Load<Texture2D>("Textures/Player");
            camPos = new Vector2(100, 100);
            cam.LookAt(camPos);
            map = Content.Load<TiledMap>("map");
            mapRenderer = new TiledMapRenderer(GraphicsDevice, map);
        }

        protected override void Update(GameTime gameTime) {
            var keyStates = Keyboard.GetState();

            if (keyStates.IsKeyDown(Keys.Escape))
                Exit();

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
                camPos += 200f * movementDirection * gameTime.GetElapsedSeconds();
            }

            // TODO: Add your update logic here

            viewportAdapter = new ScalingViewportAdapter(GraphicsDevice, Window.ClientBounds.Width, Window.ClientBounds.Height);
            cam = new OrthographicCamera(viewportAdapter);

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

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(player.sprite, camPos, null, Color.White, 0f, new Vector2(player.sprite.Width/2, player.sprite.Height/2), 0.5f, SpriteEffects.None, 0);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }

    public class Player {
        public Texture2D sprite { get; set; }
        public Vector2 pos { get; set; }
        public Inventory inv { get; set; }
    }

    public class Inventory {
        public Item[] items { get; set; }
    }

    public class Item {
        public string name { get; set; }
        public int amount { get; set; }
    }
}
