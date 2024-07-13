class Program
{
    static void Main(string[] args)
    {
        Map map = new Map(300, 200);
        Player player = new Player(150, 100);

        while (true)
        {
            Console.Clear();
            map.Display(player.X, player.Y, 50, 25);
            DisplayPlayerInfo(player);

            ConsoleKeyInfo key = Console.ReadKey(true);
            HandleInput(key, player, map);

            if (key.Key == ConsoleKey.Q)
                break;
        }
    }

    static void HandleInput(ConsoleKeyInfo key, Player player, Map map)
    {
        int newX = player.X;
        int newY = player.Y;

        switch (key.Key)
        {
            case ConsoleKey.UpArrow: newY--; break;
            case ConsoleKey.DownArrow: newY++; break;
            case ConsoleKey.LeftArrow: newX--; break;
            case ConsoleKey.RightArrow: newX++; break;
            case ConsoleKey.I: player.OpenInventory(); return;
            case ConsoleKey.M: DisplaySimplifiedMap(map); return;
        }

        if (map.CanMoveTo(newX, newY))
        {
            player.MoveTo(newX, newY);
            map.CheckForEncounter(player);
        }
    }

    static void DisplayPlayerInfo(Player player)
    {
        Console.SetCursorPosition(0, 26);
        Console.WriteLine($"Player Position: ({player.X}, {player.Y})");
        Console.WriteLine("Press 'I' to open your Bag, 'M' for the Town Map, 'Q' to Quit");
    }

    static void DisplaySimplifiedMap(Map map)
    {
        Console.Clear();
        map.DisplaySimplifiedMap();
        Console.WriteLine("Press any key to return to game...");
        Console.ReadKey(true);
    }
}