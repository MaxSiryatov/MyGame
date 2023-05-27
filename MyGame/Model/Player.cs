using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame;

public class Player
{
    public static int FrameWidth = 77;
    public static int FrameHeight = 77;
    internal static Point CurrentFrame = new(0, 0);
    public static Point SpriteSize = new(8, 4);
    public static Vector2 Position = Vector2.Zero;
    public static Rectangle Rectangle = new Rectangle((int)Position.X, (int)Position.Y, FrameWidth, FrameHeight);
    
    public static void Update()
    {
        Rectangle.X = (int)Position.X;
        Rectangle.Y = (int)Position.Y;
    }
}