using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class Control
{
    private static readonly float playerSpeed = 6f;
    private static readonly float pigSpeed = 3f;
    private static int boundsMoveCount = 0;
    private static int _currentTime = 0;
    private static readonly int _period = 50;
    private static readonly Random _random = new Random();
    private static int _currentTimer;
    private static int _timer;
    private static Direction _currentDirection;
    private static bool switchMovementLogic = false;

    public static void MovePlayer(KeyboardState keyboardState, GameTime gameTime)
    {
        if (keyboardState.IsKeyDown(Keys.Left) && Player.Position.X >= 0 && 
            PlayerCanMove(Player.Rectangle, Pig.Rectangle))
            MovePlayerInDirection(Direction.Left, gameTime);
        else if (keyboardState.IsKeyDown(Keys.Right) && Player.Position.X <= Globals.Window.ClientBounds.Width - 70 &&
                 PlayerCanMove(Player.Rectangle, Pig.Rectangle))
            MovePlayerInDirection(Direction.Right, gameTime);
        else if (keyboardState.IsKeyDown(Keys.Up) && Player.Position.Y >= 0 &&
                 PlayerCanMove(Player.Rectangle, Pig.Rectangle))
            MovePlayerInDirection(Direction.Up, gameTime);
        else if (keyboardState.IsKeyDown(Keys.Down) && Player.Position.Y <= Globals.Window.ClientBounds.Height - 90 &&
                 PlayerCanMove(Player.Rectangle, Pig.Rectangle))
            MovePlayerInDirection(Direction.Down, gameTime);
        else MovePlayerInDirection(Direction.None, gameTime);
    }

    public static void MovePig(GameTime gameTime)
    {
        if (switchMovementLogic)
        {
            if (Player.Rectangle.X - Pig.Rectangle.X > 3)
            {
                MovePigInDirection(Direction.Right, gameTime);
                CheckForCollision(Pig.Rectangle);
                return;
            }
            if (Pig.Rectangle.X - Player.Rectangle.X > 3)
            {
                MovePigInDirection(Direction.Left, gameTime);
                CheckForCollision(Pig.Rectangle);
                return;
            }

            if (Pig.Rectangle.Y - Player.Rectangle.Y > 3)
            {
                MovePigInDirection(Direction.Up, gameTime);
                CheckForCollision(Pig.Rectangle);
                return;
            }
            if (Player.Rectangle.Y - Pig.Rectangle.Y > 3)
            {
                MovePigInDirection(Direction.Down, gameTime);
                CheckForCollision(Pig.Rectangle);
            }
        }
        
        else if (_currentTimer < _timer)
        {
            if (UnitNotInBounds(Pig.Rectangle) || PigCollisionPlayer() || boundsMoveCount > 0 || CheckForCollision(Pig.Rectangle)) 
            {
                if (boundsMoveCount > 0)
                    if (boundsMoveCount == 4)
                    {
                        MovePigInDirection(_currentDirection, gameTime);
                        boundsMoveCount = 0;
                        _currentTimer++;
                    }
                    else
                    {
                        MovePigInDirection(_currentDirection, gameTime);
                        boundsMoveCount++;
                        _currentTimer++;
                    }
                else
                {
                    if (PigCollisionPlayer())
                    {
                        switchMovementLogic = true;
                    }

                    else
                    { 
                        ReverseDirection(_currentDirection);
                        MovePigInDirection(_currentDirection, gameTime);
                        boundsMoveCount++;
                        _currentTimer++;  
                    }
                }
            }
            else
            {
                MovePigInDirection(_currentDirection, gameTime);
                _currentTimer++;
            }
        }
        else
        {
            GetRandomDirection();
            MovePigInDirection(_currentDirection, gameTime);
            _currentTimer++;
        }
    }

    private static bool CheckForCollision(Rectangle rectangle)
    {
        var collisionTilesNums = new List<int> { 3, 4, 5, 7, 8, 9, 11 };
        foreach (var tile in Map.CollisionTiles)
        {
            if (rectangle.Intersects(tile.CollisionRectangle) && tile.TileNumber == 6)
            {
                Pig.Position = new Vector2(Globals.Window.ClientBounds.Width / 2, Globals.Window.ClientBounds.Height / 2);
                Globals.Score++;
                switchMovementLogic = false;
            }
            if (rectangle.Intersects(tile.CollisionRectangle) && collisionTilesNums.Contains(tile.TileNumber))
                return true;
        }

        return false;
    }

    private static void GetRandomDirection()
    {
        var random = _random.Next(3);
        switch (random)
        {
            case 0:
                _currentDirection = Direction.Down;
                _timer = _random.Next(40, 300);
                _currentTimer = 0;
                break;
            case 1:
                _currentDirection = Direction.Left;
                _timer = _random.Next(40, 300);
                _currentTimer = 0;
                break;
            case 2:
                _currentDirection = Direction.Right;
                _timer = _random.Next(40, 300);
                _currentTimer = 0;
                break;
            case 3:
                _currentDirection = Direction.Up;
                _timer = _random.Next(40, 300);
                _currentTimer = 0;
                break;
        }
    }

    private static Direction GetCollisionDirection(float position1X, float position1Y, float position2X, float position2Y)
    {
        if ((int)position2X - (int)position1X >= 0 && (int)position2X - (int)position1X <= 150)
            return Direction.Left;
        if ((int)position1X - (int)position2X >= 0 && (int)position1X - (int)position2X <= 150)
            return Direction.Right;
        if ((int)position1Y - (int)position2Y >= 0 && (int)position2Y - (int)position1Y <= 150)
            return Direction.Down;
        if ((int)position2Y - (int)position1Y >= 0 && (int)position1Y - (int)position2Y <= 150)
            return Direction.Up;
        return _currentDirection;
    }

    private static bool PlayerCanMove(Rectangle playerRectangle, Rectangle unitRectangle)
    {
        return !(playerRectangle.X - unitRectangle.X >= 64 && playerRectangle.X - unitRectangle.X <= 200 &&
        unitRectangle.X - playerRectangle.X >= 64 && unitRectangle.X - playerRectangle.X <= 200 && 
        unitRectangle.Y - playerRectangle.Y >= 64 && playerRectangle.Y - unitRectangle.Y <= 200 &&
         playerRectangle.Y - unitRectangle.Y >= 64 && unitRectangle.Y - playerRectangle.Y <= 200);
    }

    private static bool UnitNotInBounds(Rectangle rectangle)
    {
        return rectangle.X <= 10 || rectangle.X >= Globals.Window.ClientBounds.Width - 90 || rectangle.Y <= 10 ||
               rectangle.Y >= Globals.Window.ClientBounds.Height - 90;
    }

    private static bool PigCollisionPlayer()
    {
        return Pig.Rectangle.Intersects(Player.Rectangle);
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
                    Player.Position.X -= playerSpeed;
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
                    Player.Position.X += playerSpeed;
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
                    Player.Position.Y -= playerSpeed;
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
                    Player.Position.Y += playerSpeed;
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
                    Pig.Position.X -= pigSpeed;
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
                    Pig.Position.X += pigSpeed;
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
                    Pig.Position.Y -= pigSpeed;
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
                    Pig.Position.Y += pigSpeed;
                }
                break;
            case Direction.None:
                Pig.CurrentFrame.Y = 0;
                Pig.CurrentFrame.X = 0;
                break;
        }
    }

}