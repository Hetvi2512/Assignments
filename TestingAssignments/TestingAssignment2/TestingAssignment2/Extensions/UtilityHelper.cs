using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TestingAssignment2
{
    public static class UtilityHelper
    {
        public static string CreateUpperCase(this string inputstring)
        {
            if(inputstring.Length > 0)
            {
                char[] charArray = inputstring.ToCharArray();
                charArray[0] = char.IsUpper(charArray[0]) ? char.ToLower(charArray[0]) : char.ToUpper(charArray[0]);
                return new string(charArray);
            }
            return inputstring;
        }
        public static string TitleCase(this string inputString)
        {
            StringBuilder updatedString = new StringBuilder();
            string[] inputStringArray = inputString.Split(' ');
            foreach (var item in inputStringArray)
            {
                bool isAcronyms = true;

                for (int index = 0; index < item.Length; index++)
                {
                    if (Char.IsLower(item[index]))
                    {
                        isAcronyms = false;
                        break;
                    }

                }
                if (!isAcronyms)
                    updatedString.Append(CultureInfo.InvariantCulture.TextInfo.ToTitleCase(item) + " ");
                else
                    updatedString.Append(item + " ");
            }
            return updatedString.ToString().Remove(updatedString.Length - 1);
        }

        public static bool LowerCase(this string inputString)
        {
            bool isLower = true;
            for (int index = 0; index < inputString.Length; index++)
            {
                if (Char.IsUpper(inputString[index]))
                {
                    isLower = false;
                    break;
                }
            }
            return isLower ? true : false;
        }
            public static string Capitalize(this string inputString)
            {
                return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(inputString);
            }
            public static bool IsUpperCaseString(this string inputString)
            {
                bool isUpper = true;
                for (int index = 0; index < inputString.Length; index++)
                {
                    if (Char.IsLower(inputString[index]))
                    {
                        isUpper = false;
                        break;
                    }
                }
                return isUpper ? true : false;
            }
            public static bool IsValidNumericValue(this string inputString)
            {
                return int.TryParse(inputString, out int n);
            }
            public static string RemoveLastCharacter(this string inputString)
            {
                return inputString.Remove(inputString.Length - 1);
            }
            public static int WordCount(this string inputString)
            {
                return inputString.Split(' ').Length;
            }
            public static int StringToInteger(this string inputString)
            {
                int.TryParse(inputString, out int n);
                return n;
            }
    }
}

