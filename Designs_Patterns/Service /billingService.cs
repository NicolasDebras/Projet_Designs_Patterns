using System;
using Designs_Patterns.Model;

namespace Designs_Patterns.Service
{
	public class billingService
	{
		public OrderProps orderProps { get; set; }

		public int total { get; set; }

		public billingService(OrderProps orderProps)
		{
			this.orderProps = orderProps;
			total = 0;
		}

		public void printbilling()
		{
			if (orderProps.order.Count == 0)
				throw new Exception("Pas de pizza");

			foreach (PizzaProps pizza in orderProps.order)
			{
				total += pizza.prix;
				Console.WriteLine(pizza.title + " --------------- " + pizza.prix);

			}
			Console.WriteLine("\n-----------------\n\n");
            Console.WriteLine("Total :" + total);

        }
    }
}

