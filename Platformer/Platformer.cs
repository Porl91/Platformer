using System;
using Cocos2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Platformer.Render;
using Platformer.World;

namespace Platformer
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Platformer : Game
	{
		private readonly GraphicsDeviceManager _graphics;
		private Rectangle _screenArea;
		private Texture2D _spritesheet;
		private SpriteBatch _spriteBatch;
		private RenderManager _renderManager;

		private Level _world;

		public Platformer()
		{
			_graphics = new GraphicsDeviceManager(this);

			Content.RootDirectory = "Content";
			_graphics.IsFullScreen = false;
			TargetElapsedTime = TimeSpan.FromTicks(333333 / 2);

			CCApplication application = new AppDelegate(this, _graphics);
			Components.Add(application);
		}

		private void ProcessBackClick()
		{
			if (CCDirector.SharedDirector.CanPopScene)
			{
				CCDirector.SharedDirector.PopScene();
			}
			else
			{
				Exit();
			}
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			_screenArea = new Rectangle(
				_graphics.GraphicsDevice.Viewport.X,
				_graphics.GraphicsDevice.Viewport.Y,
				_graphics.GraphicsDevice.Viewport.Width,
				_graphics.GraphicsDevice.Viewport.Height
			);

			_spritesheet = Content.Load<Texture2D>("Spritesheet");

			_renderManager = new RenderManager(_graphics, _spriteBatch, _spritesheet, _screenArea);

			_world = new Level();
		}

		protected override void Update(GameTime gameTime)
		{
			KeyboardState keyboardState = Keyboard.GetState();

			_world.Update(keyboardState);

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			_world.Render(_renderManager);
		}
	}
}