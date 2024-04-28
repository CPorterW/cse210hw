using System;
using System.Globalization;


class Program
{
    static void Main(string[] args)
    {
        TextInfo ti = new CultureInfo("en-US", false).TextInfo;
        Console.Write("What is your first name? ");
        string fname = ti.ToTitleCase(ti.ToLower(Console.ReadLine()));
        Console.Write("What is your last name? ");
        string lname = ti.ToTitleCase(ti.ToLower(Console.ReadLine()));
        string intro = $"\nMy name is {lname}, {fname} {lname}.";
        Console.WriteLine(intro);
    }
}