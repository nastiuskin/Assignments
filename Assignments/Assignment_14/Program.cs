using Assignment_14;
using Assignment_14.Contracts;
using Assignment_14.Enums;
using Assignment_14.Factories;

ICoffeeFactory coffeeFactory = new CoffeeFactory();

IDrink espresso = coffeeFactory.CreateEspresso();   
Console.WriteLine("1. Espresso: " + espresso.GetDescription());

IDrink cappuccino = coffeeFactory.CreateCappuccino(MilkType.Oat);
Console.WriteLine("2. Cappuccino (Oat Milk): " + cappuccino.GetDescription());

IDrink flatWhite = coffeeFactory.CreateFlatWhite(MilkType.Regular);
Console.WriteLine("3. Flat White (Regular Milk): " + flatWhite.GetDescription());

ICoffeeBuilder builder = new CoffeeBuilder(coffeeFactory.CreateFlatWhite(MilkType.Soy));
IDrink flatWhiteWithSugar = builder
    .AddSugar()
    .Build();
Console.WriteLine("3. Flat White + 1 Sugar: " + flatWhiteWithSugar.GetDescription());

builder = new CoffeeBuilder(coffeeFactory.CreateEspresso());
IDrink customEspresso = builder
    .AddMilk(MilkType.Soy)
    .AddSugar()
    .AddSugar()
    .Build();
Console.WriteLine("4. Custom Espresso (Soy Milk + 2x Sugar): " + customEspresso.GetDescription());

builder = new CoffeeBuilder();
IDrink customCrazyCoffee = builder
    .AddBlackCoffee()
    .AddBlackCoffee()
    .AddBlackCoffee()
    .AddMilk(MilkType.Oat)
    .AddMilk(MilkType.Oat)
    .AddSugar()
    .Build();
Console.WriteLine("5. Crazy Coffee: " + customCrazyCoffee.GetDescription());
