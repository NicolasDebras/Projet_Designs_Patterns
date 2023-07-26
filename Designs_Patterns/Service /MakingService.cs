using System;
using Designs_Patterns.Factory;
using Designs_Patterns.Model;

namespace Designs_Patterns.Service
{
	public class MakingService
	{
		public MakingService(OrderProps orderProps)
		{
			this.orderProps = orderProps;
		}

        OrderProps orderProps { get; set; }

		public void Making()
		{
			Console.WriteLine("Préparation :");

            foreach (Tuple<PizzaProps, int> order in orderProps.order)
			{
				for(int i = 0; i != order.Item2; i++)
				{
					if (order.Item1.title == "Regina")
						ReginaPizzaFactory.Instance.MakingPizza(order.Item1);
					else if (order.Item1.title == "4 Saisons")
						QuatreSaisonsPizzaFactory.Instance.MakingPizza(order.Item1);
					else
						VegetariennePizzaFactory.Instance.MakingPizza(order.Item1);

                }

				
			}


        }

    }
}

