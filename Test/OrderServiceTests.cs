using Designs_Patterns;
using Designs_Patterns.Error;
using Designs_Patterns.Error.Order;
using Designs_Patterns.Factory;
using Designs_Patterns.Model;
using Designs_Patterns.Service;

namespace Test
{
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
            serviceMock.Setup(s => s.RecupInput()).Returns("1 Regina, 2 Végétarienne");
            OrderService service = serviceMock.Object;

            var order = service.CreateOrder();

            Assert.Equal(2, order.order.Count);
            Assert.Equal("Regina", order.order[0].Item1.title);
            Assert.Equal(1, order.order[0].Item2);
            Assert.Equal("Végétarienne", order.order[1].Item1.title);
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
        public void CreateOrder_SamePizzaMultipleTimes_ConsolidatesOrder()
        {
            var serviceMock = new Mock<OrderService>(restaurant) { CallBase = true };
            serviceMock.Setup(s => s.RecupInput()).Returns("1 Regina, 2 Regina");
            OrderService service = serviceMock.Object;

            var order = service.CreateOrder();

            Assert.Single(order.order);
            Assert.Equal("Regina", order.order[0].Item1.title);
            Assert.Equal(3, order.order[0].Item2);
        }
    }
}
