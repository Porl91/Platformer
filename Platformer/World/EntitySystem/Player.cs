using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Platformer.Render;
using Platformer.TileSystem;

namespace Platformer.World.EntitySystem
{
	public class Player : DynamicEntity
	{
		public Player(Level level)
			: base(level)
		{
			HalfDimensions = new Vector2(8, 14);

			Position = new Vector2(500, 0);
		}

		public override void Update(KeyboardState keyboardState)
		{
			if (keyboardState.IsKeyDown(Keys.A))
				Move(new Vector2(-5, 0));

			if (keyboardState.IsKeyDown(Keys.D))
				Move(new Vector2(5, 0));

			if (keyboardState.IsKeyDown(Keys.Space))
				Jump();

			if (keyboardState.IsKeyDown(Keys.P))
				CreateCrater(10);

			base.Update(keyboardState);
		}

		public override void Render(RenderManager renderManager, Camera camera)
		{
			var offsetPosition = Position - camera.Position - HalfDimensions;
			renderManager.DrawTexture(new Rectangle(64, 0, (int) (HalfDimensions.X * 2), (int) (HalfDimensions.Y * 2)), offsetPosition);
		}

		private void CreateCrater(int radius)
		{
			var radius2 = radius * radius;
			for(var y = -radius; y <= radius; y++)
			{
				var d1 = y * y;
				for (var x = -radius; x <= radius; x++)
				{
					var d2 = x * x + d1;
					if (d2 <= radius2)
						Level.SetTile((int)(x + Position.X / Tile.Width), (int)(y + Position.Y / Tile.Height), TileFactory.Empty.Key);
				}
			}
		}
	}
}
