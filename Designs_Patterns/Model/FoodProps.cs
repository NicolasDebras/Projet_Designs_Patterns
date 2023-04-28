using System;
namespace Designs_Patterns.Model
{
	/// <summary>
	/// aliment (ex tomate)
	/// </summary>
	public class FoodProps
	{
		public FoodProps(string name)
		{
			this.name = name;
		}

		public string name { get; set; }
	}
}

