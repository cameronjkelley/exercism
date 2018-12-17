using System.Text;

namespace RotationalCipher
{
    public static class RotationalCipher
    {
        private const string _alphabet = "abcdefghijklmnopqrstuvwxyz";

        public static string Rotate(string text, int shiftKey)
        {
            string cipher = shiftKey > 0 && shiftKey < 26 ? _alphabet.Substring(shiftKey) + _alphabet.Substring(0, shiftKey) : _alphabet;

            StringBuilder sb = new StringBuilder();

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    if (char.IsLower(c))
                        sb.Append(cipher[_alphabet.IndexOf(c)]);
                    else
                        sb.Append(char.ToUpper(cipher[_alphabet.ToUpper().IndexOf(c)]));
                }
                else
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }
    }
}
