using Designs_Patterns;
using Designs_Patterns.Factory;
using Designs_Patterns.Model;
using Designs_Patterns.Service;
using Designs_Patterns.Strategy;

public class Program
{
    public static void Main(string[] args)
    {
        List<PizzaProps> InitMenu = new List<PizzaProps>();
        InitMenu.Add(ReginaPizzaFactory.Instance.CreatePizza());
        InitMenu.Add(QuatreSaisonsPizzaFactory.Instance.CreatePizza());
        InitMenu.Add(VegetariennePizzaFactory.Instance.CreatePizza());
        InitMenu.Add(CalzonePizzaFactory.Instance.CreatePizza());

        RestaurantProps restaurant = new RestaurantProps(InitMenu);

        OrderService order = new OrderService(restaurant);

        while (true)
        {
            OrderProps res = order.CreateOrder();

            billingService billing = new billingService(res);
            var promotionStrategy = new GroupPromotionStrategy();

            billing.ApplyPromotion(promotionStrategy);

            billing.printbilling();

            MakingService making = new MakingService(res);
            making.Making();
            making.ListIngredientUse(res);
        }
    }
}



