using System;


namespace Pig_Latin_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = "";

            Console.WriteLine("Ellohay!  Elcomeway otay hetay Igpay Atinlay Anslatortray.");
            Console.WriteLine();
            Console.WriteLine("Oops, sorry.  I meant:  Hello!  Welcome to the Pig Latin Translator.");
            Console.WriteLine();

            bool again = true;
            while (again == true)
            {
                Console.WriteLine("Enter what you'd like to be translated:");
                string userInput = Console.ReadLine().ToLower();

                string pigLatin = GetPigLatin(userInput);
                Console.WriteLine(pigLatin);

                again = GetContinue();

            }
        }
        public static string GetPigLatin(string sentence)
        {
            string returnWord = "";
            string returnSentence = "";
            string spCh = "0123456789@#$%&*";
            int wordLength = 0;
            char[] charArr = spCh.ToCharArray();
            string beforeLetters = "";
            string afterLetters = "";

            if (sentence == " ")
            {
                returnSentence = "You have not entered a word.";
                return returnSentence;
            }
            foreach (char ch in charArr)
            {
                if (sentence.Contains(ch))
                {
                    returnSentence = "This cannot be translated.";
                    return returnSentence;
                }
            }
            foreach (string word in sentence.Split())
            {
                int VowelPosition = -1;

                foreach (char letter in word)
                {
                    VowelPosition = VowelPosition + 1;

                    if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u')
                    {
                        break;
                    }
                }

                if (VowelPosition == 0)
                {
                    returnWord = word + "way";
                }

                else
                {
                    wordLength = word.Length;
                    beforeLetters = word.Substring(0, VowelPosition);
                    afterLetters = word.Substring(VowelPosition, wordLength - VowelPosition);

                    returnWord = afterLetters + beforeLetters + "ay";
                }
                returnSentence += returnWord + " ";
            }
            return returnSentence + " ";
        }
        public static bool GetContinue()
        {
            Console.WriteLine();
            Console.WriteLine("Is there anything else you'd like to translate? y/n");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "y")
            {
                return true;
            }
            else if (answer.ToLower() == "n")
            {
                Console.Write("Eesay Ouyay Aterlay!");
                return false;
            }
            else
            {
                Console.WriteLine("I didn't understand your response, please try again...");
                return GetContinue();
            }
        }
    }
}
