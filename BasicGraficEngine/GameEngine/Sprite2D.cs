using System;
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
        public Vector LasPos = new Vector();
        public string Directory = "";
        public string Tag = "";
        public Bitmap Sprite = null;
        public SpriteAnimation Animation = null;
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
        public bool IsColliding(List<string> Tags)
        {
            foreach(Sprite2D b in Engine.AllSprites)
            {
                foreach (string Tag in Tags)
                {
                    if (b.Tag == Tag)
                    {
                        if (Position.X + Scale.X >= b.Position.X &&
                            Position.Y + Scale.Y >= b.Position.Y &&
                            Position.X <= b.Position.X + b.Scale.X &&
                            Position.Y <= b.Position.Y + b.Scale.Y)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public void DestroySelf()
        {
            Engine.UnRegisterSprite(this);
        }
        /// <summary>
        /// Takes the IsColliding function to stop movement when colliding with other
        /// objekt with specific tag.
        /// </summary>
        /// <param name="IsColliding"></param>
        public void CollitionStop(bool IsColliding)
        {
            if(IsColliding)
            {
                Position.X = LasPos.X;
                Position.Y = LasPos.Y;
            }
            else
            {
                LasPos.X = Position.X;
                LasPos.Y = Position.Y;
            }
        }
        public void AddSpriteAnimation(SpriteAnimation spriteAnimation)
        {
            this.Animation = spriteAnimation;
        }
        public void cycleAnimation()
        {
            this.Sprite = Animation.GetSpriteForDirection(this.Position);
            Engine.UpdateSpriteWithTag(Sprite, Tag);
        }
        public void UpdateSpirte(Bitmap sprite)
        {
            this.Sprite = sprite;
        }
    }
}
