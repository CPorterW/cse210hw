using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction yourFraction = new Fraction();
        Console.Write("Give me the top number for your fraction. ");
        double topNum = double.Parse(Console.ReadLine());
        yourFraction.SetTopNum(topNum);
        Console.Write("Give me the bottom number for your fraction. ");
        double bottomNum = double.Parse(Console.ReadLine());
        yourFraction.SetBottomNum(bottomNum);
        Console.WriteLine(yourFraction.GetFractionString());
        Console.WriteLine(yourFraction.GetDecimalValue());
        Fraction myFraction = new Fraction(3,9);
        Console.WriteLine("\n\nYour fraction is nice, but look at mine! :)");
        Console.WriteLine(myFraction.GetTopNum());
        Console.WriteLine(myFraction.GetBottomNum());
        Console.WriteLine(myFraction.GetFractionString());
        Console.WriteLine(myFraction.GetDecimalValue());
    }
}
