using System;
using System.Collections.Generic;
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
            Player = new Sprite2D(new Vector(40, 40), new Vector(11, 16), "Player/Right", "Player");
            
        }
        int times = 0;
        public override void OnUpdate()
        {
            if (Up) { Player.Position.Y -=1f; }
            if(Down) { Player.Position.Y +=1f; }
            if (Left) { Player.Position.X -= 1f; } 
            if (Right) { Player.Position.X += 1f; }
            
            if(Player.IsColliding("Water"))
            {
                Log.Info($"Collision {times}");
                times++;
            }

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
