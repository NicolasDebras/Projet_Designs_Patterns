using System;
namespace Designs_Patterns.Error
{
	public class NotValueOrderException : Exception
    {
		public NotValueOrderException()
			: base("Pas de Quantité Sélectioné")
		{
		}
	}
}

