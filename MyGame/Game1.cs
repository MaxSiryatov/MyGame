using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGame;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Map _map;
    public static PlayButton BtnPlay;
    public static QuitButton BtnQuit;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.PreferredBackBufferWidth = 1280;
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
        IsMouseVisible = true;
        Globals.SpriteBatch = _spriteBatch;
        BtnPlay = new PlayButton();
        BtnQuit = new QuitButton();
        View.LoadContent();
        _map.Generate(Map.MapGrid, 48);
    }

    protected override void Update(GameTime gameTime)
    {
        var keyboardState = Keyboard.GetState();
        var mouseState = Mouse.GetState();
        
        if (!Globals.Paused)
        {
            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                Globals.Paused = true;
                PlayButton.isClicked = false;
            }
            Control.MovePlayer(keyboardState, gameTime);
            Control.MovePig(gameTime);
            Player.Update();
            Pig.Update();
        }
        else if (Globals.Paused)
        {
            if (PlayButton.isClicked)
                Globals.Paused = false;
            if (QuitButton.isClicked)
                Exit();
            PlayButton.Update(mouseState);
            QuitButton.Update(mouseState);
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        View.DrawMap();
        View.DrawUnit(View.PlayerTexture, Player.Position, Player.CurrentFrame, Player.FrameWidth, Player.FrameHeight);
        View.DrawUnit(View.PigTexture, Pig.Position, Pig.CurrentFrame, Pig.FrameWidth, Pig.FrameHeight);
        View.DrawScore();
        if (Globals.Paused)
            View.DrawButton();
        base.Draw(gameTime);
    }
}