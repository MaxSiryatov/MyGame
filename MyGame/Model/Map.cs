using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame;

public class Map
{
    public static List<CollisionTiles> CollisionTiles { get; } = new();

    private int width, height;
    public int Width => width;
    public int Height => height;

    public static int[,] MapGrid = {
        { 1, 1, 2, 1, 1, 1, 1, 1, 1, 3, 8, 8, 8, 8, 8, 8, 8, 7, 1, 1, 1, 1, 1, 2, 2, 2, 1 },
        { 1, 1, 1, 2, 2, 1, 1, 1, 2, 9, 6, 6, 6, 6, 6, 6, 6, 9, 1, 1, 1, 1, 2, 1, 1, 2, 1 },
        { 2, 1, 1, 1, 1, 1, 1, 1, 1, 11, 6, 6, 6, 6, 6, 6, 6, 11, 1, 1, 1, 1, 1, 1, 1, 2, 2 },
        { 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 10, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1 },
        { 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1 },
        { 1, 1, 1, 2, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 10, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 1, 1, 1, 1, 2, 2 }
    };
    public Map()
    {
    }

    public void Generate(int[,] map, int size)
    {
        for (var x = 0; x < map.GetLength(1); x++)
        {
            for (var y = 0; y < map.GetLength(0); y++)
            {
                var number = map[y, x];
                
                if (number > 0)
                    CollisionTiles.Add(new CollisionTiles(number, new Rectangle(x * size, y * size, size, size)));

                width = (x + 1) * size;
                height = (y + 1) * size;
            }
        }
    }
}