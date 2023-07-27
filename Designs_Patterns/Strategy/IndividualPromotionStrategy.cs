using System;
using Designs_Patterns.Model;

namespace Designs_Patterns.Strategy
{
	public class IndividualPromotionStrategy : IPromotionStrategy
    {
        public void ApplyPromotion(OrderProps order)
        {
            foreach (var pizza in order.order)
            {
                if (pizza.Item1.title == "Regina")
                {
                    pizza.Item1.prix *= 0.8;
                }
            }
        }
    }
}

