using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Platformer.Exceptions
{
	public class InvalidTileException : Exception
	{
		public InvalidTileException()
		{
		}
		public InvalidTileException(string message)
			: base(message)
		{
		}
		public InvalidTileException(string message, Exception inner)
			: base(message)
		{
		}
	}
}
