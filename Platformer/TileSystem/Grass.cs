
using Microsoft.Xna.Framework;

using Platformer.Render;
using Platformer.World;

namespace Platformer.TileSystem
{
	public class Grass : Tile
	{
		public Grass()
		{
			IsObstructive = true;
		}

		public override void Update(Level level, int x, int y, ref int states)
		{
		}

		public override void UpdateType()
		{
		}

		public override void Render(RenderManager renderManager, int x, int y)
		{
			renderManager.DrawTexture(new Rectangle(32, 0, Tile.Width, Tile.Height), new Vector2(x, y));
		}
	}
}
