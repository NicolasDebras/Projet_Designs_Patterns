using System;
namespace Designs_Patterns.Model
{
	public class OrderProps
	{
		public OrderProps()
		{
			order = new List<Tuple<PizzaProps, int>>();
        }

        public List<Tuple<PizzaProps, int>> order { get; set; }

    }
}

