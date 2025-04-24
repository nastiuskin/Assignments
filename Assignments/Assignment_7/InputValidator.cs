namespace Assignment_7
{
    public class InputValidator
    {
        public static void ValidateAge(int age)
        {
            if (age <=  0)
                throw new InvalidAgeException("Age must be greater than 0");
        }

        public static void ValidateName(string? name)
        {
            if (string.IsNullOrEmpty(name))
                throw new InvalidNameException("Name cannot be empty");
        }
    }
}
