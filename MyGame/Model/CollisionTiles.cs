using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace MyGame;

public class CollisionTiles : Tiles
{
    public Rectangle CollisionRectangle;
    public int TileNumber;
    public CollisionTiles(int tileNumber, Rectangle newRectangle)
    {
        TileNumber = tileNumber;
        CollisionRectangle = newRectangle;
    }
}