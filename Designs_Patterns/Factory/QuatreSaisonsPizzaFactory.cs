using System;
using Designs_Patterns.Model;

namespace Designs_Patterns.Factory
{
	public class QuatreSaisonsPizzaFactory : PizzaFactory
	{
        private static QuatreSaisonsPizzaFactory instance;
        public static QuatreSaisonsPizzaFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new QuatreSaisonsPizzaFactory();
                }
                return instance;
            }
        }

        private QuatreSaisonsPizzaFactory() { }


        public override PizzaProps CreatePizza()
        {
            FoodProps tomate = new FoodProps("tomate");
            FoodProps mozzarella = new FoodProps("mozzarella");
            FoodProps fromageRape = new FoodProps("fromage râpé");
            FoodProps jambon = new FoodProps("tranches de jambon");
            FoodProps champignons = new FoodProps("champignons frais");
            FoodProps huileOlive = new FoodProps("cuillères à soupe d'huile d'olive");
            FoodProps poivron = new FoodProps("poivron");
            FoodProps olives = new FoodProps("poignée d'olives");
            FoodProps courgette = new FoodProps("courgette");
            FoodProps tomatesCerises = new FoodProps("tomates cerises");

            IngerdientsProps quatreSaisonsTomate = new IngerdientsProps(150, tomate);
            IngerdientsProps quatreSaisonsMozzarella = new IngerdientsProps(125, mozzarella);
            IngerdientsProps quatreSaisonsJambon = new IngerdientsProps(2, jambon);
            IngerdientsProps quatreSaisonsChampignons = new IngerdientsProps(100, champignons);
            IngerdientsProps quatreSaisonsPoivron = new IngerdientsProps(0.5, poivron);
            IngerdientsProps quatreSaisonsOlives = new IngerdientsProps(1, olives);

            List<IngerdientsProps> RecipeQuatreSaisons = new List<IngerdientsProps>();
            RecipeQuatreSaisons.Add(quatreSaisonsTomate);
            RecipeQuatreSaisons.Add(quatreSaisonsMozzarella);
            RecipeQuatreSaisons.Add(quatreSaisonsJambon);
            RecipeQuatreSaisons.Add(quatreSaisonsChampignons);
            RecipeQuatreSaisons.Add(quatreSaisonsPoivron);
            RecipeQuatreSaisons.Add(quatreSaisonsOlives);

            return new PizzaProps("4 Saisons", RecipeQuatreSaisons, 9);

        }
	}
}

