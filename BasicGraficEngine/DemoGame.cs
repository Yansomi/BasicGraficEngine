using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BasicGraficEngine.GameEngine;

namespace BasicGraficEngine
{
    public class DemoGame : GameEngine.Engine
    {
        Sprite2D Player;
        List<string> Tags = new List<string>();

        bool Left;
        bool Right;
        bool Up;
        bool Down;
        MapHandler mapHandler = new MapHandler();
       // string[,] Buildings =
       //{
       //      {"w","w","w","w","w","w","w"},
       //      {"w","g","g","g","g","g","w"},
       //      {"w","g","g","g","g","g","w"},
       //      {"w","g","g","b","g","g","w"},
       //      {"w","g","g","g","g","g","w"},
       //      {"w","g","g","g","g","g","w"},
       //      {"w","w","w","w","w","w","w"},
       // };
        public DemoGame() : base(new Vector(720,720),"Basic Engine Demo")
        { 
        }

        public override void OnDraw()
        {
            
        }

        public override void OnLoad()
        {
            BackgroundColor = Color.Black;
            mapHandler.LoadMap();

            //for (int i = 0; i < Map.GetLength(0); i++)
            //{
            //    for (int j = 0; j < Map.GetLength(1); j++)
            //    {
            //        if (Buildings[i,j] == "b")
            //        {
            //            new Sprite2D(new Vector(j * 36, i * 36), new Vector(51, 80), "Houses/House", "House");
            //        }
            //    }
            //}

            SpriteDirector director1 = new SpriteDirector();
            SpriteDirector director2 = new SpriteDirector();
            SpriteDirector director3 = new SpriteDirector();
            SpriteDirector director4 = new SpriteDirector();

            director1.AddSpriteForNotMoving("Player/Right", new Vector(11, 16));
            director1.AddMovingSprites("Player/Right2", new Vector(11, 16));
            director1.AddMovingSprites("Player/Right3", new Vector(11, 16));
            director1.AddMovingSprites("Player/Right4", new Vector(11, 16));

            director2.AddSpriteForNotMoving("Player/Left", new Vector(11, 16));
            director2.AddMovingSprites("Player/Left2", new Vector(11, 16));
            director2.AddMovingSprites("Player/Left3", new Vector(11, 16));
            director2.AddMovingSprites("Player/Left4", new Vector(11, 16));

            director3.AddSpriteForNotMoving("Player/Up", new Vector(11, 16));
            director3.AddMovingSprites("Player/Up2", new Vector(11, 16));
            director3.AddMovingSprites("Player/Up3", new Vector(11, 16));
            director3.AddMovingSprites("Player/Up4", new Vector(11, 16));

            director4.AddSpriteForNotMoving("Player/Down", new Vector(11, 16));
            director4.AddMovingSprites("Player/Down2", new Vector(11, 16));
            director4.AddMovingSprites("Player/Down3", new Vector(11, 16));
            director4.AddMovingSprites("Player/Down4", new Vector(11, 16));

            List<SpriteDirector> spriteDirectorsList = new List<SpriteDirector>();
            spriteDirectorsList.Add(director1);
            spriteDirectorsList.Add(director2);
            spriteDirectorsList.Add(director3);
            spriteDirectorsList.Add(director4);
            Player = new Sprite2D(new Vector(40, 40), new Vector(11, 16), "Player/Left", "Player");
            Vector v = new Vector();
            v.X = Player.Position.X;
            v.Y = Player.Position.Y;
            SpriteAnimation animation = new SpriteAnimation(v, spriteDirectorsList);
            Player.AddSpriteAnimation(animation);


            Tags.Add("Water");
            Tags.Add("House");
            Tags.Add("Tree");
        }
        int times = 0;
        float n = -1f;
        public override void OnUpdate()
        {
            if (Up) { Player.Position.Y -=1f; }
            if(Down) { Player.Position.Y +=1f; }
            if (Left) { Player.Position.X -= 1f; } 
            if (Right) { Player.Position.X += 1f; }

            Player.CollitionStop(Player.IsColliding(Tags));
            Player.cycleAnimation();
            base.CameraPosition.X = Player.Position.X * n + 360;
            base.CameraPosition.Y = Player.Position.Y * n + 360;
        }

        public override void GetKeyDown(KeyEventArgs e)
        {
            if(e.KeyCode == Keys.W)
            {
                Up = true;
            }
            if (e.KeyCode == Keys.S)
            {
                Down = true;
            }
            if (e.KeyCode == Keys.A)
            {
                Left = true;
            }
            if (e.KeyCode == Keys.D)
            {
                Right = true;
            }


        }

        public override void GetKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                Up = false;
            }
            if (e.KeyCode == Keys.S)
            {
                Down = false;
            }
            if (e.KeyCode == Keys.A)
            {
                Left = false;
            }
            if (e.KeyCode == Keys.D)
            {
                Right = false;
            }
        }
        void MapCaller()
        {
            mapHandler.LoadMap();
        }
    }
}
