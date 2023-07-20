using Designs_Patterns;
using Designs_Patterns.Model;
using Designs_Patterns.Service;

// Définition des ingrédients
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

// Définition des ingrédients pour chaque pizza
IngerdientsProps reginaTomate = new IngerdientsProps(150, tomate);
IngerdientsProps reginaMozzarella = new IngerdientsProps(125, mozzarella);
IngerdientsProps reginaFromageRape = new IngerdientsProps(100, fromageRape);
IngerdientsProps reginaJambon = new IngerdientsProps(2, jambon);
IngerdientsProps reginaChampignons = new IngerdientsProps(4, champignons);
IngerdientsProps reginaHuileOlive = new IngerdientsProps(2, huileOlive);

IngerdientsProps quatreSaisonsTomate = new IngerdientsProps(150, tomate);
IngerdientsProps quatreSaisonsMozzarella = new IngerdientsProps(125, mozzarella);
IngerdientsProps quatreSaisonsJambon = new IngerdientsProps(2, jambon);
IngerdientsProps quatreSaisonsChampignons = new IngerdientsProps(100, champignons);
IngerdientsProps quatreSaisonsPoivron = new IngerdientsProps(0.5, poivron);
IngerdientsProps quatreSaisonsOlives = new IngerdientsProps(1, olives);

IngerdientsProps vegetarienneTomate = new IngerdientsProps(150, tomate);
IngerdientsProps vegetarienneMozzarella = new IngerdientsProps(100, mozzarella);
IngerdientsProps vegetarienneCourgette = new IngerdientsProps(0.5, courgette);
IngerdientsProps vegetariennePoivron = new IngerdientsProps(1, poivron);
IngerdientsProps vegetarienneTomatesCerises = new IngerdientsProps(6, tomatesCerises);
IngerdientsProps vegetarienneOlives = new IngerdientsProps(5, olives);


List<IngerdientsProps> RecipeRegina = new List<IngerdientsProps>();
RecipeRegina.Add(reginaTomate);
RecipeRegina.Add(reginaMozzarella);
RecipeRegina.Add(reginaFromageRape);
RecipeRegina.Add(reginaJambon);
RecipeRegina.Add(reginaChampignons);
RecipeRegina.Add(reginaHuileOlive);

List<IngerdientsProps> RecipeQuatreSaisons = new List<IngerdientsProps>();
RecipeQuatreSaisons.Add(quatreSaisonsTomate);
RecipeQuatreSaisons.Add(quatreSaisonsMozzarella);
RecipeQuatreSaisons.Add(quatreSaisonsJambon);
RecipeQuatreSaisons.Add(quatreSaisonsChampignons);
RecipeQuatreSaisons.Add(quatreSaisonsPoivron);
RecipeQuatreSaisons.Add(quatreSaisonsOlives);

List<IngerdientsProps> RecipeVegetarienne = new List<IngerdientsProps>();
RecipeVegetarienne.Add(vegetarienneTomate);
RecipeVegetarienne.Add(vegetarienneMozzarella);
RecipeVegetarienne.Add(vegetarienneCourgette);
RecipeVegetarienne.Add(vegetariennePoivron);
RecipeVegetarienne.Add(vegetarienneTomatesCerises);
RecipeVegetarienne.Add(vegetarienneOlives);


List<PizzaProps> InitMenu = new List<PizzaProps>();
InitMenu.Add(new PizzaProps("Regina",RecipeRegina ,8));
InitMenu.Add(new PizzaProps("4 Saisons ", RecipeRegina, 9));
InitMenu.Add(new PizzaProps("Végétarienne", RecipeRegina, 7.5));


RestaurantProps restaurant = new RestaurantProps(InitMenu);


OrderService order = new OrderService(restaurant);
OrderProps res = order.CreateOrder();

billingService billing = new billingService(res);
billing.printbilling();

MakingService making = new MakingService(res);
making.Making();




