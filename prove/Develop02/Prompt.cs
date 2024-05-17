public class Prompt {
    public static string GeneratePrompt(){
        List<string> prompts = new List<string> {"How did I see the hand of the Lord in my life today?", "What's the funniest thing you heard someone say today? (If you're a couch potato, feel free to use a quote from whatever media you watched)", "What is the tastiest thing you ate today?", "What is the most interesting thing that has happened to you in the past week?", "What's your favorite song this month?", "What did you spend today's free time doing?"};

        Random rand = new Random();
        int randomIndex = rand.Next(0, prompts.Count);
        string randomPrompt = prompts[randomIndex];
        return randomPrompt;
    }
}    
