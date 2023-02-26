using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    Player Ship;
    Enemy[] AlienArray = new Enemy[4];    
    

    SpriteFont _font;


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // Add Font
        _font = Content.Load<SpriteFont>("Spritefont");
        Debug.WriteLine("*** LoadContent Font Completed");

 
        // Ship Player Sprite
        Ship = new Player(Content.Load<Texture2D>("Spaceship"));
        Ship.position = new Vector2(100, 100);
        Ship.velocity.X = 50;
        Ship.velocity.Y = 50;
        Debug.WriteLine("*** LoadContent Player Completed");

        //Enemy Sprites
        AlienArray[0] = new Enemy(Content.Load<Texture2D>(""));
        AlienArray[1] = new Enemy(Content.Load<Texture2D>(""));
        AlienArray[2] = new Enemy(Content.Load<Texture2D>(""));
        AlienArray[3] = new Enemy(Content.Load<Texture2D>(""));
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
        Exit();

        // TODO: Add your update logic here
        KeyboardState kb = Keyboard.GetState();

        if (kb.IsKeyDown(Keys.A))
            Ship.direction.X = -1;
        if (kb.IsKeyDown(Keys.D))
            Ship.direction.X = +1;
        if (kb.IsKeyDown(Keys.W))
            Ship.direction.Y = -1;
        if (kb.IsKeyDown(Keys.S))
            Ship.direction.Y = +1;

        Ship.sUpdate(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();

        string x;
        string y;
        x = "Player Position X:" + Convert.ToString((int)Ship.position.X);
        y = "Player Postiton Y:" + Convert.ToString((int)Ship.position.Y);

        _spriteBatch.DrawString(_font, x, new Vector2(25,25), Color.Black);
        _spriteBatch.DrawString(_font, y, new Vector2(50, 50), Color.Black);

        Ship.sDraw(_spriteBatch);

        for(int i = 0; i < AlienArray.Length; i++)
        {
            AlienArray[i].eDraw(_spriteBatch);
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}