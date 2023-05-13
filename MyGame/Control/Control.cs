using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class Control
{
    private static readonly float speed = 5f;
    private static int _currentTime = 0;
    private static readonly int _period = 50;
    private static readonly Random _random = new Random();
    private static int _currentTimer;
    private static int _timer;
    private static Direction _currentDirection;

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
        if (_currentTimer < _timer)
        {
            MovePigInDirection(_currentDirection, gameTime);
            if (PigNotInBounds())
                ReverseDirection(_currentDirection);
            _currentTimer++;
            return;
        }

        var random = _random.Next(3);
        switch (random)
        {
            case 0:
                _currentDirection = Direction.Down;
                _timer = _random.Next(30, 500);
                _currentTimer = 0;
                break;
            case 1:
                _currentDirection = Direction.Left;
                _timer = _random.Next(30, 500);
                _currentTimer = 0;
                break;
            case 2:
                _currentDirection = Direction.Right;
                _timer = _random.Next(30, 500);
                _currentTimer = 0;
                break;
            case 3:
                _currentDirection = Direction.Up;
                _timer = _random.Next(30, 500);
                _currentTimer = 0;
                break;
        }
    }

    private static bool PigNotInBounds()
    {
        return Pig.Position.X < 0 || Pig.Position.X > Globals.Window.ClientBounds.Width - 70 || Pig.Position.Y < 0 ||
               Pig.Position.Y > Globals.Window.ClientBounds.Height - 70;
    }

    private static void ReverseDirection(Direction currentDirection)
    {
        _currentDirection = currentDirection switch
        {
            Direction.Down => Direction.Up,
            Direction.Up => Direction.Down,
            Direction.Left => Direction.Right,
            Direction.Right => Direction.Left,
            _ => _currentDirection
        };
    }

    private static void MovePlayerInDirection(Direction direction, GameTime gameTime)
    {
        switch (direction)
        {
            case Direction.Left:
                Player.CurrentFrame.Y = 1;
                _currentTime += gameTime.ElapsedGameTime.Milliseconds;
                if (_currentTime > _period)
                {
                    _currentTime -= _period;
                    ++Player.CurrentFrame.X;
                    if (Player.CurrentFrame.X >= Player.SpriteSize.X) Player.CurrentFrame.X = 0;
                    Player.Position.X -= speed;
                }
                break;
            case Direction.Right:
                Player.CurrentFrame.Y = 2;
                _currentTime += gameTime.ElapsedGameTime.Milliseconds;
                if (_currentTime > _period)
                {
                    _currentTime -= _period;
                    ++Player.CurrentFrame.X;
                    if (Player.CurrentFrame.X >= Player.SpriteSize.X) Player.CurrentFrame.X = 0;
                    Player.Position.X += speed;
                }
                break;
            case Direction.Up:
                Player.CurrentFrame.Y = 3;
                _currentTime += gameTime.ElapsedGameTime.Milliseconds;
                if (_currentTime > _period)
                {
                    _currentTime -= _period;
                    ++Player.CurrentFrame.X;
                    if (Player.CurrentFrame.X >= Player.SpriteSize.X) Player.CurrentFrame.X = 0;
                    Player.Position.Y -= speed;
                }
                break;
            case Direction.Down:
                Player.CurrentFrame.Y = 0;
                _currentTime += gameTime.ElapsedGameTime.Milliseconds;
                if (_currentTime > _period)
                {
                    _currentTime -= _period;
                    ++Player.CurrentFrame.X;
                    if (Player.CurrentFrame.X >= Player.SpriteSize.X) Player.CurrentFrame.X = 0;
                    Player.Position.Y += speed;
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
                _currentTime += gameTime.ElapsedGameTime.Milliseconds;
                if (_currentTime > _period)
                {
                    _currentTime -= _period;
                    ++Pig.CurrentFrame.X;
                    if (Pig.CurrentFrame.X >= Pig.SpriteSize.X) Pig.CurrentFrame.X = 0;
                    Pig.Position.X -= speed;
                }
                break;
            case Direction.Right:
                Pig.CurrentFrame.Y = 2;
                _currentTime += gameTime.ElapsedGameTime.Milliseconds;
                if (_currentTime > _period)
                {
                    _currentTime -= _period;
                    ++Pig.CurrentFrame.X;
                    if (Pig.CurrentFrame.X >= Pig.SpriteSize.X) Pig.CurrentFrame.X = 0;
                    Pig.Position.X += speed;
                }
                break;
            case Direction.Up:
                Pig.CurrentFrame.Y = 3;
                _currentTime += gameTime.ElapsedGameTime.Milliseconds;
                if (_currentTime > _period)
                {
                    _currentTime -= _period;
                    ++Pig.CurrentFrame.X;
                    if (Pig.CurrentFrame.X >= Pig.SpriteSize.X) Pig.CurrentFrame.X = 0;
                    Pig.Position.Y -= speed;
                }
                break;
            case Direction.Down:
                Pig.CurrentFrame.Y = 0;
                _currentTime += gameTime.ElapsedGameTime.Milliseconds;
                if (_currentTime > _period)
                {
                    _currentTime -= _period;
                    ++Pig.CurrentFrame.X;
                    if (Pig.CurrentFrame.X >= Pig.SpriteSize.X) Pig.CurrentFrame.X = 0;
                    Pig.Position.Y += speed;
                }
                break;
            case Direction.None:
                Pig.CurrentFrame.Y = 0;
                Pig.CurrentFrame.X = 0;
                break;
        }
    }

}