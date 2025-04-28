using Assignment_14.Enums;

namespace Assignment_14.Contracts
{
    public interface ICoffeeFactory
    {
        public Coffee CreateCappuccino(MilkType milkType);
        public Coffee CreateEspresso();
        public Coffee CreateFlatWhite(MilkType milkType);
    }   
}
