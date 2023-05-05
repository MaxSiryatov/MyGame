using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame;

public class Player
{
    public static int FrameWidth = 77;
    public static int FrameHeight = 77;
    internal static Point CurrentFrame = new(0, 0);
    public static Point SpriteSize = new(8, 4);
    public static Texture2D PlayerTexture;

    public static void LoadContent()
    {
        PlayerTexture = Globals.Content.Load<Texture2D>("CowBoy");
    }
}