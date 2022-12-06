using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.XAudio2;
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
        public Vector2 pos;
        public Vector2 vel;

        // Float
        public float Radius;
        public float Mass;

        // Other
        Texture2D Tex;
        public Rectangle DestRec;
        Color DrawColor = Color.White;

        public Vector2 Pos { get => Pos; set => Pos = value; }
        public Vector2 Vel { get => Vel; set => Vel = value; }

        public Ball(Texture2D tex, float radius, Vector2 pos)
        {
            Tex = tex;
            this.pos = pos;
            Radius = radius;
            Mass = 1.0f;
            SetConstants();
        }

        public Ball(Texture2D tex, float radius, Vector2 pos, Vector2 vel)
        {
            Tex = tex;
            this.pos = pos;
            this.vel = vel;
            Radius = radius;
            Mass = 1.0f;
            SetConstants();
        }

        public Ball(Texture2D tex, float radius, float mass, Vector2 pos)
        {
            Tex = tex;
            this.pos = pos;
            Radius = radius;
            Mass = mass;
            SetConstants();
        }

        public Ball(Texture2D tex, float radius, float mass, Vector2 pos, Vector2 vel)
        {
            Tex = tex;
            this.pos = pos;
            this.vel = vel;
            Radius = radius;
            Mass = mass;
            SetConstants();
        }

        public void Update()
        {
            pos += vel;

            UpdateDestRec();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Tex, DestRec, DrawColor);
        }

        void SetConstants()
        {
            DestRec = new((int)(pos.X- Radius), (int)(pos.Y-Radius), (int)Radius * 2,(int)Radius*2);
        }

        public void SetColor(Color newColor)
        {
            DrawColor = newColor;
        }

        public void UpdateDestRec()
        {
            DestRec.X = (int)(pos.X - Radius);
            DestRec.Y = (int)(pos.Y - Radius);
        }
    }
}
