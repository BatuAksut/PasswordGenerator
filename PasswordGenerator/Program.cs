using System;
namespace PasswordGenerator;
class Program
{
    static void Main()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Password Manager");
            Console.ResetColor();

            Console.WriteLine(
                "1. Generate default password\r\n" +
                "2. Generate password of specific length\r\n" +
                "3. Generate password from specific character sets\r\n" +
                "4. Generate password without lowercase\r\n" +
                "5. Generate password without uppercase\r\n" +
                "6. Generate password without digits\r\n" +
                "7. Generate password without symbols\r\n" +
                "8. Exit"
            );

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    PasswordGenerator.GenerateDefaultPassword();
                    break;

                case "2":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Enter length");
                    Console.ResetColor();
                    var length = Console.ReadLine();
                    if (!int.TryParse(length, out int intLength) || intLength <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid length");
                        Console.ResetColor();
                        break;
                    }
                    PasswordGenerator.GenerateDefaultPassword(intLength);
                    break;

                case "3":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Choose sets");
                    Console.WriteLine("Include lowercase letters(a - z) ? (y/n)");
                    var includeLowercase = Console.ReadLine();
                    Console.WriteLine("Include uppercase letters (A-Z) ? (y/n)");
                    var includeUppercase = Console.ReadLine();
                    Console.WriteLine("Include digits (0-9) ? (y/n)");
                    var includeDigits = Console.ReadLine();
                    Console.WriteLine("Include symbols (!@#$%^&*) ? (y/n)");
                    var includeSymbols = Console.ReadLine();
                    Console.ResetColor();

                    bool? includeLowercaseBool = includeLowercase.ToLower() == "y" ? true : includeLowercase.ToLower() == "n" ? false : null;
                    bool? includeUppercaseBool = includeUppercase.ToLower() == "y" ? true : includeUppercase.ToLower() == "n" ? false : null;
                    bool? includeDigitsBool = includeDigits.ToLower() == "y" ? true : includeDigits.ToLower() == "n" ? false : null;
                    bool? includeSymbolsBool = includeSymbols.ToLower() == "y" ? true : includeSymbols.ToLower() == "n" ? false : null;

                    PasswordGenerator.GenerateSpecificPassword(includeLowercaseBool, includeUppercaseBool, includeDigitsBool, includeSymbolsBool);
                    break;

                case "4":
                    PasswordGenerator.GenerateDefaultPassword(without: "lower");
                    break;

                case "5":
                    PasswordGenerator.GenerateDefaultPassword(without: "upper");
                    break;

                case "6":
                    PasswordGenerator.GenerateDefaultPassword(without: "digits");
                    break;

                case "7":
                    PasswordGenerator.GenerateDefaultPassword(without: "symbols");
                    break;

                case "8":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Exiting");
                    Console.ResetColor();
                    isRunning = false;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unknown command");
                    Console.ResetColor();
                    isRunning = false;
                    break;
            }
        }
    }
}
