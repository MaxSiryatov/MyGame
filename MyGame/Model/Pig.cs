using Microsoft.Xna.Framework;

namespace MyGame;

public class Pig
{
    public static int FrameWidth = 64;
    public static int FrameHeight = 64;
    internal static Point CurrentFrame = new(0, 0);
    public static Point SpriteSize = new(4, 4);
    public static Vector2 Position = new Vector2(256, 256);
}