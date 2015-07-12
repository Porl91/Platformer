using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
