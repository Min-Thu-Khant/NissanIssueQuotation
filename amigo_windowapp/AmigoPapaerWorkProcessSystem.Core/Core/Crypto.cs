using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace AmigoPaperWorkProcessSystem.Core
{
    public static class Crypto
    {
        public static string Generate8DigitPassword()
        {
            const int MAXIMUM_IDENTICAL_CONSECUTIVE_CHARS = 2;

            const string SMALL_LETTERS = "abcdefghijklmnopqrstuvwxyz";

            const string CAPTAL_LETTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            const string NUMBERS = "0123456789";

            const string SPECIAL_LETTERS = @"!#$%&*@\";

            //random possible character pool
            List<string> CHARACTER_ARRAY = new List<string> { SMALL_LETTERS, CAPTAL_LETTERS, NUMBERS, SPECIAL_LETTERS };

            //character pool to generate raw password.
            string characterSet = "";


            //get 3 types from random pool
            System.Random random = new System.Random();
            CHARACTER_ARRAY.RemoveAt(random.Next(0, 3));

            for (int i = 0; i < 3; i++)
            {
                characterSet += CHARACTER_ARRAY[i];
            }


            //raw password holder
            char[] password = new char[8];

            for (int characterPosition = 0; characterPosition < 8; characterPosition++)
            {
                password[characterPosition] = characterSet[random.Next(characterSet.Length - 1)];

                bool moreThanTwoIdenticalInARow =
                    characterPosition >= MAXIMUM_IDENTICAL_CONSECUTIVE_CHARS
                    && password[characterPosition] == password[characterPosition - 1]
                    && password[characterPosition - 1] == password[characterPosition - 2];

                if (moreThanTwoIdenticalInARow)
                {
                    characterPosition--;
                }
            }

            //check if 8 random characters are 3 different types

            int SMALL_LETTER_COUNT = 0;
            int CAPITAL_LETTER_COUNT = 0;
            int NUMBER_COUNT = 0;
            int SPECIAL_LETTER_COUNT = 0;

            //Count each type
            for (int i = 0; i < password.Length; i++)
            {
                if (SMALL_LETTERS.Contains(password[i].ToString()))
                {
                    SMALL_LETTER_COUNT++;
                }
                else if (CAPTAL_LETTERS.Contains(password[i].ToString()))
                {
                    CAPITAL_LETTER_COUNT++;
                }
                else if (NUMBERS.Contains(password[i].ToString()))
                {
                    NUMBER_COUNT++;
                }
                else if (SPECIAL_LETTERS.Contains(password[i].ToString()))
                {
                    SPECIAL_LETTER_COUNT++;
                }
            }

            List<string> LEFT_RANDOM = new List<string>();

            if (SMALL_LETTER_COUNT == 0)
            {
                LEFT_RANDOM.Add(SMALL_LETTERS);
            }
            if (CAPITAL_LETTER_COUNT == 0)
            {
                LEFT_RANDOM.Add(CAPTAL_LETTERS);
            }

            if (NUMBER_COUNT == 0)
            {
                LEFT_RANDOM.Add(NUMBERS);
            }

            if (SPECIAL_LETTER_COUNT == 0)
            {
                LEFT_RANDOM.Add(SPECIAL_LETTERS);
            }

            string str_password = string.Join(null, password);

            if (LEFT_RANDOM.Count > 1)
            {
                //get random Character set wheren count = 0
                string leftcharSet = LEFT_RANDOM[random.Next(LEFT_RANDOM.Count - 1)];

                //replace last character with another random character 
                str_password = str_password.Remove(7, 1) + random.Next(leftcharSet.Length - 1).ToString();
            }

            return str_password;
        }

        public static string Generate6DigitPassword()
        {
            const int MAXIMUM_IDENTICAL_CONSECUTIVE_CHARS = 2;

            const string CAPTAL_LETTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            const string NUMBERS = "0123456789";

            //random possible character pool
            List<string> CHARACTER_ARRAY = new List<string> { CAPTAL_LETTERS, NUMBERS };

            //character pool to generate raw password.
            string characterSet = "";

            System.Random random = new System.Random();

            //raw password holder
            char[] password = new char[6];

            for (int characterPosition = 0; characterPosition < 6; characterPosition++)
            {
                password[characterPosition] = characterSet[random.Next(characterSet.Length - 1)];

                bool moreThanTwoIdenticalInARow =
                    characterPosition >= MAXIMUM_IDENTICAL_CONSECUTIVE_CHARS
                    && password[characterPosition] == password[characterPosition - 1]
                    && password[characterPosition - 1] == password[characterPosition - 2];

                if (moreThanTwoIdenticalInARow)
                {
                    characterPosition--;
                }
            }

            //check if 6 random characters are 2 different types

            int CAPITAL_LETTER_COUNT = 0;
            int NUMBER_COUNT = 0;

            //Count each type
            for (int i = 0; i < password.Length; i++)
            {
                if (CAPTAL_LETTERS.Contains(password[i].ToString()))
                {
                    CAPITAL_LETTER_COUNT++;
                }
                else if (NUMBERS.Contains(password[i].ToString()))
                {
                    NUMBER_COUNT++;
                }
            }

            List<string> LEFT_RANDOM = new List<string>();


            if (CAPITAL_LETTER_COUNT == 0)
            {
                LEFT_RANDOM.Add(CAPTAL_LETTERS);
            }

            if (NUMBER_COUNT == 0)
            {
                LEFT_RANDOM.Add(NUMBERS);
            }


            string str_password = string.Join(null, password);

            if (LEFT_RANDOM.Count > 1)
            {
                //get random Character set wheren count = 0
                string leftcharSet = LEFT_RANDOM[random.Next(LEFT_RANDOM.Count - 1)];

                //replace last character with another random character 
                str_password = str_password.Remove(7, 1) + random.Next(leftcharSet.Length - 1).ToString();
            }

            return str_password;
        }
    }
}
