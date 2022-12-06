﻿using Microsoft.Xna.Framework;
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
        Vector2 pos;
        Vector2 vel;

        // Other
        Texture2D Tex;
        Rectangle DestRec;
        Color DrawColor = Color.White;

        float Radius;

        public Vector2 Pos { get => Pos; set => Pos = value; }

        public Ball(Texture2D tex, float radius, Vector2 pos)
        {
            Tex = tex;
            this.pos = pos;
            Radius = radius;
        }

        public Ball(Texture2D tex, float radius, Vector2 pos, Vector2 vel)
        {
            Tex = tex;
            this.pos = pos;
            this.vel = vel;
            Radius = radius;
        }

        public void Update()
        {
            DestRec.X = (int)pos.X;
            DestRec.Y = (int)pos.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Tex, DestRec, DrawColor);
        }

        public void SetColor(Color newColor)
        {
            DrawColor = newColor;
        }
    }
}
