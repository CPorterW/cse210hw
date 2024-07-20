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
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                tiles[x, y] = new GrassTile();
            }
        }

        new WaterTile().AddArea(this, 0, 0, Width, Height / 4);
        new WaterTile().AddArea(this, 0, 3 * Height / 4, Width, Height / 4);
        new WaterTile().AddArea(this, 0, Height / 4, Width / 4, Height / 2);
        new WaterTile().AddArea(this, 3 * Width / 4, Height / 4, Width / 4, Height / 2);

        new PathTile().AddArea(this, Width / 4, Height / 2, 3 * Width / 4, Height / 2);
        new PathTile().AddArea(this, Width / 2, Height / 4, Width / 2, 3 * Height / 4);

        new TreeTile().AddArea(this, Width / 4, Height / 4, Width / 4, Height / 4);
        new MountainTile().AddArea(this, 2 * Width / 3, Height / 4, Width / 6, Height / 4);

        new BuildingTile().AddArea(this, 3 * Width / 8, 5 * Height / 8, Width / 16, Height / 16);
        new BuildingTile().AddArea(this, 5 * Width / 8, 5 * Height / 8, Width / 16, Height / 16);

        new LedgeTile().AddArea(this, 3 * Width / 8, 7 * Height / 16, Width / 4, 1);

        AddRocksBorderingWater();

        return tiles;
    }

    public void AddTiles(int x, int y, int width, int height, Tile tilePrototype)
    {
        Random rand = new Random();

        for (int dy = 0; dy < height; dy++)
        {
            for (int dx = 0; dx < width; dx++)
            {
                if (x + dx < Width && y + dy < Height)
                {
                    if (tilePrototype.Type == TileType.Tree && rand.Next(100) >= 70)
                    {
                        continue; // Skip tile if not within the 70% chance
                    }

                    tiles[x + dx, y + dy] = (Tile)Activator.CreateInstance(tilePrototype.GetType());
                    tiles[x + dx, y + dy].SpecialSymbol = tilePrototype.SpecialSymbol;
                }
            }
        }

        if (tilePrototype.Type == TileType.Building)
        {
            tiles[x + width / 2, y + height - 1] = new DoorTile();
            tiles[x + width / 2, y + height / 2] = new BuildingTile { SpecialSymbol = tilePrototype.SpecialSymbol };
        }
    }

    public void AddPath(int x1, int y1, int x2, int y2)
    {
        int dx = Math.Sign(x2 - x1);
        int dy = Math.Sign(y2 - y1);
        int x = x1;
        int y = y1;
        while (x != x2 || y != y2)
        {
            tiles[x, y] = new PathTile();
            if (x != x2) x += dx;
            if (y != y2) y += dy;
        }
    }

    public void AddRocksBorderingWater()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                if (tiles[x, y] is WaterTile && HasAdjacentLand(x, y))
                {
                    tiles[x, y] = new RockTile();
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
                if (nx >= 0 && nx < Width && ny >= 0 && ny < Height && !(tiles[nx, ny] is WaterTile))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
