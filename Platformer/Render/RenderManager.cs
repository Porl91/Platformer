using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer.Render
{
	public class RenderManager
	{
		public GraphicsDeviceManager GraphicsDeviceManager { get; private set; }
		public SpriteBatch SpriteBatch { get; private set; }
		public Texture2D Spritesheet { get; private set; }
		public Rectangle ScreenArea { get; private set; }

		private int _viewportWidth = 0;
		public int ViewportWidth
		{
			get
			{
				if (_viewportWidth == 0)
				{
					_viewportWidth = GraphicsDeviceManager.GraphicsDevice.Viewport.Width;
				}

				return _viewportWidth;
			}
		}

		private int _viewportHeight = 0;
		public int ViewportHeight
		{
			get
			{
				if (_viewportHeight == 0)
				{
					_viewportHeight = GraphicsDeviceManager.GraphicsDevice.Viewport.Height;
				}

				return _viewportHeight;
			}
		}

		public RenderManager(GraphicsDeviceManager graphicsDeviceManager, SpriteBatch spriteBatch, Texture2D spriteSheet, Rectangle screenArea)
		{
			GraphicsDeviceManager = graphicsDeviceManager;
			SpriteBatch = spriteBatch;
			Spritesheet = spriteSheet;
			ScreenArea = screenArea;
		}

		public void ClearScreen(Color col)
		{
			GraphicsDeviceManager.GraphicsDevice.Clear(col);
		}

		public void DrawTexture(Rectangle textureCrop, Vector2 position)
		{
			SpriteBatch.Begin();
			SpriteBatch.Draw(Spritesheet, position, textureCrop, Color.White);
			SpriteBatch.End();
		}
	}
}
