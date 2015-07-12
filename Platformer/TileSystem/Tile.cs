using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Platformer.Exceptions;

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
				if(_key == -1)
				{
					throw new InvalidTileIndexException("Tile index is an invalid valid: " + _key);
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

		public bool IsObstructive
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
	}
}
