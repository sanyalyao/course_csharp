using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;
        public static Random rnd = new Random();

        [SetUp]
        public void SetupApplicationManager()
        {            
            app = ApplicationManager.GetInstance();
        }

        public static string GenerateRandomString(int number)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * number);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 223)));
            }
            return builder.ToString();
        }

        public static string GenerateRandomEmail()
        {
            StringBuilder builder = new StringBuilder();
            List<char> characters = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (Char)i).ToList();
            builder.Append(characters[rnd.Next(characters.Count())], 5);
            builder.Append("@");
            builder.Append(characters[rnd.Next(characters.Count())], 5);
            return builder.ToString();
        }

        public static string GenerateRandomPhone()
        {
            StringBuilder builder = new StringBuilder();
            List<string> characters = new List<string>()
            {
                "",
                "-",
                " ",
                "(",
                ")"
            };
            int randomCharacter = rnd.Next(characters.Count);
            builder.Append(characters[randomCharacter]);
            builder.Append(rnd.Next(100,1000));
            builder.Append(characters[randomCharacter]);
            builder.Append(rnd.Next(100,1000));
            builder.Append(characters[randomCharacter]);
            builder.Append(rnd.Next(10,100));
            builder.Append(characters[randomCharacter]);
            builder.Append(rnd.Next(10,100));
            return $"+7{builder}";
        }

        public static string GetRandomDay()
        {
            return rnd.Next(0, 31).ToString();
        }

        public static string GetRandomMonth()
        {
            List<string> months = DateTimeFormatInfo.CurrentInfo.MonthNames.ToList();
            return months[rnd.Next(months.Count())];
        }
        public static string GenerateRandomYear()
        {
            return rnd.Next(1000, 9999).ToString();
        }

        public static string GenerateRandomWebSite()
        {
            StringBuilder builder = new StringBuilder();
            List<char> characters = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (Char)i).ToList();
            builder.Append(characters[rnd.Next(characters.Count)], 5);
            return $"{builder}.com" ;
        }
    }
}
