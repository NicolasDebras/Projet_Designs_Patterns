using System;
using Designs_Patterns.Factory;
using Designs_Patterns.Model;
using Designs_Patterns.Visitor;

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
					else if (order.Item1.title == "Calzone")
						ReginaPizzaFactory.Instance.MakingPizza(order.Item1);
					else
						VegetariennePizzaFactory.Instance.MakingPizza(order.Item1);

                }
	
			}
        }


		/// <summary>
		/// genre la liste des ingredients pour la commande
		/// </summary>
		/// <param name="res"></param>
		public void ListIngredientUse(OrderProps res)
		{
            var visitor = new ListIngredientsVisitor();
            foreach (var tuple in res.order)
            {
                var pizza = tuple.Item1;
                pizza.Accept(visitor);
            }
            foreach (var ingredient in visitor.IngredientsUsage)
            {
                double totalQuantity = ingredient.Value.Values.Sum();
                Console.WriteLine($"{ingredient.Key.name} : {totalQuantity}");
                foreach (var pizza in ingredient.Value)
                {
                    Console.WriteLine($"- {pizza.Key.title} : {pizza.Value}");
                }
            }
        }
    }
}

