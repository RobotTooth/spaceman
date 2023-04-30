using System;


namespace Spaceman
{
    class Game
    {
        private readonly string[] words = { "deliverance", "fullfilment", "existential", "subsistance", "paranoia", "vertigenous", "sacrosanct" };
        private string letters = "";
        readonly Ufo attackers = new Ufo();

        public string Codeword { get; set; }
        public string CurrentWord { get; set; }
        public int MaxGuesses { get; set; }
        public int WrongGuesses { get; set; }
        public int Guesses { get; set; }

        public Game()
        {

            Random rand = new Random();
            int index = rand.Next(0, words.Length);
            Codeword = words[index];
            MaxGuesses = 5;
            WrongGuesses = 0;
            Guesses = 0;
            for (int i = 0; i < Codeword.Length; i++)
            {
                CurrentWord += "_";
            }

        }

        public bool DidWin()
        {
            if (Codeword.Equals(CurrentWord)) { return true; } else { return false; }

        }

        public void DisplayWin()
        {
            attackers.Win();
            Console.WriteLine($"You guessed: {CurrentWord} in {Guesses} guesses, with {WrongGuesses} incorrect guesses.");
        }

        public bool DidLoose()
        {
            if (WrongGuesses >= MaxGuesses) { return true; } else { return false; }
        }

        public void Display()
        {
            Console.WriteLine($"Current Word = {CurrentWord}");
            Console.WriteLine($"Number of incorrect guesses = {WrongGuesses}");
            Console.WriteLine(attackers.Stringify());
            Console.WriteLine($"Letters guessed already: {letters}");
        }

        public void Ask()
        {
            Console.WriteLine("Please guess a letter: ");
            string guess = Convert.ToString(Console.ReadLine().ToLower());
            if (letters.Contains(guess)) { Console.WriteLine("\nYou have guessed this letter already, please guess another letter:\n"); Guesses--; if (!Codeword.Contains(guess)) { WrongGuesses--; attackers.RemovePart(); } }
            if (!letters.Contains(guess)) { letters += guess + " "; }
            Guesses++;
            if (guess.Length > 1) { Console.WriteLine("Please pick only a single letter at a time"); return; }
            else
            {
                char letter = Convert.ToChar(guess);
                if (Codeword.Contains(guess))
                {
                    for (int i = 0; i < Codeword.Length; i++)
                    {
                        if (Codeword[i] == letter)
                        {
                            CurrentWord = CurrentWord.Remove(i, 1).Insert(i, guess);
                        }

                    }
                }
                else { WrongGuesses++; attackers.AddPart(); }
            }
        }

        public void Greet()
        {
            Console.WriteLine("==============================\nWelcome to Space Word Invaders\n==============================\nGuess the word, to avoid body snatching!");
        }
    }
}