using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame;

public static class View
{
    public static Texture2D PlayerTexture;
    private static Texture2D _tile1Texture;
    private static Texture2D _tile2Texture;
    private static Texture2D _tile3Texture;
    public static Texture2D PigTexture;
    public static void LoadContent()
    {
        PlayerTexture = Globals.Content.Load<Texture2D>("CowBoy");
        _tile1Texture = Globals.Content.Load<Texture2D>("Tile1");
        _tile2Texture = Globals.Content.Load<Texture2D>("Tile2");
        _tile3Texture = Globals.Content.Load<Texture2D>("Tile3");
        PigTexture = Globals.Content.Load<Texture2D>("PigModel");
    }
    public static void DrawUnit(Texture2D texture, Vector2 position, Point currentFrame, int frameWidth, int frameHeight)
    {
        Globals.SpriteBatch.Begin();
        Globals.SpriteBatch.Draw(texture, position,
            new Rectangle(currentFrame.X * frameWidth,
                currentFrame.Y * frameHeight,
                frameWidth, frameHeight),
            Color.White, 0, Vector2.Zero,
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

    private static void DrawTile(int tileNumber, Rectangle rectangle)
    {
        Globals.SpriteBatch.Begin();
        Globals.SpriteBatch.Draw(ChooseTileTexture(tileNumber), rectangle, Color.White);
        Globals.SpriteBatch.End();
    }

    private static Texture2D ChooseTileTexture(int tileNumber)
    {
        return tileNumber switch
        {
            1 => _tile1Texture,
            2 => _tile2Texture,
            3 => _tile3Texture,
            _ => null
        };
    }
}