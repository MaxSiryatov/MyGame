using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class Control
{
    public static float Speed = 5f;
    public static int CurrentTime = 0;
    public static int Period = 50;
    public static Random Random = new Random(); 
    public static int CurrentTimer;
    public static int Timer;
    public static Direction CurrentDirection;

    public static void MovePlayer(KeyboardState keyboardState, GameTime gameTime)
    {
        if (keyboardState.IsKeyDown(Keys.Left) && Player.Position.X >= 0)
            MovePlayerInDirection(Direction.Left, gameTime);
        else if (keyboardState.IsKeyDown(Keys.Right) && Player.Position.X <= Globals.Window.ClientBounds.Width - 70)
            MovePlayerInDirection(Direction.Right, gameTime);
        else if (keyboardState.IsKeyDown(Keys.Up) && Player.Position.Y >= 0)
            MovePlayerInDirection(Direction.Up, gameTime);
        else if (keyboardState.IsKeyDown(Keys.Down) && Player.Position.Y <= Globals.Window.ClientBounds.Height - 90)
            MovePlayerInDirection(Direction.Down, gameTime);
        else MovePlayerInDirection(Direction.None, gameTime);
    }

    public static void MovePig(GameTime gameTime)
    {
        if (CurrentTimer < Timer)
        {
            MovePigInDirection(CurrentDirection, gameTime);
            if (PigNotInBounds())
                ReverseDirection(CurrentDirection);
            CurrentTimer++;
            return;
        }

        var random = Random.Next(3);
        switch (random)
        {
            case 0:
                CurrentDirection = Direction.Down;
                Timer = Random.Next(30, 500);
                CurrentTimer = 0;
                break;
            case 1:
                CurrentDirection = Direction.Left;
                Timer = Random.Next(30, 500);
                CurrentTimer = 0;
                break;
            case 2:
                CurrentDirection = Direction.Right;
                Timer = Random.Next(30, 500);
                CurrentTimer = 0;
                break;
            case 3:
                CurrentDirection = Direction.Up;
                Timer = Random.Next(30, 500);
                CurrentTimer = 0;
                break;
        }
    }

    public static bool PigNotInBounds()
    {
        return Pig.Position.X < 0 || Pig.Position.X > Globals.Window.ClientBounds.Width - 70 || Pig.Position.Y < 0 ||
               Pig.Position.Y > Globals.Window.ClientBounds.Height - 70;
    }

    public static void ReverseDirection(Direction currentDirection)
    {
        CurrentDirection = currentDirection switch
        {
            Direction.Down => Direction.Up,
            Direction.Up => Direction.Down,
            Direction.Left => Direction.Right,
            Direction.Right => Direction.Left,
            _ => CurrentDirection
        };
    }

    private static void MovePlayerInDirection(Direction direction, GameTime gameTime)
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
                    Player.Position.X -= Speed;
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
                    Player.Position.X += Speed;
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
                    Player.Position.Y -= Speed;
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
                    Player.Position.Y += Speed;
                }
                break;
            case Direction.None:
                Player.CurrentFrame.Y = 0;
                Player.CurrentFrame.X = 0;
                break;
        }
    }
    
    private static void MovePigInDirection(Direction direction, GameTime gameTime)
    {
        switch (direction)
        {
            case Direction.Left:
                Pig.CurrentFrame.Y = 1;
                CurrentTime += gameTime.ElapsedGameTime.Milliseconds;
                if (CurrentTime > Period)
                {
                    CurrentTime -= Period;
                    ++Pig.CurrentFrame.X;
                    if (Pig.CurrentFrame.X >= Pig.SpriteSize.X) Pig.CurrentFrame.X = 0;
                    Pig.Position.X -= Speed;
                }
                break;
            case Direction.Right:
                Pig.CurrentFrame.Y = 2;
                CurrentTime += gameTime.ElapsedGameTime.Milliseconds;
                if (CurrentTime > Period)
                {
                    CurrentTime -= Period;
                    ++Pig.CurrentFrame.X;
                    if (Pig.CurrentFrame.X >= Pig.SpriteSize.X) Pig.CurrentFrame.X = 0;
                    Pig.Position.X += Speed;
                }
                break;
            case Direction.Up:
                Pig.CurrentFrame.Y = 3;
                CurrentTime += gameTime.ElapsedGameTime.Milliseconds;
                if (CurrentTime > Period)
                {
                    CurrentTime -= Period;
                    ++Pig.CurrentFrame.X;
                    if (Pig.CurrentFrame.X >= Pig.SpriteSize.X) Pig.CurrentFrame.X = 0;
                    Pig.Position.Y -= Speed;
                }
                break;
            case Direction.Down:
                Pig.CurrentFrame.Y = 0;
                CurrentTime += gameTime.ElapsedGameTime.Milliseconds;
                if (CurrentTime > Period)
                {
                    CurrentTime -= Period;
                    ++Pig.CurrentFrame.X;
                    if (Pig.CurrentFrame.X >= Pig.SpriteSize.X) Pig.CurrentFrame.X = 0;
                    Pig.Position.Y += Speed;
                }
                break;
            case Direction.None:
                Pig.CurrentFrame.Y = 0;
                Pig.CurrentFrame.X = 0;
                break;
        }
    }

}