public class TileAdder
{
    protected int Width { get; private set; }
    protected int Height { get; private set; }
    protected Tile[,] tiles;

    public TileAdder(int width, int height)
    {
        Width = width;
        Height = height;
        tiles = new Tile[width, height];
    }

    public Tile[,] InitializeMap()
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

        return tiles;
    }

    public void AddTiles(int x, int y, int width, int height, TileType type, char symbol, ConsoleColor color, bool isPassable, char? specialSymbol = null)
    {
        Random rand = new Random();
        
        for (int dy = 0; dy < height; dy++)
        {
            for (int dx = 0; dx < width; dx++)
            {
                if (x + dx < Width && y + dy < Height)
                {
                    if (type == TileType.Tree && rand.Next(100) >= 70)
                    {
                        continue; // Skip tile if not within the 70% chance
                    }

                    tiles[x + dx, y + dy] = new Tile
                    {
                        Type = type,
                        Symbol = symbol,
                        Color = color,
                        IsPassable = isPassable
                    };
                }
            }
        }

        if (type == TileType.Building)
        {
            // Add a door in the center bottom of the building
            tiles[x + width / 2, y + height - 1] = new Tile
            {
                Type = TileType.Door,
                Symbol = '▼',
                Color = ConsoleColor.Yellow,
                IsPassable = true
            };

            // Add the special symbol in the center of the building
            tiles[x + width / 2, y + height / 2] = new Tile
            {
                Type = TileType.Building,
                Symbol = '■',
                Color = ConsoleColor.White,
                IsPassable = false,
                SpecialSymbol = specialSymbol
            };
        }
    }

    public void AddWaterArea(int x, int y, int width, int height)
    {
        AddTiles(x, y, width, height, TileType.Water, '~', ConsoleColor.Blue, false);
    }

    public void AddPath(int x1, int y1, int x2, int y2)
    {
        int dx = Math.Sign(x2 - x1);
        int dy = Math.Sign(y2 - y1);
        int x = x1;
        int y = y1;
        while (x != x2 || y != y2)
        {
            tiles[x, y] = new Tile
            {
                Type = TileType.Path,
                Symbol = '#',
                Color = ConsoleColor.Yellow,
                IsPassable = true
            };
            if (x != x2) x += dx;
            if (y != y2) y += dy;
        }
    }

    public void AddForestArea(int x, int y, int width, int height)
    {
        AddTiles(x, y, width, height, TileType.Tree, '♠', ConsoleColor.DarkGreen, false);
    }

    public void AddMountainArea(int x, int y, int width, int height)
    {
        AddTiles(x, y, width, height, TileType.Mountain, '▲', ConsoleColor.Gray, false);
    }

    public void AddBuilding(int x, int y, int width, int height, char specialSymbol)
    {
        AddTiles(x, y, width, height, TileType.Building, '■', ConsoleColor.White, false, specialSymbol);
    }

    public void AddLedge(int x, int y, int width, int height)
    {
        AddTiles(x, y, width, height, TileType.Ledge, '▼', ConsoleColor.DarkYellow, true);
    }

    public void AddRocksBorderingWater()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (tiles[x, y].Type == TileType.Water && HasAdjacentLand(x, y))
                {
                    tiles[x, y] = new Tile
                    {
                        Type = TileType.Rock,
                        Symbol = '◘',
                        Color = ConsoleColor.DarkGray,
                        IsPassable = false
                    };
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
}
