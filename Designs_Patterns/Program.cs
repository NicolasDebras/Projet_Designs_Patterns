using Designs_Patterns;
using Designs_Patterns.Factory;
using Designs_Patterns.Model;
using Designs_Patterns.Service;
using Designs_Patterns.Visitor;


List<PizzaProps> InitMenu = new List<PizzaProps>();
InitMenu.Add(ReginaPizzaFactory.Instance.CreatePizza());
InitMenu.Add(QuatreSaisonsPizzaFactory.Instance.CreatePizza());
InitMenu.Add(VegetariennePizzaFactory.Instance.CreatePizza());


RestaurantProps restaurant = new RestaurantProps(InitMenu);


OrderService order = new OrderService(restaurant);

while (true)
{
    OrderProps res = order.CreateOrder();

    billingService billing = new billingService(res);
    billing.printbilling();

    MakingService making = new MakingService(res);
    making.Making();

    var visitor = new ListIngredientsVisitor();
    foreach (var tuple in res.order)
    {
        var pizza = tuple.Item1;
        pizza.Accept(visitor); 
    }
    foreach (var ingredient in visitor.IngredientsUsage)
    {
        double totalQuantity = ingredient.Value.Values.Sum();
        Console.WriteLine($"{ingredient.Key.name} : {totalQuantity}");
        foreach (var pizza in ingredient.Value)
        {
            Console.WriteLine($"- {pizza.Key.title} : {pizza.Value}");
        }
    }

}




