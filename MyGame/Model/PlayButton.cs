using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class PlayButton
{
    public static Vector2 Position = new Vector2(1000, 500);
    public static Rectangle Rectangle;
    public static Color Color = new Color(255, 255, 255, 255);
    public static bool down;
    public static bool isClicked;

    public PlayButton()
    {
        
    }
    
    public static void Update(MouseState mouse)
    {
        mouse = Mouse.GetState();
        Rectangle = new Rectangle((int)Position.X, (int)Position.Y, View.PlayTexture.Width, View.PlayTexture.Height);
        var mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

        if (mouseRectangle.Intersects(Rectangle))
        {
            if (Color.A == 255) down = false;
            if (Color.A == 0) down = true;
            if (down) Color.A += 3;
            else Color.A -= 3;
            if (mouse.LeftButton == ButtonState.Pressed)
            {
                isClicked = true;
                Color.A = 255;
            }
        }
        else if (Color.A < 255)
            Color.A += 3;
    }
}