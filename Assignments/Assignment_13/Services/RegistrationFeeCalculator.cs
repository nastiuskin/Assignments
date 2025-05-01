using Assignment_13.Abstractions;

namespace Assignment_13.Services
{
    public class RegistrationFeeCalculator : IRegistrationFeeCalculator
    {
        public int CalculateFee(int? experience)
        {
            int exp = experience ?? 0;

            return experience switch
            {
                <= 1 => 500,
                <= 3 => 250,
                <= 5 => 100,
                <= 9 => 50,
                _ => 0
            };
        }
    }
}
