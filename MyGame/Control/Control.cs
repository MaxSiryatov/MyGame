using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class Control
{
    public static Vector2 Position = Vector2.Zero;
    public static float Speed = 5f;
    public static int CurrentTime = 0;
    public static int Period = 50;

    public static void MovePlayer(KeyboardState keyboardState, GameTime gameTime)
    {
        if (keyboardState.IsKeyDown(Keys.Left) && Position.X >= 0)
            MoveInDirection(Direction.Left, gameTime);
        else if (keyboardState.IsKeyDown(Keys.Right) && Position.X <= Globals.Window.ClientBounds.Width - 70)
            MoveInDirection(Direction.Right, gameTime);
        else if (keyboardState.IsKeyDown(Keys.Up) && Position.Y >= 0)
            MoveInDirection(Direction.Up, gameTime);
        else if (keyboardState.IsKeyDown(Keys.Down) && Position.Y <= Globals.Window.ClientBounds.Height - 90)
            MoveInDirection(Direction.Down, gameTime);
        else MoveInDirection(Direction.None, gameTime);
    }

    private static void MoveInDirection(Direction direction, GameTime gameTime)
    {
        switch (direction)
        {
            case Direction.Left:
                Player.CurrentFrame.Y = 1;
                CurrentTime += gameTime.ElapsedGameTime.Milliseconds;
                if (CurrentTime > Period)
                {
                    CurrentTime -= Period;
                    ++Player.CurrentFrame.X;
                    if (Player.CurrentFrame.X >= Player.SpriteSize.X) Player.CurrentFrame.X = 0;
                    Position.X -= Speed;
                }
                break;
            case Direction.Right:
                Player.CurrentFrame.Y = 2;
                CurrentTime += gameTime.ElapsedGameTime.Milliseconds;
                if (CurrentTime > Period)
                {
                    CurrentTime -= Period;
                    ++Player.CurrentFrame.X;
                    if (Player.CurrentFrame.X >= Player.SpriteSize.X) Player.CurrentFrame.X = 0;
                    Position.X += Speed;
                }
                break;
            case Direction.Up:
                Player.CurrentFrame.Y = 3;
                CurrentTime += gameTime.ElapsedGameTime.Milliseconds;
                if (CurrentTime > Period)
                {
                    CurrentTime -= Period;
                    ++Player.CurrentFrame.X;
                    if (Player.CurrentFrame.X >= Player.SpriteSize.X) Player.CurrentFrame.X = 0;
                    Position.Y -= Speed;
                }
                break;
            case Direction.Down:
                Player.CurrentFrame.Y = 0;
                CurrentTime += gameTime.ElapsedGameTime.Milliseconds;
                if (CurrentTime > Period)
                {
                    CurrentTime -= Period;
                    ++Player.CurrentFrame.X;
                    if (Player.CurrentFrame.X >= Player.SpriteSize.X) Player.CurrentFrame.X = 0;
                    Position.Y += Speed;
                }
                break;
            case Direction.None:
                Player.CurrentFrame.Y = 0;
                Player.CurrentFrame.X = 0;
                break;
        }
    }

}