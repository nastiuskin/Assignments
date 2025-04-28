using Assignment_14.Contracts;
using Assignment_14.Enums;

namespace Assignment_14.Factories
{
    public class CoffeeFactory : ICoffeeFactory
    {
        public Coffee CreateEspresso()
        {
            return new CoffeeBuilder()
                .AddBlackCoffee()
                .Build();
        }

        public Coffee CreateFlatWhite(MilkType milkType)
        {
            return new CoffeeBuilder()
                .AddBlackCoffee()
                .AddBlackCoffee()
                .AddMilk(milkType)
                .Build();
        }

        public Coffee CreateCappuccino(MilkType milkType)
        {
            return new CoffeeBuilder()
               .AddBlackCoffee()
               .AddMilk(milkType)
               .Build();
        }
    }
}
