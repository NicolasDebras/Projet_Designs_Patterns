using System;
using Xunit;
using Designs_Patterns.Error.Billing;
using Designs_Patterns.Model;
using Designs_Patterns.Service;
using Designs_Patterns;
using Designs_Patterns.Factory;
using Designs_Patterns.Strategy;

namespace Tests
{
    public class BillingServiceTests
    {
        [Fact]
        public void TestPrintBillingWithNoOrderThrowsException()
        {
            var orderProps = new OrderProps();
            var billingService = new billingService(orderProps);

            Assert.Throws<NoPizzaBillingException>(() => billingService.printbilling());
            PizzaProps pizzaProps;
        }

        [Fact]
        public void TestPrintBillingWithOrderCalculatesTotal()
        {
            var orderProps = new OrderProps
            {
                order = new List<Tuple<PizzaProps, int>>
                {
                    new Tuple<PizzaProps, int>(ReginaPizzaFactory.Instance.CreatePizza(), 1)
                }
            };

            var billingService = new billingService(orderProps);
            billingService.printbilling();

            Assert.Equal(8, billingService.total);
        }

        [Fact]
        public void TestApplyPromotionWithValidStrategy()
        {
            
            var orderProps = new OrderProps
            {
                order = new List<Tuple<PizzaProps, int>>
                {
                    new Tuple<PizzaProps, int>(ReginaPizzaFactory.Instance.CreatePizza(), 10)
                }
            };

            var billingService = new billingService(orderProps);
            billingService.ApplyPromotion(new IndividualPromotionStrategy()); 

            billingService.printbilling();

            Assert.Equal(64, billingService.total);
        }

        [Fact]
        public void TestApplyGroupPromotionWithValidStrategy()
        {
            var orderProps = new OrderProps
            {
                order = new List<Tuple<PizzaProps, int>>
                {
                    new Tuple<PizzaProps, int>(ReginaPizzaFactory.Instance.CreatePizza(), 3)
                }
            };

            var billingService = new billingService(orderProps);
            
            billingService.ApplyPromotion(new GroupPromotionStrategy());
            billingService.printbilling();
            Assert.Equal(16, billingService.total);
        }

        [Fact]
        public void TestApplyGroupPromotionWithNotValidStrategy()
        {
            var orderProps = new OrderProps
            {
                order = new List<Tuple<PizzaProps, int>>
                {
                    new Tuple<PizzaProps, int>(ReginaPizzaFactory.Instance.CreatePizza(), 1)
                }
            };

            var billingService = new billingService(orderProps);
            
            billingService.ApplyPromotion(new GroupPromotionStrategy());
            billingService.printbilling();
            Assert.Equal(8, billingService.total);
        }
    }
}
