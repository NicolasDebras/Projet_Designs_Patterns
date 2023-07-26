using System;
using Designs_Patterns.Visitor;

namespace Designs_Patterns.Model
{
	/// <summary>
	/// class Ingredients 
	/// </summary>
	public class IngerdientsProps
    {
		/// <summary>
		/// Constructeur 
		/// </summary>
		/// <param name="quantity"></param>
		/// <param name="foodProps"></param>
		public IngerdientsProps(double quantity, FoodProps foodProps)
		{
			this.quantity = quantity;
			this.foodProps = foodProps;
		}

		public double quantity { get; set; }

		public FoodProps foodProps { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}

