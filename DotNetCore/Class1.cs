using System;
using System.Linq;
using TextToSpeech;

namespace DotNetCore
{
    public static class StringGenerator
    {
        private static Random random = new Random();
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string GenerateString(int length = 8)
        {
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
            // We can reference .NET framework from Core
            // Program.Main();
        }
    }
}
