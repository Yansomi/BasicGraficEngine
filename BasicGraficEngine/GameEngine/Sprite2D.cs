﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BasicGraficEngine.GameEngine
{
    public class Sprite2D
    {
        public Vector Position = null;
        public Vector Scale = null;
        public string Directory = "";
        public string Tag = "";
        public Bitmap Sprite = null;
        public Sprite2D(Vector position, Vector scale, string Directory, string tag)
        {
            this.Position = position;
            this.Scale = scale;
            this.Directory = Directory;
            this.Tag = tag;

            Image temp = Image.FromFile($"Assets/Sprites/{Directory}.png");

            Bitmap sprite = new Bitmap(temp,(int)this.Scale.X, (int)this.Scale.Y);
            this.Sprite = sprite;

            Log.Info($"[SPRITE2D]({Tag}) - Has been registerd!");
            Engine.RegisterSprite(this);
        }
        public void DestroySelf()
        {
            Engine.UnRegisterSprite(this);
        }
    }
}
