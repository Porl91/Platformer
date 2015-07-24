using System;

namespace Platformer.Entensions
{
	public static class FloatExtensions
	{
		public static float NFMod(this float a, float b)
		{
			return a - b * (float)Math.Floor(a / b);
		}
	}
}