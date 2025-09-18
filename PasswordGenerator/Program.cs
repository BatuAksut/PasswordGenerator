using System.Linq.Expressions;

Console.WriteLine("Hello, World!");

bool isRunning = true;


string lowercase = "abcdefghijklmnopqrstuvwxyz";
string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
string digits = "0123456789";
string symbols = "!@#$%^&*()";



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
            Console.WriteLine("test");
            break;

        case "3":
            Console.WriteLine("test");
            break;
        case "4":
            Console.WriteLine("test");
            break;

        case "5":
            Console.WriteLine("test");
            break;
        case "6":
            Console.WriteLine("test");
            break;
        case "7":
            Console.WriteLine("test");
            break;
        case "8":
            Console.WriteLine("test");
            isRunning = false;
            break;

        default:
            Console.WriteLine("Unknown command");
            isRunning = false;
            break;
    }


}

void GenerateDefaultPassword()
{
    //to do: implement password generation logic
    Random rnd = new Random();
    var number = rnd.Next(1, lowercase.Length);
}