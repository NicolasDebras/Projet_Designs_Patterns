using System;
namespace Designs_Patterns.Model
{
	public class OrderProps
	{
		public OrderProps()
		{
			order = new List<PizzaProps>();
        }

        public List<PizzaProps> order { get; set; }

    }
}

