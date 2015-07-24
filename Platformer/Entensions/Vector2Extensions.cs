using System;

using Microsoft.Xna.Framework;

namespace Platformer.Entensions
{
	public static class Vector2Extensions
	{
		public static Vector2 Floor(this Vector2 value1)
		{
			return new Vector2((float)Math.Floor(value1.X), (float)Math.Floor(value1.Y));
		}

		public static Vector2 Ceil(this Vector2 value1)
		{
			return new Vector2((float)Math.Ceiling(value1.X), (float)Math.Ceiling(value1.Y));
		}

		public static Vector2 Round(this Vector2 value1)
		{
			return new Vector2((float)Math.Round(value1.X), (float)Math.Round(value1.Y));
		}
	}
}
