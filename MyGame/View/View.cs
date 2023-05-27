using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame;

public static class View
{
    public static Texture2D PlayerTexture;
    private static Texture2D _tile1Texture;
    private static Texture2D _tile2Texture;
    private static Texture2D _tile3Texture;
    private static Texture2D _tile4Texture;
    private static Texture2D _tile5Texture;
    private static Texture2D _tile6Texture;
    private static Texture2D _tile7Texture;
    private static Texture2D _tile8Texture;
    private static Texture2D _tile9Texture;
    private static Texture2D _tile10Texture;
    private static Texture2D _tile11Texture;
    public static Texture2D PigTexture;
    public static Texture2D PausedTexture;
    public static Texture2D PlayTexture;
    public static Texture2D QuitTexture;
    public static SpriteFont Font;

    public static void LoadContent()
    {
        PlayerTexture = Globals.Content.Load<Texture2D>("CowBoy");
        _tile1Texture = Globals.Content.Load<Texture2D>("Tile1");
        _tile2Texture = Globals.Content.Load<Texture2D>("Tile2");
        _tile3Texture = Globals.Content.Load<Texture2D>("Tile3");
        _tile4Texture = Globals.Content.Load<Texture2D>("Tile4");
        _tile5Texture = Globals.Content.Load<Texture2D>("Tile5");
        _tile6Texture = Globals.Content.Load<Texture2D>("Tile6");
        _tile7Texture = Globals.Content.Load<Texture2D>("Tile7");
        _tile8Texture = Globals.Content.Load<Texture2D>("Tile8");
        _tile9Texture = Globals.Content.Load<Texture2D>("Tile9");
        _tile10Texture = Globals.Content.Load<Texture2D>("Tile10");
        _tile11Texture = Globals.Content.Load<Texture2D>("Tile11");
        PigTexture = Globals.Content.Load<Texture2D>("PigModel");
        PausedTexture = Globals.Content.Load<Texture2D>("Pause");
        Font = Globals.Content.Load<SpriteFont>("File");
        PlayTexture = Globals.Content.Load<Texture2D>("Play");
        QuitTexture = Globals.Content.Load<Texture2D>("Quit");
    }
    public static void DrawUnit(Texture2D texture, Vector2 position, Point currentFrame, int frameWidth, int frameHeight)
    {
        Globals.SpriteBatch.Begin();
        Globals.SpriteBatch.Draw(texture, position, new Rectangle(currentFrame.X * frameWidth,
                currentFrame.Y * frameHeight,
                frameWidth, frameHeight), Color.White, 0, Vector2.Zero,
            1, SpriteEffects.None, 0);
        Globals.SpriteBatch.End();
    }

    public static void DrawMap()
    {
        foreach (var tile in Map.CollisionTiles)
        {
            DrawTile(tile.TileNumber, tile.CollisionRectangle);
        }
    }
    
    public static void DrawButton()
    {
        Globals.SpriteBatch.Begin(); ;
        Globals.SpriteBatch.Draw(PausedTexture, Pause.PausedRectangle, Color.White);
        Globals.SpriteBatch.Draw(PlayTexture, PlayButton.Rectangle, PlayButton.Color);
        Globals.SpriteBatch.Draw(QuitTexture, QuitButton.Rectangle, QuitButton.Color);
        Globals.SpriteBatch.End();
    }

    private static void DrawTile(int tileNumber, Rectangle rectangle)
    {
        Globals.SpriteBatch.Begin();
        Globals.SpriteBatch.Draw(ChooseTileTexture(tileNumber), rectangle, Color.White);
        Globals.SpriteBatch.End();
    }

    public static void DrawScore()
    {
        Globals.SpriteBatch.Begin();
        Globals.SpriteBatch.DrawString(Font, $"Score:{Globals.Score}", new Vector2(20, 10), Color.Yellow);
        Globals.SpriteBatch.End();
    }

    private static Texture2D ChooseTileTexture(int tileNumber)
    {
        return tileNumber switch
        {
            1 => _tile1Texture,
            2 => _tile2Texture,
            3 => _tile3Texture,
            4 => _tile4Texture,
            5 => _tile5Texture,
            6 => _tile6Texture,
            7 => _tile7Texture,
            8 => _tile8Texture,
            9 => _tile9Texture,
            10 => _tile10Texture,
            11 => _tile11Texture,
            _ => null
        };
    }
}