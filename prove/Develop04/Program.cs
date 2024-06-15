/*
The list activity counts entries, the console is kept clean, 
no duplicate questions are used in the reflection activity, 
I error-proofed type conversions, and the timer doesn't 
interrupt the user mid-iteration. I spent 10+ hours on this.
*/
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            int choice = 0;
            try{
                choice = int.Parse(Console.ReadLine());
            }
            catch(System.FormatException){
                Console.Write("Please enter an integer.");
                Thread.Sleep(1000);
                continue;
            }

            Activity activity;
            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(1000);
                    continue;
            }
            bool completed;
            completed = activity.Start();
            if (completed) {
                activity.RunActivity();
                activity.End();
            }
        }
    }
}