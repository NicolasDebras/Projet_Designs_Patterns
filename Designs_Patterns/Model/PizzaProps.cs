using System;
using Designs_Patterns.Model;

namespace Designs_Patterns
{
	public class PizzaProps
	{
		public PizzaProps(string title, List<IngerdientsProps> recipe, double prix)
		{
			this.title = title;
			this.recipe = recipe;
			this.prix = prix;
		}

		public List<IngerdientsProps> recipe { get; set; }

		public string title { get; set; }

		public double prix { get; set; }
    }
}

