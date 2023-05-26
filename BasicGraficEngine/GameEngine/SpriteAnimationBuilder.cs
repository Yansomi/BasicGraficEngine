using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGraficEngine.GameEngine
{
    public class SpriteAnimationBuilder
    {
        private SpriteDirector directorRigth = new SpriteDirector();
        private SpriteDirector directorLeft = new SpriteDirector();
        private SpriteDirector directorUp = new SpriteDirector();
        private SpriteDirector directorDown = new SpriteDirector();

        public void AddMovingToDirectorRight(string directory, Vector sacle)
        {
            this.directorRigth.AddMovingSprites(directory, sacle);
        }
        public void AddMovingToDirectorLeft(string directory, Vector sacle)
        {
            this.directorLeft.AddMovingSprites(directory, sacle);
        }
        public void AddMovingToDirectorUp(string directory, Vector sacle)
        {
            this.directorUp.AddMovingSprites(directory, sacle);
        }
        public void AddMovingToDirectorDown(string directory, Vector sacle)
        {
            this.directorDown.AddMovingSprites(directory, sacle);
        }
        public void AddNotMovingDirectorRight(string directory, Vector sacle)
        {
            directorRigth.AddSpriteForNotMoving(directory, sacle);
        }
        public void AddNotMovingDirectorLeft(string directory, Vector sacle)
        {
            directorLeft.AddSpriteForNotMoving(directory, sacle);
        }
        public void AddNotMovingDirectorUp(string directory, Vector sacle)
        {
            directorUp.AddSpriteForNotMoving(directory, sacle);
        }
        public void AddNotMovingDirectorDown(string directory, Vector sacle)
        {
            directorDown.AddSpriteForNotMoving(directory, sacle);
        }
        /// <summary>
        /// Add images for the correct direction then use this function to creat a SpriteAnimation to
        /// add to your sprite that you want to animate.
        /// Don't forget the images for standing still.
        /// </summary>
        /// <param name="positionForObjToAnimate"></param>
        /// <returns></returns>
        public SpriteAnimation SpriteAnimationBuild(Vector positionForObjToAnimate)
        {
            List<SpriteDirector> directors = new List<SpriteDirector>();
            directors.Add(directorRigth);
            directors.Add(directorLeft);
            directors.Add(directorUp);
            directors.Add(directorDown);
            return new SpriteAnimation(new Vector(positionForObjToAnimate.X,positionForObjToAnimate.Y), directors);
        }

    }
}
