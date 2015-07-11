using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Platformer.Tile
{
	public abstract class Tile
	{
		public static int Width = 32;
		public static int Height = 32;

		public abstract void Update();

		public abstract void Render(RenderManager renderManager, int x, int y);

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
