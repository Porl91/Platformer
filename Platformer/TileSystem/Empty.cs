using Platformer.Render;

namespace Platformer.TileSystem
{
	public class Empty : Tile
	{
		public Empty()
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
		}
	}
}
