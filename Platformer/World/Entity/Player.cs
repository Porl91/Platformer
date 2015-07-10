using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Platformer.World.Entity
{
	public class Player : Entity
	{
		public override void Update()
		{
		}

		public override void Render(RenderManager renderManager, int x, int y)
		{
			renderManager.DrawTexture(new Rectangle(50, 50, 100, 100), new Vector2(10, 10));
		}
	}
}
