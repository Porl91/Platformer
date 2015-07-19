
using Microsoft.Xna.Framework;

using Platformer.Render;

namespace Platformer.TileSystem
{
	public class Dirt : Tile
	{
		public Dirt()
		{
			IsObstructive = true;
		}

		public override void Update()
		{
		}

		public override void Render(RenderManager renderManager, int x, int y)
		{
			renderManager.DrawTexture(new Rectangle(0, 0, Tile.Width, Tile.Height), new Vector2(x, y));
		}
	}
}
