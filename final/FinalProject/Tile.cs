public class Tile
{
    public TileType Type { get; set; }
    public char Symbol { get; set; }
    public ConsoleColor Color { get; set; }
    public bool IsPassable { get; set; }
    public char? SpecialSymbol { get; set; }
}