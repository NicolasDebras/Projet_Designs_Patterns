using System;
namespace Designs_Patterns.Model
{
	public class RestaurantProps
	{
		public RestaurantProps(List<PizzaProps> Menu)
		{
			this.Menu = Menu;
		}

		public List<PizzaProps> Menu { get; set; }
    }
}

