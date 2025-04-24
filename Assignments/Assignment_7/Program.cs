using Assignment_7;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string name;
            int age;

        #if DEBUG
            name = "Nastiuskin";
            age = 22;
            Console.WriteLine($"[DEBUG] Using test values — Name: {name}, Age: {age}");
        #else
            name = GetUserName();
            age = GetUserAge();
        #endif

            Console.WriteLine($"Final Info — Name: {name}, Age: {age}");
        }
        catch (Exception ex)
        {
            LogError(ex);
        }
        finally
        {
            Console.WriteLine("Validation completed.");
        }
    }

    public static string GetUserName()
    {
        int attempts = 0;
        const int maxAttempts = 4;

        while (attempts < maxAttempts)
        {
            Console.WriteLine("Enter your name: ");
            var name = Console.ReadLine();
            try
            {
                InputValidator.ValidateName(name);
                return name;
            }
            catch (InvalidNameException ex)
            {
                Console.WriteLine(ex.Message);
                attempts++;

                if (attempts >= maxAttempts)
                {
                    Console.WriteLine("Max attempts reached for name input");
                    throw;
                }
                Console.WriteLine("Please try again.");
            }
        }

        return string.Empty;
    }

    public static int GetUserAge()
    {
        int attempts = 0;
        const int maxAttempts = 3;

        while (attempts < maxAttempts)
        {
            Console.WriteLine("Enter your age:");
            string input = Console.ReadLine();
            try
            {
                int age = int.Parse(input);
                InputValidator.ValidateAge(age);
                return age;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please enter a valid age.");
                attempts++;
            }
            catch (InvalidAgeException ex)
            {
                Console.WriteLine(ex.Message);
                attempts++;

                if (attempts >= maxAttempts)
                {
                    Console.WriteLine("Max attempts reached for age input.");
                    throw;
                }

                Console.WriteLine("Please try again.");
            }
        }

        return 0;
    }

    static void LogError(Exception ex)
    {
        Console.WriteLine($"Logged error: {ex.Message}");
    }
}

