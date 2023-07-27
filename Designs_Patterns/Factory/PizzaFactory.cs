using System;
using Designs_Patterns.Model;

namespace Designs_Patterns.Factory
{
    public abstract class PizzaFactory
    {
        public abstract PizzaProps CreatePizza();

        public virtual void MakingPizza(PizzaProps pizza)
        {
            Console.WriteLine("Préparer la pâte");
            foreach (IngerdientsProps ingerdients in pizza.recipe)
            {
                 Console.WriteLine("Ajouter " + ingerdients.foodProps.name);
            }

            
        }

    }
}

