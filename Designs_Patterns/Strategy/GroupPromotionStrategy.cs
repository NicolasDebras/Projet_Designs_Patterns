using Designs_Patterns;
using Designs_Patterns.Model;

public class GroupPromotionStrategy : IPromotionStrategy
{
    public void ApplyPromotion(OrderProps order)
    {

        var totalQuantity = order.order.Sum(p => p.Item2);

        if (totalQuantity >= 3)
        {
            var cheapestPizza = order.order.OrderBy(p => p.Item1.prix).First();

            int numberOfFreePizzas = totalQuantity / 3;
            for (int i = 0; i < numberOfFreePizzas && i < cheapestPizza.Item2; i++)
            {
                cheapestPizza.Item1.prix -= cheapestPizza.Item1.prix / cheapestPizza.Item2;
            }
        }
    }
}
