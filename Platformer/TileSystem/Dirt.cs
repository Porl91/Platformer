using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace Platformer.TileSystem
{
	public class Dirt : Tile
	{
		public override void Update()
		{
		}

		public override void Render(RenderManager renderManager, int x, int y)
		{
			renderManager.DrawTexture(new Rectangle(0, 0, Tile.Width, Tile.Height), new Vector2(x, y));
		}
	}
}
