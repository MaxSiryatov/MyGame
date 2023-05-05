using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame;

public static class View
{
    public static void Draw(SpriteBatch spriteBatch)
    {
        
        spriteBatch.Draw(Player.PlayerTexture, Control.Position,
            new Rectangle(Player.CurrentFrame.X * Player.FrameWidth,
                Player.CurrentFrame.Y * Player.FrameHeight,
                Player.FrameWidth, Player.FrameHeight),
            Color.White, 0, Vector2.Zero,
            1, SpriteEffects.None, 0);
    }
}