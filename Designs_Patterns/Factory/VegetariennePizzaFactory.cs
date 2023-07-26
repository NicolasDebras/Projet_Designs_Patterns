using System;
using Designs_Patterns.Model;

namespace Designs_Patterns.Factory
{
    public class VegetariennePizzaFactory : PizzaFactory
    {
        private static VegetariennePizzaFactory instance;
        public static VegetariennePizzaFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VegetariennePizzaFactory();
                }
                return instance;
            }
        }

        private VegetariennePizzaFactory() { }

        public override PizzaProps CreatePizza()
        {
            FoodProps tomate = new FoodProps("tomate");
            FoodProps mozzarella = new FoodProps("mozzarella");
            FoodProps courgette = new FoodProps("courgette");
            FoodProps poivron = new FoodProps("poivron");
            FoodProps olives = new FoodProps("poignée d'olives");
            FoodProps tomatesCerises = new FoodProps("tomates cerises");

            IngerdientsProps vegetarienneTomate = new IngerdientsProps(150, tomate);
            IngerdientsProps vegetarienneMozzarella = new IngerdientsProps(100, mozzarella);
            IngerdientsProps vegetarienneCourgette = new IngerdientsProps(0.5, courgette);
            IngerdientsProps vegetariennePoivron = new IngerdientsProps(1, poivron);
            IngerdientsProps vegetarienneOlives = new IngerdientsProps(5, olives);
            IngerdientsProps vegetarienneTomatesCerises = new IngerdientsProps(6, tomatesCerises);

            List<IngerdientsProps> RecipeVegetarienne = new List<IngerdientsProps>();
            RecipeVegetarienne.Add(vegetarienneTomate);
            RecipeVegetarienne.Add(vegetarienneMozzarella);
            RecipeVegetarienne.Add(vegetarienneCourgette);
            RecipeVegetarienne.Add(vegetariennePoivron);
            RecipeVegetarienne.Add(vegetarienneOlives);
            RecipeVegetarienne.Add(vegetarienneTomatesCerises);

            return new PizzaProps("Végétarienne", RecipeVegetarienne, 8);
        }
    }

}

