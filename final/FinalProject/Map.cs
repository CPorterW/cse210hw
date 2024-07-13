public class Map
{
    private Tile[,] tiles;
    public int Width { get; }
    public int Height { get; }

    public Map(int width, int height)
    {
        Width = width;
        Height = height;
        tiles = new Tile[width, height];
        InitializeMap();
    }

    private void InitializeMap()
    {
        // Set everything to grass by default
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                tiles[x, y] = new Tile { Type = TileType.Grass, Symbol = '.', Color = ConsoleColor.Green, IsPassable = true };
            }
        }

        // Add water areas
        AddWaterArea(0, 0, Width, Height / 4);
        AddWaterArea(0, 3 * Height / 4, Width, Height / 4);
        AddWaterArea(0, Height / 4, Width / 4, Height / 2);
        AddWaterArea(3 * Width / 4, Height / 4, Width / 4, Height / 2);

        // Add paths
        AddPath(Width / 4, Height / 2, 3 * Width / 4, Height / 2);
        AddPath(Width / 2, Height / 4, Width / 2, 3 * Height / 4);

        // Add trees and mountains
        AddForestArea(Width / 4, Height / 4, Width / 4, Height / 4);
        AddMountainArea(2 * Width / 3, Height / 4, Width / 6, Height / 4);

        // Add buildings
        AddBuilding(3 * Width / 8, 5 * Height / 8, Width / 16, Height / 16, 'P'); // Pokemon Center
        AddBuilding(5 * Width / 8, 5 * Height / 8, Width / 16, Height / 16, 'M'); // Mart

        // Add ledges
        AddLedge(3 * Width / 8, 7 * Height / 16, Width / 4, 1);

        // Add rocks bordering waterways
        AddRocksBorderingWater();
    }

    private void AddWaterArea(int x, int y, int width, int height)
    {
        for (int dy = 0; dy < height; dy++)
        {
            for (int dx = 0; dx < width; dx++)
            {
                if (x + dx < Width && y + dy < Height)
                {
                    tiles[x + dx, y + dy] = new Tile { Type = TileType.Water, Symbol = '~', Color = ConsoleColor.Blue, IsPassable = false };
                }
            }
        }
    }

    private void AddPath(int x1, int y1, int x2, int y2)
    {
        int dx = Math.Sign(x2 - x1);
        int dy = Math.Sign(y2 - y1);
        int x = x1;
        int y = y1;
        while (x != x2 || y != y2)
        {
            tiles[x, y] = new Tile { Type = TileType.Path, Symbol = '#', Color = ConsoleColor.Yellow, IsPassable = true };
            if (x != x2) x += dx;
            if (y != y2) y += dy;
        }
    }

    private void AddForestArea(int x, int y, int width, int height)
    {
        Random rand = new Random();
        for (int dy = 0; dy < height; dy++)
        {
            for (int dx = 0; dx < width; dx++)
            {
                if (x + dx < Width && y + dy < Height && rand.Next(100) < 70)
                {
                    tiles[x + dx, y + dy] = new Tile { Type = TileType.Tree, Symbol = '♠', Color = ConsoleColor.DarkGreen, IsPassable = false };
                }
            }
        }
    }

    private void AddMountainArea(int x, int y, int width, int height)
    {
        for (int dy = 0; dy < height; dy++)
        {
            for (int dx = 0; dx < width; dx++)
            {
                if (x + dx < Width && y + dy < Height)
                {
                    tiles[x + dx, y + dy] = new Tile { Type = TileType.Mountain, Symbol = '▲', Color = ConsoleColor.Gray, IsPassable = false };
                }
            }
        }
    }

    private void AddBuilding(int x, int y, int width, int height, char specialSymbol)
    {
        for (int dy = 0; dy < height; dy++)
        {
            for (int dx = 0; dx < width; dx++)
            {
                if (x + dx < Width && y + dy < Height)
                {
                    tiles[x + dx, y + dy] = new Tile { Type = TileType.Building, Symbol = '■', Color = ConsoleColor.White, IsPassable = false };
                }
            }
        }
        tiles[x + width / 2, y + height - 1] = new Tile { Type = TileType.Door, Symbol = '▼', Color = ConsoleColor.Yellow, IsPassable = true };
        tiles[x + width / 2, y + height / 2] = new Tile { Type = TileType.Building, Symbol = '■', Color = ConsoleColor.White, IsPassable = false, SpecialSymbol = specialSymbol };
    }

    private void AddLedge(int x, int y, int width, int height)
    {
        for (int dy = 0; dy < height; dy++)
        {
            for (int dx = 0; dx < width; dx++)
            {
                if (x + dx < Width && y + dy < Height)
                {
                    tiles[x + dx, y + dy] = new Tile { Type = TileType.Ledge, Symbol = '▼', Color = ConsoleColor.DarkYellow, IsPassable = true };
                }
            }
        }
    }

    private void AddRocksBorderingWater()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (tiles[x, y].Type == TileType.Water && HasAdjacentLand(x, y))
                {
                    tiles[x, y] = new Tile { Type = TileType.Rock, Symbol = '◘', Color = ConsoleColor.DarkGray, IsPassable = false };
                }
            }
        }
    }

    private bool HasAdjacentLand(int x, int y)
    {
        for (int dy = -1; dy <= 1; dy++)
        {
            for (int dx = -1; dx <= 1; dx++)
            {
                if (dx == 0 && dy == 0) continue;
                int nx = x + dx, ny = y + dy;
                if (nx >= 0 && nx < Width && ny >= 0 && ny < Height && tiles[nx, ny].Type != TileType.Water)
                {
                    return true;
                }
            }
        }
        return false;
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
    public void CheckForEncounter(Player player)
    {
        if (tiles[player.X, player.Y].Type == TileType.Grass)
        {
            Random rand = new Random();
            if (rand.Next(100) < 10) // 10% chance for encounter
            {
                Console.WriteLine("\nA wild Pokemon appeared!");
                Console.ReadKey(true);
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