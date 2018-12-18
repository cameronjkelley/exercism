using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace IsbnVerifier
{
    public static class IsbnVerifier
    {
        public static bool IsValid(string number)
        {
            Regex regex = new Regex(@"[\dxX]");
            List<int> numbers = new List<int>();

            foreach (Match match in regex.Matches(number))
            {
                if ((match.Value == "X" || match.Value == "x") && 
                    match.Index == number.Length - 1)
                {
                    numbers.Add(10);
                }
                else
                {
                    if (int.TryParse(match.Value, out int tryInt))
                    {
                        numbers.Add(tryInt);
                    }
                }
            }

            return numbers.Count == 10 && numbers.Select((x, i) => x * (10 - i)).Sum() % 11 == 0;
        }
    }
}
