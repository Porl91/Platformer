using System;

using Microsoft.Xna.Framework;

namespace Platformer.World.Background
{
	public class Star
	{
		public Vector2 Position = new Vector2(0, 0);

		private static Random rand = new Random();

		private int _size = 3;

		public int Size
		{
			get
			{
				return _size;
			}

			set
			{
				_size = value;
			}
		}

		public Star(Vector2 position)
		{
			_size = rand.Next(1, 3);
			Position = position;
		}
	}
}
