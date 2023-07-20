using System;
using Designs_Patterns.Error;
using Designs_Patterns.Error.Order;
using Designs_Patterns.Model;

namespace Designs_Patterns.Service
{
	public class OrderService
	{
		public OrderService(RestaurantProps restaurant)
		{
			this.restaurant = restaurant;
		}

		public RestaurantProps restaurant { get; set; }

		public OrderProps CreateOrder()
		{
			OrderProps res = new OrderProps();
            Console.WriteLine("Veuillez saisir votre commande :");
            string input = Console.ReadLine();

            res.order = ParsePizzaOrders(input);

            return res;
		}

        
        private List<Tuple<PizzaProps, int>> ParsePizzaOrders(string input)
        {
            List<Tuple<PizzaProps, int>> order = new List<Tuple<PizzaProps, int>>();

            string[] orderItems = input.Split(',');

            foreach (string orderItem in orderItems)
            {
                int quantity = 0;
                try {
                    if (orderItem[0] == ' ')
                        quantity = (int)Char.GetNumericValue(orderItem[1]);
                    else
                        quantity = (int)Char.GetNumericValue(orderItem[0]);
                    Console.WriteLine(orderItem[0]);
                }
                catch {
                    throw new NotValueOrderException();
                }

                string pizza = "";
                if (orderItem[0] == ' ')
                    pizza = orderItem.Substring(3);
                else
                    pizza = orderItem.Substring(2);

                PizzaProps PizzaOrder = restaurant.Menu.Find(x => x.title == pizza);

                if (PizzaOrder == null)
                    throw new NotCorrectPizzaOrderException();

                order.Add(new Tuple<PizzaProps, int>(PizzaOrder, quantity));

            }

            return ConsolidatePizzaOrders(order);
        }


        /// <summary>
        /// regroupe les pizza du même type
        /// </summary>
        /// <param name="pizzaOrders"></param>
        /// <returns></returns>
        private static List<Tuple<PizzaProps, int>> ConsolidatePizzaOrders(List<Tuple<PizzaProps, int>> pizzaOrders)
        {
            var consolidatedOrders = pizzaOrders
                .GroupBy(o => o.Item1)
                .Select(g => new Tuple<PizzaProps, int>(g.Key, g.Sum(o => o.Item2)))
                .ToList();

            return consolidatedOrders;
        }

    }
}

