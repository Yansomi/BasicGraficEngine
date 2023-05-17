using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BasicGraficEngine.GameEngine;

namespace BasicGraficEngine
{
    public class DemoGame : GameEngine.Engine
    {
        //Sprite2D Player;

        string[,] Map =
        {
             {".",".",".",".",".",".","."},
             {".",".",".",".",".",".","."},
             {".","g","g","g","g","g","."},
             {".","g","g","g","g","g","."},
             {".","g","g","g","g","g","."},
             {".","g","g","g","g","g","."},
             {".",".",".",".",".",".","."},
        };
        public DemoGame() : base(new Vector(615,515),"Basic Engine Demo")
        { 
        }

        public override void OnDraw()
        {
            
        }

        public override void OnLoad()
        {
            BackgroundColor = Color.Black;

            //Player = new Sprite2D(new Vector(10,10),new Vector(11,16),"Player/Right","Player");

            for(int i =0; i < Map.GetLength(0); i++)
            {
                for(int j = 0; j < Map.GetLength(1); j++)
                {
                    if (Map[i,j] == "g")
                    {
                        new Sprite2D(new Vector(i *16, j*16), new Vector(16, 16), "Tiles/Grass", "Ground");
                    }
                }
            }
        }
        int time = 0;
        public override void OnUpdate()
        {
            if(time > 400)
            {
                //Player.DestroySelf();
            }
            time++;
        }
    }
}
