using System;

class Program
{
    static void Main(string[] args){
        DisplayWelcome();
        string userName = PromptUserName();
        int favNum = PromptUserNumber();
        int squaredNum = SquareNumber(favNum);
        DisplayResult(userName, squaredNum);
    }

    static void DisplayWelcome(){
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName(){
        Console.Write("Please enter your name: ");
        string userName = Console.ReadLine();
        return userName;
    }
    static int PromptUserNumber(){
        Console.Write("Please enter your favorite number: ");
        int favNum = int.Parse(Console.ReadLine());
        return favNum;
    }
    static int SquareNumber(int favNum){
        int squaredNum = (int)(Math.Pow(favNum, 2));
        return squaredNum;
    }
    static void DisplayResult(string userName, int squaredNum){
        Console.WriteLine($"{userName}, your fav number squared is {squaredNum}!");
    }

}