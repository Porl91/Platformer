using System;

namespace Platformer.Exceptions
{
	public class DuplicateTileException : Exception
	{
		public DuplicateTileException()
		{
		}
		public DuplicateTileException(string message)
			: base(message)
		{
		}
		public DuplicateTileException(string message, Exception inner)
			: base(message)
		{
		}
	}
}
