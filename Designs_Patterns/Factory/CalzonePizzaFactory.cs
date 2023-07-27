using System;
using Designs_Patterns.Model;

namespace Designs_Patterns.Factory
{
	public class CalzonePizzaFactory : PizzaFactory
	{
        private static CalzonePizzaFactory instance;
        public static CalzonePizzaFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CalzonePizzaFactory();
                }
                return instance;
            }
        }

        private CalzonePizzaFactory() { }

        public override void MakingPizza(PizzaProps pizza)
        {
            Console.WriteLine("Préparer la pâte");
            foreach (IngerdientsProps ingerdients in pizza.recipe)
            {
                Console.WriteLine("Ajouter " + ingerdients.foodProps.name);
            }
            Console.WriteLine("fermer la pâte");
        }

        public override PizzaProps CreatePizza()
        {
            FoodProps tomate = new FoodProps("tomate");
            FoodProps mozzarella = new FoodProps("mozzarella");
            FoodProps fromageRape = new FoodProps("fromage râpé");
            FoodProps jambon = new FoodProps("tranches de jambon");
            FoodProps champignons = new FoodProps("champignons frais");
            FoodProps huileOlive = new FoodProps("cuillères à soupe d'huile d'olive");

            IngerdientsProps reginaTomate = new IngerdientsProps(150, tomate);
            IngerdientsProps reginaMozzarella = new IngerdientsProps(125, mozzarella);
            IngerdientsProps reginaFromageRape = new IngerdientsProps(100, fromageRape);
            IngerdientsProps reginaJambon = new IngerdientsProps(2, jambon);
            IngerdientsProps reginaChampignons = new IngerdientsProps(4, champignons);
            IngerdientsProps reginaHuileOlive = new IngerdientsProps(2, huileOlive);

            List<IngerdientsProps> RecipeRegina = new List<IngerdientsProps>();
            RecipeRegina.Add(reginaTomate);
            RecipeRegina.Add(reginaMozzarella);
            RecipeRegina.Add(reginaFromageRape);
            RecipeRegina.Add(reginaJambon);
            RecipeRegina.Add(reginaChampignons);
            RecipeRegina.Add(reginaHuileOlive);

            return new PizzaProps("Calzone", RecipeRegina, 8);

        }


        
    }
}

