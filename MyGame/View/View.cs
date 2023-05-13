using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGame;

public static class View
{
    public static Texture2D PlayerTexture;
    public static Texture2D Tile1Texture;
    public static Texture2D Tile2Texture;
    public static Texture2D Tile3Texture;
    public static Texture2D PigTexture;
    public static void LoadContent()
    {
        PlayerTexture = Globals.Content.Load<Texture2D>("CowBoy");
        Tile1Texture = Globals.Content.Load<Texture2D>("Tile1");
        Tile2Texture = Globals.Content.Load<Texture2D>("Tile2");
        Tile3Texture = Globals.Content.Load<Texture2D>("Tile3");
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

    public static void DrawTile(int tileNumber, Rectangle rectangle)
    {
        Globals.SpriteBatch.Begin();
        Globals.SpriteBatch.Draw(ChooseTileTexture(tileNumber), rectangle, Color.White);
        Globals.SpriteBatch.End();
    }

    public static Texture2D ChooseTileTexture(int tileNumber)
    {
        return tileNumber switch
        {
            1 => Tile1Texture,
            2 => Tile2Texture,
            3 => Tile3Texture,
            _ => null
        };
    }
}