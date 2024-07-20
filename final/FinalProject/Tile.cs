using System;

public abstract class Tile
{
    public abstract TileType Type { get; }
    public abstract char Symbol { get; }
    public abstract ConsoleColor Color { get; }
    public abstract bool IsPassable { get; }
    public char? SpecialSymbol { get; set; }

    public abstract void AddArea(TileAdder tileAdder, int x, int y, int width, int height);
}

public class GrassTile : Tile
{
    public override TileType Type => TileType.Grass;
    public override char Symbol => '.';
    public override ConsoleColor Color => ConsoleColor.Green;
    public override bool IsPassable => true;

    public override void AddArea(TileAdder tileAdder, int x, int y, int width, int height)
    {
        tileAdder.AddTiles(x, y, width, height, this);
    }
}

public class WaterTile : Tile
{
    public override TileType Type => TileType.Water;
    public override char Symbol => '~';
    public override ConsoleColor Color => ConsoleColor.Blue;
    public override bool IsPassable => false;

    public override void AddArea(TileAdder tileAdder, int x, int y, int width, int height)
    {
        tileAdder.AddTiles(x, y, width, height, this);
    }
}

public class PathTile : Tile
{
    public override TileType Type => TileType.Path;
    public override char Symbol => '#';
    public override ConsoleColor Color => ConsoleColor.Yellow;
    public override bool IsPassable => true;

    public override void AddArea(TileAdder tileAdder, int x, int y, int width, int height)
    {
        tileAdder.AddPath(x, y, width, height);
    }
}

public class TreeTile : Tile
{
    public override TileType Type => TileType.Tree;
    public override char Symbol => '♠';
    public override ConsoleColor Color => ConsoleColor.DarkGreen;
    public override bool IsPassable => false;

    public override void AddArea(TileAdder tileAdder, int x, int y, int width, int height)
    {
        tileAdder.AddTiles(x, y, width, height, this);
    }
}

public class MountainTile : Tile
{
    public override TileType Type => TileType.Mountain;
    public override char Symbol => '▲';
    public override ConsoleColor Color => ConsoleColor.Gray;
    public override bool IsPassable => false;

    public override void AddArea(TileAdder tileAdder, int x, int y, int width, int height)
    {
        tileAdder.AddTiles(x, y, width, height, this);
    }
}

public class LedgeTile : Tile
{
    public override TileType Type => TileType.Ledge;
    public override char Symbol => '▼';
    public override ConsoleColor Color => ConsoleColor.DarkYellow;
    public override bool IsPassable => true;

    public override void AddArea(TileAdder tileAdder, int x, int y, int width, int height)
    {
        tileAdder.AddTiles(x, y, width, height, this);
    }
}

public class BuildingTile : Tile
{
    public override TileType Type => TileType.Building;
    public override char Symbol => '■';
    public override ConsoleColor Color => ConsoleColor.White;
    public override bool IsPassable => false;

    public override void AddArea(TileAdder tileAdder, int x, int y, int width, int height)
    {
        tileAdder.AddTiles(x, y, width, height, this);
    }
}

public class DoorTile : Tile
{
    public override TileType Type => TileType.Door;
    public override char Symbol => '▼';
    public override ConsoleColor Color => ConsoleColor.Yellow;
    public override bool IsPassable => true;

    public override void AddArea(TileAdder tileAdder, int x, int y, int width, int height)
    {
        tileAdder.AddTiles(x, y, width, height, this);
    }
}

public class RockTile : Tile
{
    public override TileType Type => TileType.Rock;
    public override char Symbol => '◘';
    public override ConsoleColor Color => ConsoleColor.DarkGray;
    public override bool IsPassable => false;

    public override void AddArea(TileAdder tileAdder, int x, int y, int width, int height)
    {
        tileAdder.AddTiles(x, y, width, height, this);
    }
}
