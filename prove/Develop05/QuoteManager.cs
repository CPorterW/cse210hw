public class QuoteManager
{
    private List<string> quotes = new List<string>
    {
        "The future is as bright as your faith. - Thomas S. Monson",
        "We can't direct the wind, but we can adjust the sails. - Thomas S. Monson",
        "Try a little harder to be a little better. - Gordon B. Hinckley",
        "Be believing, be happy, don’t get discouraged. Things will work out. - Gordon B. Hinckley",
        "The joy we feel has little to do with the circumstances of our lives and everything to do with the focus of our lives. - Russell M. Nelson",
        "Doubt your doubts before you doubt your faith. - Dieter F. Uchtdorf",
        "It is your reaction to adversity, not the adversity itself, that determines how your life’s story will develop. - Dieter F. Uchtdorf",
        "Don’t you quit. You keep walking. You keep trying. There is help and happiness ahead. - Jeffrey R. Holland",
        "If you are on the right path, it will always be uphill. The Lord is anxious to lead us to the safety of higher ground. - Henry B. Eyring"
    };


    public string GetRandomQuote()
    {
        Random rand = new Random();
        return quotes[rand.Next(quotes.Count)];
    }
}