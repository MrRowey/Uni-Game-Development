using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Enemy
{
    public Texture2D texture;
    public Vector2 position = new Vector2(0,0);
    public Vector2 direction = new Vector2(0, 0);
    public Vector2 velocity = new Vector2(0, 0);

    public int Health = 100;
    public float HealthMulti = 0.1f;
    public int WeaponDmg = 5;
    public float WeaponDmgMulti = 1f;
    
    
    
    public Random rand = new Random();


    public Enemy(Texture2D texture)
    {
        this.texture = texture;
    }

    public void eUpdate(GameTime gameTime)
    {
        position = position + direction * velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public void eDraw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, position, Color.White);
    }


}