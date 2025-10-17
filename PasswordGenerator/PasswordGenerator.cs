using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public static class PasswordGenerator
    {
        private static readonly Random rnd = new Random();

        public static void GenerateDefaultPassword(int? length = null, string? without = null)
        {
            int passwordLength = length ?? 12;
            string characters;

            switch (without?.ToLower())
            {
                case "lower":
                    characters = CharacterSets.Uppercase + CharacterSets.Digits + CharacterSets.Symbols;
                    break;
                case "upper":
                    characters = CharacterSets.Lowercase + CharacterSets.Digits + CharacterSets.Symbols;
                    break;
                case "digits":
                    characters = CharacterSets.Lowercase + CharacterSets.Uppercase + CharacterSets.Symbols;
                    break;
                case "symbols":
                    characters = CharacterSets.Lowercase + CharacterSets.Uppercase + CharacterSets.Digits;
                    break;
                default:
                    characters = CharacterSets.AllCharacters;
                    break;
            }

            string password = GeneratePasswordString(characters, passwordLength);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPassword Generated:");
            Console.WriteLine(password);
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void GenerateSpecificPassword(bool? includeLowercaseBool, bool? includeUppercaseBool, bool? includeDigitsBool, bool? includeSymbolsBool)
        {
            if (includeLowercaseBool == null || includeUppercaseBool == null || includeDigitsBool == null || includeSymbolsBool == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input");
                Console.ResetColor();
                return;
            }

            if (includeLowercaseBool.Value && includeUppercaseBool.Value && includeDigitsBool.Value && includeSymbolsBool.Value)
            {
                GenerateDefaultPassword();
                return;
            }

            string characters = "";
            if (includeLowercaseBool.Value) characters += CharacterSets.Lowercase;
            if (includeUppercaseBool.Value) characters += CharacterSets.Uppercase;
            if (includeDigitsBool.Value) characters += CharacterSets.Digits;
            if (includeSymbolsBool.Value) characters += CharacterSets.Symbols;

            if (string.IsNullOrEmpty(characters))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No character sets selected");
                Console.ResetColor();
                return;
            }

            string password = GeneratePasswordString(characters, 12);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPassword Generated:");
            Console.WriteLine(password);
            Console.ResetColor();
            Console.WriteLine();
        }

        private static string GeneratePasswordString(string characters, int length)
        {
            char[] password = new char[length];
            for (int i = 0; i < length; i++)
            {
                password[i] = characters[rnd.Next(characters.Length)];
            }
            return new string(password);
        }

        public static void GeneratePasswordFromCustomSet(string customSet)
        {
            if (string.IsNullOrEmpty(customSet))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Character set cannot be empty.");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("Enter password length:");
            string? lengthInput = Console.ReadLine();
            if (!int.TryParse(lengthInput, out int length) || length <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid length. Try again.");
                Console.ResetColor();
                return;
            }

            Random rnd = new();
            char[] password = new char[length];
            for (int i = 0; i < length; i++)
                password[i] = customSet[rnd.Next(customSet.Length)];

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Generated password: {new string(password)}");
            Console.ResetColor();
        }

    }
}
