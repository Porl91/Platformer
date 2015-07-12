using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Platformer.World.EntitySystem
{
	public class Player : Entity
	{
		public override void Update(KeyboardState keyboardState)
		{
			if (keyboardState.IsKeyDown(Keys.W))
			{
				Move(new Vector2(0, -1));
			}

			if (keyboardState.IsKeyDown(Keys.S))
			{
				Move(new Vector2(0, 1));
			}

			if (keyboardState.IsKeyDown(Keys.A))
			{
				Move(new Vector2(-1, 0));
			}

			if (keyboardState.IsKeyDown(Keys.D))
			{
				Move(new Vector2(1, 0));
			}
		}

		public override void Render(RenderManager renderManager, int x, int y)
		{
			//renderManager.DrawTexture(new Rectangle(0, 0, 32, 32), new Vector2(0, 0));
		}
	}
}
