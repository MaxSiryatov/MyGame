using Microsoft.Xna.Framework;

namespace MyGame;

public class Pig
{
    public static int FrameWidth = 64;
    public static readonly int FrameHeight = 64;
    internal static Point CurrentFrame = new(0, 0);
    public static Point SpriteSize = new(4, 4);
    public static Vector2 Position = new (256, 256);
    public static Rectangle Rectangle = new Rectangle((int)Position.X, (int)Position.Y, FrameWidth, FrameHeight);

    public static void Update()
    {
        Rectangle.X = (int)Position.X;
        Rectangle.Y = (int)Position.Y;
    }
}