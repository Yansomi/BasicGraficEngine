using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGraficEngine.GameEngine
{
    public class SpriteAnimation
    {
        public Vector Position;
        public List<SpriteDirector> SpriteDirectors;

        private int Times;
        private int LastDirection;
        private Bitmap LastSprite;
        /// <summary>
        /// Takes a list of SpriteDirectors
        /// directors are in following order:
        /// 0 - Right
        /// 1 - Left
        /// 2 - Up
        /// 3 - Down
        /// Each director takes a list of sprites to cicle through and one for
        /// not Moving.
        /// </summary>
        /// <param name="Position"></param>
        /// <param name="directors"></param>
        public SpriteAnimation(Vector Position, List<SpriteDirector> directors) 
        {
            this.Position = Position;
            this.SpriteDirectors = directors;
            Times = 0;
            LastDirection = 0;
            LastSprite = null;
        }
        public Bitmap GetSpriteForDirection(Vector direction)
        {
            if (Times == 0)
            {
                if (Position.X < direction.X)
                {
                    Times++;
                    LastSprite = SpriteDirectors[0].GetBitmap(true);
                    Position.X = direction.X;
                    Position.Y = direction.Y;
                    return LastSprite;
                }
                if(Position.X > direction.X)
                {
                    Times++;
                    LastSprite = SpriteDirectors[1].GetBitmap(true);
                    Position.X = direction.X;
                    Position.Y = direction.Y;
                    return LastSprite;
                }
                if(Position.Y > direction.Y)
                {
                    Times++;
                    LastSprite = SpriteDirectors[2].GetBitmap(true);
                    Position.X = direction.X;
                    Position.Y = direction.Y;
                    return LastSprite;
                }
                if (Position.Y < direction.Y)
                {
                    Times++;
                    LastSprite = SpriteDirectors[3].GetBitmap(true);
                    Position.X = direction.X;
                    Position.Y = direction.Y;
                    return LastSprite;
                }
                if(Position.X == direction.X &&
                    Position.Y== direction.Y) 
                {
                    Times++;
                    LastSprite = SpriteDirectors[LastDirection].GetBitmap(false);
                    return LastSprite;
                }
            }
            else if(Times == 2)
            {
                Times = 0;
            }
            return LastSprite;
        }
    }
}
