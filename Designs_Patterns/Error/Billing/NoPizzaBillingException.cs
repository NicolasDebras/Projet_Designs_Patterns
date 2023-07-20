using System;
namespace Designs_Patterns.Error.Billing
{
	public class NoPizzaBillingException : Exception
    {
		public NoPizzaBillingException()
            : base("Commande vide")
        {
		}
	}
}

