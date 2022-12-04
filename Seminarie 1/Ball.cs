using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminarie_1
{
    public class Ball
    {
        // Vector2
        Vector2 Pos;
        Vector2 Vel;

        // Other
        Texture2D Tex;
        Rectangle DestRec;

        public Ball(Texture2D tex, float radius, Vector2 pos)
        {
            Tex = tex;
            Pos = pos;
        }

        public Ball(Texture2D tex, float radius, Vector2 pos, Vector2 vel)
        {
            Tex = tex;
            Pos = pos;
            Vel = vel;
        }

        public void Update()
        {
            DestRec.X = (int)Pos.X;
            DestRec.Y = (int)Pos.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Tex, DestRec, Color.White);
        }

    }
}
