# Password Generator

## Description
A simple console-based Password Manager and Generator built in C#.  
It allows users to create secure passwords with different configurations such as length, character sets, or fully custom-defined character pools.

## Layout of the Solution
```
PasswordGenerator/
│
├── Program.cs
├── PasswordGenerator.cs
├── README.md  
└── password_manager.md
```

## How to Build
1. Open the project in **Visual Studio** or **VS Code**.
2. Ensure you have **.NET SDK 8.0 or newer** installed.
3. Build the project:
   ```bash
   dotnet build
   ```

## How to Run
Execute the following command from the project directory:
```bash
dotnet run
```
The application will launch in the terminal and display the Password Manager menu.

## Functionalities
- Generate a default password using all available characters.
- Generate a password with custom length.
- Generate a password from chosen character sets (lowercase, uppercase, digits, symbols).
- Generate a password without certain character types (e.g., no digits).
- Generate a password using a **fully custom character set** provided by the user.
