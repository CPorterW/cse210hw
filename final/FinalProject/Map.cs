using System.Threading.Tasks;
using System.Diagnostics;
using System.Text;
public class Map
{
    private Tile[,] tiles;
    public int Width { get; }
    public int Height { get; }
    private Encounter encounter;
    private TileAdder adder;

    public Map(int width, int height)
    {
        Width = width;
        Height = height;
        encounter = new Encounter();
        adder = new TileAdder(Width, Height);
        tiles = adder.InitializeMap();
    }

    public void Display(int playerX, int playerY, int viewportWidth, int viewportHeight)
    {
        int startX = Math.Max(0, playerX - viewportWidth / 2);
        int startY = Math.Max(0, playerY - viewportHeight / 2);
        int endX = Math.Min(Width, startX + viewportWidth);
        int endY = Math.Min(Height, startY + viewportHeight);

        for (int y = startY; y < endY; y++)
        {
            for (int x = startX; x < endX; x++)
            {
                if (x == playerX && y == playerY)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('@');
                }
                else
                {
                    Tile tile = tiles[x, y];
                    Console.ForegroundColor = tile.Color;
                    char displayChar = tile.SpecialSymbol ?? tile.Symbol;
                    Console.Write(displayChar);
                }
            }
            Console.WriteLine();
        }
        Console.ResetColor();
    }

    public void DisplaySimplifiedMap()
    {
        for (int y = 0; y < Height; y += 2)
        {
            for (int x = 0; x < Width; x += 2)
            {
                Console.ForegroundColor = tiles[x, y].Color;
                Console.Write(GetSimplifiedSymbol(tiles[x, y].Type));
            }
            Console.WriteLine();
        }
        Console.ResetColor();
    }

    public async Task CheckForEncounter(Player player)
    {
        if (tiles[player.X, player.Y].Type == TileType.Grass)
        {
            Random rand = new Random();
            if (rand.Next(100) < 10) // 10% chance for encounter
            {
                Console.Clear();
                Console.WriteLine("\nA wild Pokemon appeared!");
                await encounter.RunPythonBattle();
                Console.WriteLine("Press enter to continue.");
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) {}
            }
        }
    }
    private char GetSimplifiedSymbol(TileType type)
    {
        switch (type)
        {
            case TileType.Grass: return '·';
            case TileType.Water: return '~';
            case TileType.Path: return '=';
            case TileType.Tree: return '♣';
            case TileType.Mountain: return '▲';
            case TileType.Building: return '□';
            case TileType.Ledge: return '_';
            case TileType.Rock: return '○';
            default: return '?';
        }
    }

    public bool CanMoveTo(int x, int y)
    {
        if (x < 0 || x >= Width || y < 0 || y >= Height)
            return false;

        return tiles[x, y].IsPassable;
    }
}