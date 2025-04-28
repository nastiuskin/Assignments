using Assignment_14.Contracts;
using Assignment_14.Enums;

namespace Assignment_14
{
    public class Coffee : IDrink
    {
        public int BlackCoffeeShots { get; set; }
        public int MilkShots { get; set; }
        public MilkType? Milk { get; set; }
        public int SugarCount { get; set; }

        public void AddBlackCoffeeShot() => BlackCoffeeShots++;

        public void AddMilkShot(MilkType milkType)
        {
            MilkShots++;
            Milk = milkType;
        }

        public void AddSugar() => SugarCount++;

        public string GetDescription()
        {
            var description = $"{BlackCoffeeShots}x Black Coffee";
            if (MilkShots > 0)
            {
                description += $" + {MilkShots}x {Milk?.ToString() ?? "Milk"}";
            }
            if (SugarCount > 0)
            {
                description += $" + {SugarCount}x Sugar";
            }
            return description;
        }
    }
}
