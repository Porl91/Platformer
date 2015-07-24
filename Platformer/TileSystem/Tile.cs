
using Platformer.Exceptions;
using Platformer.Render;
using Platformer.World;

namespace Platformer.TileSystem
{
	public abstract class Tile : ITile
	{
		private int _key = -1;

		#region Global static tile properties
		public static int Width = 32;
		public static int Height = 32;
		#endregion

		#region Flags
		private bool _isObstructive = true;
		private bool _isDestroyedByWater = false;
		private bool _canSubmerge = false;
		#endregion

		#region Accessor methods
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
		#endregion

		#region Abstract ITile methods
		public abstract void Update(Level level, int x, int y, ref int states);
		public abstract void UpdateType();
		public abstract void Render(RenderManager renderManager, int x, int y);
		#endregion

		protected bool CanFlowInto(Tile t)
		{
			return t is Empty || t.IsDestroyedByWater;
		}
	}
}
