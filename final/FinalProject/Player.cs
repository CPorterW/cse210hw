public class Player
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public List<string> Bag { get; } = new List<string>{"Pokémon", "Pokédex", "Bag", "License", "<--", "Quit"};

    public Player(int startX, int startY)
    {
        X = startX;
        Y = startY;
    }

    public void MoveTo(int newX, int newY)
    {
        X = newX;
        Y = newY;
    }

    public void OpenInventory()
    {
        Console.Clear();
        Console.WriteLine("Bag:");
        int i = 0;
        Dictionary<int, string> bagDict = new Dictionary<int, string>();
        foreach (var item in Bag)
        {
            i++;
            Console.WriteLine($"{i} - {item}");
            bagDict.Add(i,item);
        }
        switch(Console.ReadKey(true).KeyChar){
            case '1':
                break;
            case '2':
                break;
        }
    }
}