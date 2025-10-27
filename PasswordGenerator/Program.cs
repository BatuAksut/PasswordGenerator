using System;

namespace PasswordGenerator
{
  class Program
  {
    // FIXME: system crash.
    // to repro: select "3", provide your own character pool, type Enter (without providing any character), type '6' as the length of the password.
    // TODO: after you fixed everything, you can start introducing some unit tests.
    static void Main()
    {
      bool isRunning = true;

      while (isRunning)
      {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Password Manager\n");
        Console.ResetColor();

        // FIXME: try to better print this text. I don't think is the best approach to use the "+" operator to concatenate literals.
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

        string? input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Invalid input! Please try again.");
          Console.ResetColor();
          continue;
        }

        switch (input)
        {
          case "1":
            PasswordGenerator.GenerateDefaultPassword();
            break;

          case "2":
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter length");
            Console.WriteLine();
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
            Console.WriteLine("Would you like to provide your own character set? (y/n)");
            Console.ResetColor();

            var customSetChoice = Console.ReadLine()?.Trim().ToLower();

            if (customSetChoice == "y")
            {
              Console.ForegroundColor = ConsoleColor.Cyan;
              Console.WriteLine("Enter your custom character set (example: aAbBcC123!@#):");
              Console.ResetColor();

              string? customSet = Console.ReadLine();

              // FIXME: warning to be fixed. Treat all the warnings as if they were errors
              PasswordGenerator.GeneratePasswordFromCustomSet(customSet);
              break;
            }

            Console.WriteLine("Choose sets");
            Console.WriteLine("Include lowercase letters (a-z)? (y/n)");
            Console.WriteLine();
            var includeLowercase = Console.ReadLine();

            Console.WriteLine("Include uppercase letters (A-Z)? (y/n)");
            Console.WriteLine();
            var includeUppercase = Console.ReadLine();

            Console.WriteLine("Include digits (0-9)? (y/n)");
            Console.WriteLine();
            var includeDigits = Console.ReadLine();

            Console.WriteLine("Include symbols (!@#$%^&*)? (y/n)");
            Console.WriteLine();
            var includeSymbols = Console.ReadLine();

            Console.ResetColor();

            bool? includeLowercaseBool =
                !string.IsNullOrEmpty(includeLowercase) && includeLowercase.ToLower() == "y" ? true :
                !string.IsNullOrEmpty(includeLowercase) && includeLowercase.ToLower() == "n" ? false : null;

            bool? includeUppercaseBool =
                !string.IsNullOrEmpty(includeUppercase) && includeUppercase.ToLower() == "y" ? true :
                !string.IsNullOrEmpty(includeUppercase) && includeUppercase.ToLower() == "n" ? false : null;

            bool? includeDigitsBool =
                !string.IsNullOrEmpty(includeDigits) && includeDigits.ToLower() == "y" ? true :
                !string.IsNullOrEmpty(includeDigits) && includeDigits.ToLower() == "n" ? false : null;

            bool? includeSymbolsBool =
                !string.IsNullOrEmpty(includeSymbols) && includeSymbols.ToLower() == "y" ? true :
                !string.IsNullOrEmpty(includeSymbols) && includeSymbols.ToLower() == "n" ? false : null;

            PasswordGenerator.GenerateSpecificPassword(
                includeLowercaseBool,
                includeUppercaseBool,
                includeDigitsBool,
                includeSymbolsBool
            );
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
            Console.WriteLine("Invalid input! Please try again.");
            Console.ResetColor();
            continue;
        }
      }
    }
  }
}
