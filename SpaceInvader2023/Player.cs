using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class Player
{
    public Texture2D texture;
    public Vector2 position = new Vector2(0, 0);
    public Vector2 direction = new Vector2(0, 0);
    public Vector2 velocity = new Vector2(0, 0);
    
    // Player Varables
    public bool SheildEnabled = false;
    public int SheildHealth = 100;
    public int Health = 100;
    public int CurrentWave = 0;
    public int Score = 0;
    public int[] weapon;




    public Player(Texture2D texture)
    {
        this.texture = texture;
    }

    public void sUpdate(GameTime gameTime)
    {
        position = position + direction * velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public void sDraw(SpriteBatch spritebatch)
    {
        spritebatch.Draw(texture, position, Color.White);
    }







}