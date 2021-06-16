using System;

namespace OTP_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao OTP Decryptor!");
            Console.WriteLine();
            Console.WriteLine("Digite a chave:");
            string key = Console.ReadLine().ToUpper();

            Console.WriteLine("Digite a mensagem encriptada:");
            string rawMessage = Console.ReadLine();

            string filteredText = FilterText(rawMessage.ToUpper());
            string finalMessage = Decode(key, filteredText);

            finalMessage = BuildMessage(finalMessage, rawMessage);

            Console.WriteLine("Mensagem decriptada:");
            Console.WriteLine(finalMessage);
        }

        private static string BuildMessage(string finalMessage, string rawMessage)
        {
            for (int i = 0; i < rawMessage.Length; i++)
            {
                if (IsNotInAlphabet(rawMessage[i]))
                    finalMessage = finalMessage.Insert(i, rawMessage[i].ToString());
            }

            return finalMessage;
        }

        public static string Decode(string keyInput, string textInput)
        {
            string text = textInput.ToUpper();
            string key = keyInput.ToUpper();
            char[] charKey = key.ToCharArray();
            char[] charText = text.ToCharArray();

            for (int i = 0; i < key.Length; i++)
            {
                int temp = charKey[i] - 65;
                char temporary;

                if ((charText[i] - temp) < 65)
                    temporary = Convert.ToChar((charText[i] + 26) - temp);
                else
                    temporary = Convert.ToChar(charText[i] - temp);

                charText[i] = temporary;
            }

            string output = new string(charText);
            return output;
        }

        private static string FilterText(string text)
        {
            foreach (var c in text)
                if (IsNotInAlphabet(c))
                    text = text.Replace(c.ToString(), string.Empty);

            return text;
        }

        public static bool IsNotInAlphabet(char c) => (c < 65 || c > 90);
    }
}
