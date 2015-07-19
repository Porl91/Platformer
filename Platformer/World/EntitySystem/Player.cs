using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Platformer.Render;

namespace Platformer.World.EntitySystem
{
	public class Player : DynamicEntity
	{
		public Player(Level level)
			: base(level)
		{
			HalfDimensions = new Vector2(8, 16);

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

			base.Update(keyboardState);
		}

		public override void Render(RenderManager renderManager, Camera camera)
		{
			var offsetPosition = Position - camera.Position - HalfDimensions;
			renderManager.DrawTexture(new Rectangle(64, 0, (int) (HalfDimensions.X * 2), (int) (HalfDimensions.Y * 2)), offsetPosition);
		}
	}
}
