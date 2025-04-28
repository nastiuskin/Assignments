using Assignment_14.Enums;

namespace Assignment_14.Contracts
{
    public interface ICoffeeBuilder
    {
        public ICoffeeBuilder AddBlackCoffee();
        public ICoffeeBuilder AddMilk(MilkType milkType);
        public ICoffeeBuilder AddSugar();
        public Coffee Build();
    }
}
