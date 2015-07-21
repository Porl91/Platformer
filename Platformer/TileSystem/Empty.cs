using Platformer.Render;
using Platformer.World;

namespace Platformer.TileSystem
{
	public class Empty : Tile
	{
		public Empty()
		{
			IsObstructive = false;
		}

		public override void Update(Level level, int x, int y, ref int states)
		{
		}

		public override void UpdateType()
		{
		}

		public override void Render(RenderManager renderManager, int x, int y)
		{
		}
	}
}
