using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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
        string[,] Map =
        {
             {"w","w","w","w","w","w","w"},
             {"w","g","g","g","g","g","w"},
             {"w","g","g","g","g","g","w"},
             {"w","g","g","g","g","g","w"},
             {"w","g","g","g","g","g","w"},
             {"w","g","g","g","g","g","w"},
             {"w","w","w","w","w","w","w"},
        };
        string[,] Buildings =
       {
             {"w","w","w","w","w","w","w"},
             {"w","g","g","g","g","g","w"},
             {"w","g","g","g","g","g","w"},
             {"w","g","g","b","g","g","w"},
             {"w","g","g","g","g","g","w"},
             {"w","g","g","g","g","g","w"},
             {"w","w","w","w","w","w","w"},
        };
        public DemoGame() : base(new Vector(720,720),"Basic Engine Demo")
        { 
        }

        public override void OnDraw()
        {
            
        }

        public override void OnLoad()
        {
            BackgroundColor = Color.Black;

            

            for(int i =0; i < Map.GetLength(0); i++)
            {
                for(int j = 0; j < Map.GetLength(1); j++)
                {
                    if (Map[i,j] == "g")
                    {
                        new Sprite2D(new Vector(j *36, i*36), new Vector(36,36), "Tiles/Grass", "Ground");
                    }
                    if (Map[i,j] == "w")
                    {
                        new Sprite2D(new Vector(j * 36, i * 36), new Vector(36, 36), "Tiles/Water", "Water");
                    }
                }
            }
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    if (Buildings[i,j] == "b")
                    {
                        new Sprite2D(new Vector(j * 36, i * 36), new Vector(51, 80), "Houses/House", "House");
                    }
                }
            }
            Player = new Sprite2D(new Vector(40, 40), new Vector(11, 16), "Player/Right", "Player");
            Tags.Add("Water");
            Tags.Add("House");
        }
        int times = 0;
        public override void OnUpdate()
        {
            if (Up) { Player.Position.Y -=1f; }
            if(Down) { Player.Position.Y +=1f; }
            if (Left) { Player.Position.X -= 1f; } 
            if (Right) { Player.Position.X += 1f; }

            Player.CollitionStop(Player.IsColliding(Tags));
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
    }
}
