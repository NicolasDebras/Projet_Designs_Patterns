using System;
namespace Designs_Patterns.Model
{
	public class IngerdientsProps
    {
		public IngerdientsProps(int quantity, FoodProps foodProps)
		{
			this.quantity = quantity;
			this.foodProps = foodProps;
		}

		public int quantity { get; set; }

		public FoodProps foodProps { get; set; }
	}
}

