using System.Linq.Expressions;

bool isRunning = true;

string lowercase = "abcdefghijklmnopqrstuvwxyz";
string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
string digits = "0123456789";
string symbols = "!@#$%^&*";
string allcharacters = lowercase + uppercase + digits + symbols;



while (isRunning)
{
    Console.WriteLine("Password Manager");
    Console.WriteLine("1. Generate default password\r\n" +
        "2. Generate password of specific length\r\n" +
        "3. Generate password from specific character sets\r\n" +
        "4. Generate password without lowercase\r\n" +
        "5. Generate password without uppercase\r\n" +
        "6. Generate password without digits\r\n" +
        "7. Generate password without symbols\r\n" +
        "8. Exit");
    string input = Console.ReadLine();
    switch (input)
    {
        case "1":
            GenerateDefaultPassword();
            break;

        case "2":
            Console.WriteLine("Enter length");
            var length = Console.ReadLine();
            if (!int.TryParse(length, out int intLength) || intLength <= 0)
            {
                Console.WriteLine("Invalid length");
                break;
            }
            GeneratePasswordWithLength(intLength);
            break;

        case "3":
            Console.WriteLine("Choose sets");
            Console.WriteLine("Include lowercase letters(a - z) ? (y/n)");
            var includeLowercase = Console.ReadLine();
            Console.WriteLine("Include uppercase letters (A-Z) ? (y/n)");
            var includeUppercase = Console.ReadLine();
            Console.WriteLine("Include digits (0-9) ? (y/n)");
            var includeDigits = Console.ReadLine();
            Console.WriteLine("Include symbols (!@#$%^&*) ? (y/n)");
            var includeSymbols = Console.ReadLine();
            bool? includeLowercaseBool = includeLowercase.ToLower() == "y" ? true : includeLowercase.ToLower() == "n" ? false : null;
            bool? includeUppercaseBool = includeUppercase.ToLower() == "y" ? true : includeUppercase.ToLower() == "n" ? false : null;
            bool? includeDigitsBool = includeDigits.ToLower() == "y" ? true : includeDigits.ToLower() == "n" ? false : null;
            bool? includeSymbolsBool = includeSymbols.ToLower() == "y" ? true : includeSymbols.ToLower() == "n" ? false : null;

            GenerateSpecificPassword(includeLowercaseBool, includeUppercaseBool, includeDigitsBool, includeSymbolsBool);
            break;


        case "4":
            GeneratePasswordWithoutLowercase();
            break;

        case "5":
            GeneratePasswordWithoutUpperCase();
            break;
        case "6":
            GeneratePasswordWithoutDigits();
            break;
        case "7":
            GeneratePasswordWithoutSymbols();
            break;
        case "8":
            Console.WriteLine("Exiting");
            isRunning = false;
            break;

        default:
            Console.WriteLine("Unknown command");
            isRunning = false;
            break;
    }


}

void GeneratePasswordWithoutSymbols()
{
    string characters = "";
    characters += lowercase;
    characters += digits;
    characters += uppercase;

    Random rnd = new Random();
    var password = "";
    for (int i = 0; i < 12; i++)
    {
        var number = rnd.Next(0, characters.Length);
        password += characters[number];
    }
    Console.WriteLine("\nPassword Generated:");
    Console.WriteLine(password);
    Console.WriteLine("\n\n");
}

void GeneratePasswordWithoutDigits()
{
    string characters = "";
    characters += lowercase;
    characters += uppercase;
    characters += symbols;

    Random rnd = new Random();
    var password = "";
    for (int i = 0; i < 12; i++)
    {
        var number = rnd.Next(0, characters.Length);
        password += characters[number];
    }
    Console.WriteLine("\nPassword Generated:");
    Console.WriteLine(password);
    Console.WriteLine("\n\n");
}

void GeneratePasswordWithoutUpperCase()
{
    string characters = "";
    characters += lowercase;
    characters += digits;
    characters += symbols;

    Random rnd = new Random();
    var password = "";
    for (int i = 0; i < 12; i++)
    {
        var number = rnd.Next(0, characters.Length);
        password += characters[number];
    }
    Console.WriteLine("\nPassword Generated:");
    Console.WriteLine(password);
    Console.WriteLine("\n\n");
}

void GeneratePasswordWithoutLowercase()
{
    string characters = "";
    characters += uppercase;
    characters += digits;
    characters += symbols;

    Random rnd = new Random();
    var password = "";
    for (int i = 0; i < 12; i++)
    {
        var number = rnd.Next(0, characters.Length);
        password += characters[number];
    }
    Console.WriteLine("\nPassword Generated:");
    Console.WriteLine(password);
    Console.WriteLine("\n\n");
}

void GenerateSpecificPassword(bool? includeLowercaseBool, bool? includeUppercaseBool, bool? includeDigitsBool, bool? includeSymbolsBool)
{
    if (includeLowercaseBool == null || includeUppercaseBool == null || includeDigitsBool == null || includeSymbolsBool == null)
    {
        Console.WriteLine("Invalid input");
        return;
    }

    if (includeLowercaseBool == true && includeUppercaseBool == true && includeDigitsBool == true && includeSymbolsBool == true)
    {
        GenerateDefaultPassword();
        return;
    }

    string characters = "";
    if (includeLowercaseBool == true) characters += lowercase;
    if (includeUppercaseBool == true) characters += uppercase;
    if (includeDigitsBool == true) characters += digits;
    if (includeSymbolsBool == true) characters += symbols;
    if (characters == "")
    {
        Console.WriteLine("No character sets selected");
        return;
    }

    Random rnd = new Random();
    var password = "";
    for (int i = 0; i < 12; i++)
    {
        var number = rnd.Next(0, characters.Length);
        password += characters[number];
    }
    Console.WriteLine("\nPassword Generated:");
    Console.WriteLine(password);
    Console.WriteLine("\n\n");
}

void GeneratePasswordWithLength(int length)
{
    Random rnd = new Random();
    var password = "";
    for (int i = 0; i < length; i++)
    {
        var number = rnd.Next(1, allcharacters.Length);
        password += allcharacters[number];
    }
    Console.WriteLine("\nPassword Generated:");
    Console.WriteLine(password);
    Console.WriteLine("\n\n");
}

void GenerateDefaultPassword()
{
    Random rnd = new Random();
    var password = "";
    for (int i = 0; i < 12; i++)
    {
        var number = rnd.Next(0, allcharacters.Length);
        password += allcharacters[number];
    }
    Console.WriteLine("\nPassword Generated:");
    Console.WriteLine(password);
    Console.WriteLine("\n\n");
}