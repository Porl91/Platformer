using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

using Platformer.Render;

namespace Platformer.TileSystem
{
	public class Water : Tile
	{
		public Water()
		{
			IsObstructive = false;
		}

		public override void Update(int x, int y, ref int states)
		{
		}

		public override void UpdateType()
		{
		}

		public override void Render(RenderManager renderManager, int x, int y)
		{
			renderManager.DrawTexture(new Rectangle(0, 32, Tile.Width, Tile.Height), new Vector2(x, y));
		}
	}
}
