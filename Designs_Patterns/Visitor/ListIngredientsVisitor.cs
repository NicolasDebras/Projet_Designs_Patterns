using System;
using Designs_Patterns.Model;

namespace Designs_Patterns.Visitor
{
    public class ListIngredientsVisitor : IVisitor
    {
        public Dictionary<FoodProps, Dictionary<PizzaProps, double>> IngredientsUsage
            = new Dictionary<FoodProps, Dictionary<PizzaProps, double>>();

        private PizzaProps currentPizza;

        public void Visit(PizzaProps pizza)
        {
            currentPizza = pizza;
            foreach (var ingredient in pizza.recipe)
            {
                Visit(ingredient);
            }
        }

        public void Visit(IngerdientsProps ingredient)
        {
            if (!IngredientsUsage.TryGetValue(ingredient.foodProps, out var pizzas))
            {
                pizzas = new Dictionary<PizzaProps, double>();
                IngredientsUsage[ingredient.foodProps] = pizzas;
            }
            if (!pizzas.TryGetValue(currentPizza, out var count))
            {
                count = 0;
            }
            pizzas[currentPizza] = count + ingredient.quantity;
        }
    }
}

