using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGenerator
{
    public static class CharacterSets
    {
        public static string Lowercase = "abcdefghijklmnopqrstuvwxyz";
        public static string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string Digits = "0123456789";
        public static string Symbols = "!@#$%^&*";
        public static string AllCharacters => Lowercase + Uppercase + Digits + Symbols;
    }
}
