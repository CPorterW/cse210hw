public class Region
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public TileType Type { get; set; }
    public char Symbol { get; set; }
    public ConsoleColor Color { get; set; }

    public Region(int x, int y, int width, int height, TileType type, char symbol, ConsoleColor color)
    {
        X = x; Y = y; Width = width; Height = height;
        Type = type; Symbol = symbol; Color = color;
    }
}