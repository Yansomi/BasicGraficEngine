using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGraficEngine.GameEngine
{
    public class SpriteDirector
    {
        public List<Bitmap> Sprites;
        public Bitmap NotMoving;
        private int instant;

        public SpriteDirector()
        {
            Sprites = new List<Bitmap>();
            NotMoving = null;
            instant = 0;
        }
        public Bitmap GetBitmap(bool moving)
        { 
            if(moving)
            {
                instant++;
                if (instant > Sprites.Count)
                {
                    instant = 0;
                }
                return Sprites[instant];
            }
            else
            {
                return NotMoving;
            }
        }
        public void AddMovingSprites(string Directory,Vector scale)
        {
            Image temp = Image.FromFile($"C:/Users/Hampu/Source/Repos/Yansomi/BasicGraficEngine/BasicGraficEngine/Assets/Sprites/{Directory}.png");
            Bitmap toAdd = new Bitmap(temp,(int)scale.X,(int)scale.Y);
            Sprites.Add(toAdd); 
        }
        public void AddSpriteForNotMoving(string Directory,Vector scale)
        {
            Image temp = Image.FromFile($"C:/Users/Hampu/Source/Repos/Yansomi/BasicGraficEngine/BasicGraficEngine/Assets/Sprites/{Directory}.png");
            Bitmap toAdd = new Bitmap(temp, (int)scale.X, (int)scale.Y);
            NotMoving = toAdd;
        }
    }
}
