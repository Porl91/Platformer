
using Microsoft.Xna.Framework;

using Platformer.Render;
using Platformer.World;

namespace Platformer.TileSystem
{
	public class Water : Tile
	{
		public Water()
		{
			IsObstructive = false;
		}

		public override void Update(Level level, int x, int y, ref int states)
		{
			if (states++ > 30)
			{
				var w = level.GetTile(x - 1, y);
				var e = level.GetTile(x + 1, y);
				var s = level.GetTile(x, y + 1);

				if (CanFlowInto(s))
					level.SetTile(x, y + 1, Key);
				else
				{
					if (CanFlowInto(w))
						level.SetTile(x - 1, y, Key);

					if (CanFlowInto(e))
						level.SetTile(x + 1, y, Key);
				}

				states = 0;
			}
		}

		public override void UpdateType()
		{
		}

		public override void Render(RenderManager renderManager, int x, int y)
		{
			renderManager.DrawTexture(new Rectangle(0, 32, Tile.Width, Tile.Height), new Vector2(x, y));
		}

		private bool CanFlowInto(Tile t)
		{
			return t is Empty || t.IsDestroyedByWater;
		}
	}
}
