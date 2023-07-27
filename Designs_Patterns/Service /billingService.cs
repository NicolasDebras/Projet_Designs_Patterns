using System;
using Designs_Patterns.Error.Billing;
using Designs_Patterns.Model;

namespace Designs_Patterns.Service
{
	public class billingService
	{
		public OrderProps orderProps { get; set; }

		public double total { get; set; }

		public billingService(OrderProps orderProps)
		{
			this.orderProps = orderProps;
			total = 0;
		}

		public void printbilling()
		{
			if (orderProps.order.Count == 0)
				throw new NoPizzaBillingException();

            Console.WriteLine("Facture :");
            foreach (Tuple<PizzaProps, int> order in orderProps.order)
			{
				total += order.Item1.prix * order.Item2;
				Console.WriteLine("" + order.Item2 + " " + order.Item1.title + " : " + order.Item2 + " * " + order.Item1.prix + "€");
				foreach (IngerdientsProps ingerdients in order.Item1.recipe)
				{
					Console.WriteLine(ingerdients.foodProps.name + " " + ingerdients.quantity);
				}
			}
            Console.WriteLine("Prix total : " + total + "€");

        }

        public void ApplyPromotion(IPromotionStrategy strategy)
        {
            strategy.ApplyPromotion(orderProps);
        }
    }
}

