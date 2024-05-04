using System;
class Program
{
    static void Main(string[] args)
    {
        while (true){
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1,11);
            int guessCount = 1;
            int guessedNum = -1;
            while (true){
                Console.Write("Guess a number between one and ten. ");
                guessedNum = int.Parse(Console.ReadLine());
                if (guessedNum == number){
                    Console.WriteLine("You got it!");
                    Console.WriteLine($"You guessed {guessCount} times!");
                    break;
                }
                else if (guessedNum > number){
                    Console.WriteLine("You're a little too high. Try again.");
                }
                else if (guessedNum < number){
                    Console.WriteLine("You're a little low. Try again.");
                }
;
                guessCount++;
                }
   

            Console.Write("Would you like to play again? ");
            string yOrN = Console.ReadLine().ToLower();
            if (yOrN == "yes"){
                continue;
            }
            else{
                break;
            };
            }
    }
} 