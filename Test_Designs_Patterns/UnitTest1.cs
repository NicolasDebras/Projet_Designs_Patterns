using Designs_Patterns;
using Designs_Patterns.Model;
using Designs_Patterns.Service;

namespace Test_Designs_Patterns;

public class UnitTest1
{
    [Fact]
    public void test_billing_total()
    {
        FoodProps tomato = new FoodProps("tomate");

        IngerdientsProps sauceTomate = new IngerdientsProps(100, tomato);
        IngerdientsProps coulisTomate = new IngerdientsProps(50, tomato);

        List<IngerdientsProps> listI = new List<IngerdientsProps>();
        listI.Add(sauceTomate);
        listI.Add(coulisTomate);

        PizzaProps pizza1 = new PizzaProps("Pizza a l'annas", listI, 12);

        OrderProps order1 = new OrderProps();
        order1.order.Add(pizza1);

        billingService b = new billingService(order1);
        b.printbilling();

        Assert.Equal(12, b.total);
    }
}
