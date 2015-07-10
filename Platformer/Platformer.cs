using System;
using Cocos2D;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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

		private World.World _world;

		public Platformer()
		{
			_graphics = new GraphicsDeviceManager(this);
			//#if MACOS
			//            Content.RootDirectory = "AngryNinjas/Content";
			//#else
			Content.RootDirectory = "Content";
			//#endif
			//
			//#if XBOX || OUYA
			//            graphics.IsFullScreen = true;
			//#else
			_graphics.IsFullScreen = false;
			//#endif

			// Frame rate is 30 fps by default for Windows Phone.
			TargetElapsedTime = TimeSpan.FromTicks(333333 / 2);

			// Extend battery life under lock.
			//InactiveSleepTime = TimeSpan.FromSeconds(1);

			CCApplication application = new AppDelegate(this, _graphics);
			Components.Add(application);
			//#if XBOX || OUYA
			//            CCDirector.SharedDirector.GamePadEnabled = true;
			//            application.GamePadButtonUpdate += new CCGamePadButtonDelegate(application_GamePadButtonUpdate);
			//#endif
		}

		//#if XBOX || OUYA
		//        private void application_GamePadButtonUpdate(CCGamePadButtonStatus backButton, CCGamePadButtonStatus startButton, CCGamePadButtonStatus systemButton, CCGamePadButtonStatus aButton, CCGamePadButtonStatus bButton, CCGamePadButtonStatus xButton, CCGamePadButtonStatus yButton, CCGamePadButtonStatus leftShoulder, CCGamePadButtonStatus rightShoulder, PlayerIndex player)
		//        {
		//            if (backButton == CCGamePadButtonStatus.Pressed)
		//            {
		//                ProcessBackClick();
		//            }
		//        }
		//#endif

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
			
			_renderManager = new RenderManager(_graphics, _spriteBatch, _spritesheet);

			_world = new World.World();
		}

		protected override void Update(GameTime gameTime)
		{
			// Allows the game to exit
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
			{
				ProcessBackClick();
			}

			// TODO: Add your update logic here

			_world.Update();

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			_world.Render(_renderManager);
		}
	}
}