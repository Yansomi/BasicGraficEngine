using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace BasicGraficEngine.GameEngine
{
    class Canvas : Form
    {
        public Canvas()
        {
            this.DoubleBuffered = true;
        }
    }
    public abstract class Engine
    {
        private Vector ScreenSize = new Vector(512,512);
        private string Title;
        private Canvas Window = null;
        private Thread GameLoopThread = null;

        public static List<Shape2D> AllShapes = new List<Shape2D>();
        public static List<Sprite2D> AllSprites = new List<Sprite2D>();

        public Color BackgroundColor = Color.Black;

        public Vector CameraPosition = new Vector(360, 360);
        public float CameraAngle = 0f;
        public Engine(Vector ScreenSize,string Title = "Game") 
        {
            Log.Info("Game is Starting");
            this.ScreenSize = ScreenSize;
            this.Title = Title;
            Window = new Canvas();
            Window.Size = new Size((int)this.ScreenSize.X, (int)this.ScreenSize.Y);
            Window.Text = this.Title;
            Window.Paint += Renderer;
            Window.KeyDown += Window_KeyDown;
            Window.KeyUp += Window_KeyUp;
            Window.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Window.FormClosing += Window_FormClosing;

            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Priority = ThreadPriority.Highest;
            GameLoopThread.Start(); 

            Application.Run(Window);
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            GameLoopThread.Abort();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            GetKeyUp(e);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            GetKeyDown(e);
        }

        public static void RegisterShape(Shape2D shape)
        {
            AllShapes.Add(shape);
        }
        public static void UnRegisterShape(Shape2D shape)
        {
            AllShapes.Remove(shape);
        }
        public static void RegisterSprite(Sprite2D sprite)
        {
            AllSprites.Add(sprite);
        }
        public static void UnRegisterSprite(Sprite2D sprite)
        {
            AllSprites.Remove(sprite);
        }
        public static void UpdateSpriteWithTag(Bitmap sprite, string tag)
        {
            foreach(Sprite2D sprite2 in AllSprites)
            {
                if(sprite2.Tag == tag)
                {
                    sprite2.UpdateSpirte(sprite);
                }
            }
        }
        void GameLoop()
        {
            OnLoad();
            bool IsRunning = true;
            while(GameLoopThread.IsAlive)
            {
                try
                {
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                    OnUpdate();
                    if (!IsRunning)
                    {
                        Log.Warning("Window has been found... Resuming!");
                        IsRunning = true;
                    }
                    Thread.Sleep(1);
                }
                catch 
                {
                    Log.Error("Window has not been found... Waiting...");
                    IsRunning = false;
                }
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackgroundColor);
            g.TranslateTransform(CameraPosition.X, CameraPosition.Y);
            g.RotateTransform(CameraAngle);
            for(int i = 0; i < AllShapes.Count; i++)
            {
                g.FillRectangle(new SolidBrush(Color.Red), AllShapes[i].Position.X, AllShapes[i].Position.Y, AllShapes[i].Scale.X, AllShapes[i].Scale.Y);
            }

            for(int i =0; i < AllSprites.Count; i++)
            {
                g.DrawImage(AllSprites[i].Sprite, AllSprites[i].Position.X, AllSprites[i].Position.Y, AllSprites[i].Scale.X, AllSprites[i].Scale.Y);    
            }
            
        }
        public abstract void OnLoad();
        public abstract void OnUpdate();
        public abstract void OnDraw();
        public abstract void GetKeyDown(KeyEventArgs e);
        public abstract void GetKeyUp(KeyEventArgs e);
    }
}
