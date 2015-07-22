
using Platformer.Exceptions;
using Platformer.Render;
using Platformer.World;
using Platformer.World.EntitySystem;

namespace Platformer.TileSystem
{
	public abstract class Tile
	{
		public static int Width = 32;
		public static int Height = 32;

		public abstract void Update(Level level, int x, int y, ref int states);

		public abstract void UpdateType();

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


		private bool _isDestroyedByWater = false;

		public virtual bool IsDestroyedByWater
		{
			get
			{
				return _isDestroyedByWater;
			}

			set
			{
				_isDestroyedByWater = value;
			}
		}


		private bool _canSubmerge = false;

		public virtual bool CanSubmerge
		{
			get
			{
				return _canSubmerge;
			}

			set
			{
				_canSubmerge = value;
			}
		}

		protected bool CanFlowInto(Tile t)
		{
			return t is Empty || t.IsDestroyedByWater;
		}
	}
}
