
using Platformer.Render;
using Platformer.World;

namespace Platformer.TileSystem
{
	public interface ITile
	{
		void Update(Level level, int x, int y, ref int states);
		void UpdateType();
		void Render(RenderManager renderManager, int x, int y);
	}
}
