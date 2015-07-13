using System;

namespace Platformer.Exceptions
{
	public class InvalidTileIndexException : Exception
	{
		public InvalidTileIndexException()
		{
		}
		public InvalidTileIndexException(string message)
			: base(message)
		{
		}
		public InvalidTileIndexException(string message, Exception inner)
			: base(message)
		{
		}
	}
}
