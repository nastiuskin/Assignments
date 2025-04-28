using Assignment_14.Contracts;
using Assignment_14.Enums;

namespace Assignment_14
{
    public class CoffeeBuilder : ICoffeeBuilder
    {
        private Coffee _coffee;
        public CoffeeBuilder() => _coffee = new Coffee();

        public CoffeeBuilder(Coffee coffee) => _coffee = coffee;
        public Coffee Build()
        {
            return _coffee;
        }

        public ICoffeeBuilder AddBlackCoffee()
        {
            _coffee.BlackCoffeeShots++;
            return this;
        }

        public ICoffeeBuilder AddMilk(MilkType milkType)
        {
            _coffee.MilkShots++;
            _coffee.Milk = milkType;
            return this;
        }
        public ICoffeeBuilder AddSugar()
        {
            _coffee.SugarCount++;
            return this;
        }
    }
}
