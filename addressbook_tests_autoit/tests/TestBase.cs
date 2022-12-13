using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace addressbook_tests_autoit
{
    public class TestBase
    {
        public ApplicationManager app;
        public static Random rnd = new Random();

        [TestFixtureSetUp]
        public void InitApplication()
        {
            app = new ApplicationManager();
        }

        [TestFixtureTearDown]
        public void StopApplication()
        {
            app.Stop();
        }

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[rnd.Next(s.Length)]).ToArray());
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
            builder.Append(rnd.Next(100, 1000));
            builder.Append(characters[randomCharacter]);
            builder.Append(rnd.Next(100, 1000));
            builder.Append(characters[randomCharacter]);
            builder.Append(rnd.Next(10, 100));
            builder.Append(characters[randomCharacter]);
            builder.Append(rnd.Next(10, 100));
            return $"+7{builder}";
        }

        public static string GetRandomDay()
        {
            return rnd.Next(0, 31).ToString();
        }

        public static string GetRandomMonth()
        {
            List<string> months = DateTimeFormatInfo.CurrentInfo.MonthNames.Where(month => month != "").ToList();
            return months[rnd.Next(months.Count())];
        }
        public static string GenerateRandomYear()
        {
            return rnd.Next(2000, DateTime.Now.Year).ToString();
        }

        public static string GenerateRandomWebSite()
        {
            StringBuilder builder = new StringBuilder();
            List<char> characters = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (Char)i).ToList();
            builder.Append(characters[rnd.Next(characters.Count)], 5);
            return $"{builder}.com";
        }

        public string GenerateRandomIdentifier()
        {
            string chars = "0123456789";
            string identifier = new string(Enumerable.Repeat(chars, rnd.Next(1, 10)).Select(s => s[rnd.Next(s.Length)]).ToArray());
            if (CheckIfIdentifierPersent(identifier))
            {
                identifier = new string(Enumerable.Repeat(chars, rnd.Next(1, 10)).Select(s => s[rnd.Next(s.Length)]).ToArray());
            }
            return identifier;
        }

        public static string GenerateRandomZip()
        {
            string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, 5).Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

        private bool CheckIfIdentifierPersent(string identifier)
        {
            return app.Contacts.GetIdentifiers().Contains(identifier);
        }
    }
}
