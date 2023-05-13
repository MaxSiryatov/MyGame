using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Map _map;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        Globals.Content = Content;
        Tiles.Content = Content;
        Globals.SpriteBatch = _spriteBatch;
        Globals.Window = Window;

        _map = new Map();
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Globals.SpriteBatch = _spriteBatch;
        View.LoadContent();
        _map.Generate(Map.MapGrid, 32);
    }

    protected override void Update(GameTime gameTime)
    {
        var keyboardState = Keyboard.GetState();
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            keyboardState.IsKeyDown(Keys.Escape))
            Exit();
        
        Control.MovePlayer(keyboardState, gameTime);
        Control.MovePig(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        View.DrawMap();
        View.DrawUnit(View.PlayerTexture, Player.Position, Player.CurrentFrame, Player.FrameWidth, Player.FrameHeight);
        View.DrawUnit(View.PigTexture, Pig.Position, Pig.CurrentFrame, Pig.FrameWidth, Pig.FrameHeight);
        base.Draw(gameTime);
    }
}