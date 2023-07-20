using System;
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
					Console.WriteLine(order.Item1.title);
					Console.WriteLine("Préparer la pâte");
					foreach(IngerdientsProps ingerdients in order.Item1.recipe)
					{
						Console.WriteLine("Ajouter " + ingerdients.foodProps.name);
					}

				}

				
			}


        }

    }
}

