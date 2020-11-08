using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace AmigoProcessManagement.Utility
{
    public class Crypto
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawPassword"></param>
        /// <returns></returns>
        public static string HashPassword(string rawPassword)
        {
            //generate salt
            string salt = GenerateSalt();

            return GenerateHashedString(rawPassword, salt);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawPassword"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string HashPassword(string rawPassword, string salt)
        {
            if (String.IsNullOrEmpty(salt))
            {
                return HashPassword(rawPassword);
            }

            return GenerateHashedString(rawPassword, salt);
        }

        private static string GenerateHashedString(string rawPassword, string salt)
        {
            //get hashed value
            string hashedValue = getHashedValue(salt + rawPassword);

            //format and append string
            hashedValue = "$1$" + salt + "$" + hashedValue;

            return hashedValue;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static string GenerateSalt()
        {
            String candidateChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            string randomString = "";
            Random rng = new Random();
            for (int i = 0; i < 19; i++)
            {
                randomString += candidateChars[(rng.Next(61))];
            }

            return randomString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawData"></param>
        /// <returns></returns>
        private static string getHashedValue(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                //StringBuilder builder = new StringBuilder();
                //for (int i = 0; i < bytes.Length; i++)
                //{
                //    builder.Append(bytes[i].ToString());
                //}

                // return BASE64 converted string
                return System.Convert.ToBase64String(bytes);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GenerateRawPassword()
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

            //Cout each type
            for (int i = 0; i < password.Length; i++)
            {
                if (SMALL_LETTERS.Contains(password[i]))
                {
                    SMALL_LETTER_COUNT++;
                }
                else if (CAPTAL_LETTERS.Contains(password[i]))
                {
                    CAPITAL_LETTER_COUNT++;
                }
                else if (NUMBERS.Contains(password[i]))
                {
                    NUMBER_COUNT++;
                }
                else if (SPECIAL_LETTERS.Contains(password[i]))
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

            string str_password = new string(password);

            if (LEFT_RANDOM.Count > 1)
            {
                //get random Character set wheren count = 0
                string leftcharSet = LEFT_RANDOM[random.Next(LEFT_RANDOM.Count)];

                //replace last character with another random character 
                str_password = str_password.Remove(7, 1) + leftcharSet[random.Next(leftcharSet.Length - 1)].ToString();
            }

            return str_password;
        }

        public static Response GetGeneratePasswordResponse()
        {
            Response response = new Response();


            return response;
        }
    }
}