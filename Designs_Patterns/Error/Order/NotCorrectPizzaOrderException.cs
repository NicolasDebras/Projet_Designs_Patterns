using System;
namespace Designs_Patterns.Error.Order
{
	public class NotCorrectPizzaOrderException : Exception
    {
		public NotCorrectPizzaOrderException()
            : base("Pizza inconnue")
        {
		}
	}
}

