using System;

namespace Platformer.Exceptions
{
	public class MultipleMovementAxisException : Exception
	{
		public MultipleMovementAxisException()
		{
		}
		public MultipleMovementAxisException(string message)
			: base(message)
		{
		}
		public MultipleMovementAxisException(string message, Exception inner)
			: base(message)
		{
		}
	}
}
