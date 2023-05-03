# Projet Designs Patterns en C#

##Informations pratiques
Le code rendu devra compiler sans erreur.
Mieux vaut rendre un code incomplet qui compile qu'un code ne compilant pas. Le projet sera noté selon plusieurs critères :
➔ qualité du code fourni
➔ prise en compte des différents retours ➔ qualité de la soutenance finale
➔ pertinence des choix techniques
Vous n'oublierez pas d'inclure les slides de votre soutenance finale ainsi qu'un rapport PDF précisant vos choix, les problèmes techniques rencontrés et les solutions trouvées.
Un bonus pourra être attribué si votre code est suffisamment testé.

## Déroulement du projet
La réalisation du projet sera découpée en trois phases :
    1. Implémentation naïve d’une solution
    2. Extension des fonctionnalités et mise en place de design pattern
    3. Implémentation de modules supplémentaires “libres”
Pour l’implémentation naïve du projet, il vous est demandé de répondre aux contraintes présentées dans la suite de ce document sans réfléchir particulièrement aux design pattern qui pourraient s’y appliquer.
Cette réalisation doit être vue comme la mise en place d’un proof of concept et non comme la réalisation d’un produit fini, la suite du projet est là pour ça.
Lorsque vous devrez étendre les fonctionnalités une première fois tout en mettant en place les design pattern que vous jugerez adaptés, vous pourrez repartir du code fait précédemment ou recommencer une implémentation du début. Il n’y a pas de contrainte particulière sur ce point.
Enfin, la troisième et dernière partie de la réalisation de ce projet vous permettra d’étendre les fonctionnalités de votre projet en choisissant parmi un large choix de modules. Lors de vos choix, vous devrez réfléchir aux modules étant propices à la mise en place de design pattern et choisir ceux que vous voudrez ajouter en conséquence.
Les différentes étapes de ce projet seront présentées progressivement.
Afin d’évaluer votre réalisation, vous mettrez à disposition un dépôt git sur lequel seront facilement identifiables vos différentes versions.
Vous devrez finalement présenter votre résultat dans une soutenance qui devra mettre en avant vos différents choix de design pattern et devra également contenir une démonstration de votre exécutable final.
  
## Sujet
Une pizzeria souhaite simplifier sa prise de commande et l'élaboration de ses factures. Chaque pizza est constituée d'une liste précise d'ingrédients et possède un prix.
On souhaite écrire un programme qui prend en entrée une commande de pizzas et produit une facture formatée et/ou des instructions de préparation.
### Prise en compte des commandes
Votre programme devra récupérer les commandes sous la forme d'entrée textuelle en console. Les commandes sont de la forme :
A Pizza1
Où A est la quantité de Pizza1.
A Pizza1, B Pizza2, C Pizza3
Une commande peut contenir plusieurs occurrences de la même pizza, ainsi une commande de
la forme :
A Pizza1, B Pizza2, C Pizza1 devra être considérée comme :
 A+C Pizza1, B Pizza2

### Edition d'une facture
Après avoir interprété la commande en entrée, vous devez pouvoir produire une sortie console respectant le format suivant :
        A Pizza1 : A * XXX€ Ingredient1 Quantité1 Ingredient2 Quantité2 [...]
IngredientN QuantitéN B Pizza2 : B * XXX€ Ingredient1 Quantité1 [...]
Prix total : XXX€
### Édition des instructions de préparation

Après avoir interprété la commande en entrée, vous devez produire une sortie console respectant le format suivant :
  Pizza1
Préparer la pâte
Ajouter Ingredient1
Ajouter Ingredient2
[...]

  Ajouter IngredientN
Cuire la pizza
Pizza2
Préparer la pâte
Ajouter Ingredient1
[...]
Cuire la pizza

### Pizzas disponibles
La pizzeria est capable de produire les pizzas suivantes :
● Regina => 8€
    ○ 150g de tomate
    ○ 125g de mozzarella
    ○ 100g de fromage râpé
    ○ 2 tranches de Jambon
    ○ 4 champignons frais
    ○ 2 cuillères à soupe d’huile d’olive
● 4 Saisons => 9€
    ○ 150g de tomate
    ○ 125g de mozarella
    ○ 2 tranches de jambon
    ○ 100g de champignons frais
    ○ 0,5 poivron
    ○ 1 poignée d’olives
● Végétarienne =>7,50€
    ○ 150g de tomate
    ○ 100g de mozzarella
    ○ 0,5 courgette
    ○ 1 poivron jaune
    ○ 6 tomates cerises
    ○ quelques olives

###Comportement attendu du programme
Votre programme devra récupérer l'entrée de l'utilisateur et valider sa conformité.
En cas de commande incorrecte, votre programme produira une erreur compréhensible mais ne devra pas crasher.
En cas de commande correcte, votre programme écrira dans la console la facture et/ou les instructions de préparation.
Après avoir traité une commande, votre programme attendra la commande suivante, il ne doit pas s'arrêter après avoir écrit sa sortie.
  