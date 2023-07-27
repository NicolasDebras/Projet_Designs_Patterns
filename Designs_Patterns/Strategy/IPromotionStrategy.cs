using System;
using Designs_Patterns.Model;

namespace Designs_Patterns
{
	public interface IPromotionStrategy
	{
        void ApplyPromotion(OrderProps order);
    }
}

