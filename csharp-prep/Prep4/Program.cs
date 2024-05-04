using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Give me a few numbers, type 0 to finish.");
        List<string> words = new List<string>();
        List<int> numList = new List<int>();
        int num = 1;
        while (true){
            try{
                Console.Write("Enter a number: ");
                num = int.Parse(Console.ReadLine());

                // The condition has to be here to prevent 0 from being added to the list.
                // I could've figured out how to .remove() as in Python, but this works fine.
                if (num == 0){
                    break;
                }
                numList.Add(num);
            }
            catch(FormatException){
                Console.WriteLine("Only give negative or positive integers.");
            }
        }
        int sum = 0;
        float biggestNum = Single.MaxValue;
        float smallestNum = Single.MinValue;
        float smallestPosNum = biggestNum;
        float biggestActualNum = smallestNum;
        foreach (int n in numList){
            sum += n;
            if (n<smallestPosNum && n>0 ){
                smallestPosNum = n;
            }
            if (n>biggestActualNum){
                biggestActualNum = n;
            }

        }
        Console.WriteLine($"The sum is {sum}");

        /*
        I'm proud that I figured this line out before looking at the solution.
        I'm also proud to have reduced some of the solution's redundancies.
        (Although I know the redundancies were only present so the code
        could be broken up into chunks that are easier for students to 
        understand, so thank you for that!)
        */
        float avg = (float)sum / numList.Count();

        Console.WriteLine($"The average is {avg}");
        Console.WriteLine($"The biggest number is {biggestActualNum}");
        Console.WriteLine($"The smallest positive number is {smallestPosNum}");

    }
}