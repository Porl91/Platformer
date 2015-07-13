
using Platformer.Exceptions;
using Platformer.World.EntitySystem;

namespace Platformer.TileSystem
{
	public abstract class Tile
	{
		public static int Width = 32;
		public static int Height = 32;

		public abstract void Update();

		public abstract void Render(RenderManager renderManager, int x, int y);

		private int _key = -1;

		public int Key
		{
			get
			{
				if (_key == -1)
				{
					throw new InvalidTileIndexException("Tile index is an invalid value: " + _key);
				}

				return _key;
			}

			set
			{
				if (value < 0)
				{
					throw new InvalidTileIndexException("Tile indices cannot be below 0");
				}

				_key = value;
			}
		}

		private bool _isObstructive = true;

		public virtual bool IsObstructive
		{
			get
			{
				return _isObstructive;
			}

			set
			{
				_isObstructive = value;
			}
		}

		public virtual void IntersectedWith(Entity e)
		{
			if (e is Player)
			{
				// Player specific intersection
			}

			// Standard entity intersection
		}
	}
}
