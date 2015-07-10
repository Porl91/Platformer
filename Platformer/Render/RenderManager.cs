using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
	public class RenderManager
	{
		public GraphicsDeviceManager GraphicsDeviceManager { get; private set; }
		public SpriteBatch SpriteBatch { get; private set; }
		public Texture2D Spritesheet { get; private set; }

		public RenderManager(GraphicsDeviceManager graphicsDeviceManager, SpriteBatch spriteBatch, Texture2D spriteSheet)
		{
			GraphicsDeviceManager = graphicsDeviceManager;
			SpriteBatch = spriteBatch;
			Spritesheet = spriteSheet;
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
