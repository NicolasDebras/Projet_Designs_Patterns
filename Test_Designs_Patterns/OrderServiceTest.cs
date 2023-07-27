using Designs_Patterns.Service;
using Designs_Patterns.Model;
using Designs_Patterns.Error.Order;
using System.Collections.Generic;
using Designs_Patterns.Error;
using Designs_Patterns.Factory;
using Designs_Patterns;

namespace Test_Designs_Patterns;

public class OrderServiceTests
{
    private RestaurantProps restaurant;

    public OrderServiceTests()
    {
        List<PizzaProps> InitMenu = new List<PizzaProps>();
        InitMenu.Add(ReginaPizzaFactory.Instance.CreatePizza());
        InitMenu.Add(QuatreSaisonsPizzaFactory.Instance.CreatePizza());
        InitMenu.Add(VegetariennePizzaFactory.Instance.CreatePizza());
        InitMenu.Add(CalzonePizzaFactory.Instance.CreatePizza());

        restaurant = new RestaurantProps(InitMenu);
    }

    [Fact]
    public void CreateOrder_ValidInput_ReturnsOrder()
    {
        var serviceMock = new Mock<OrderService>(restaurant) { CallBase = true };
        serviceMock.Setup(s => s.RecupInput()).Returns("1 Pepperoni, 2 Margarita");
        OrderService service = serviceMock.Object;

        var order = service.CreateOrder();

        Assert.Equal(2, order.order.Count);
        Assert.Equal("Pepperoni", order.order[0].Item1.title);
        Assert.Equal(1, order.order[0].Item2);
        Assert.Equal("Margarita", order.order[1].Item1.title);
        Assert.Equal(2, order.order[1].Item2);
    }

    [Fact]
    public void CreateOrder_InvalidPizza_ThrowsException()
    {
        var serviceMock = new Mock<OrderService>(restaurant) { CallBase = true };
        serviceMock.Setup(s => s.RecupInput()).Returns("1 UnknownPizza");
        OrderService service = serviceMock.Object;

        Assert.Throws<NotCorrectPizzaOrderException>(() => service.CreateOrder());
    }

    [Fact]
    public void CreateOrder_InvalidQuantity_ThrowsException()
    {
        var serviceMock = new Mock<OrderService>(restaurant) { CallBase = true };
        serviceMock.Setup(s => s.RecupInput()).Returns("NotANumber Pepperoni");
        OrderService service = serviceMock.Object;

        Assert.Throws<NotValueOrderException>(() => service.CreateOrder());
    }

    [Fact]
    public void CreateOrder_SamePizzaMultipleTimes_ConsolidatesOrder()
    {
        var serviceMock = new Mock<OrderService>(restaurant) { CallBase = true };
        serviceMock.Setup(s => s.RecupInput()).Returns("1 Pepperoni, 2 Pepperoni");
        OrderService service = serviceMock.Object;

        var order = service.CreateOrder();

        Assert.Single(order.order);
        Assert.Equal("Pepperoni", order.order[0].Item1.title);
        Assert.Equal(3, order.order[0].Item2);
    }
}
