using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BasicGraficEngine.GameEngine
{
    public class Shape2D
    {
        public Vector Position = null;
        public Vector Scale = null;
        public string Tag = "";

        public Shape2D(Vector position, Vector scale, string tag)
        {
            this.Position = position;
            this.Scale = scale;
            this.Tag = tag;

            Log.Info($"[SHAPE2D]({Tag}) - Has been registerd!");
            Engine.RegisterShape(this);
        }

        public void DestroySelf()
        {
            Log.Info($"[SHAPE2D]({Tag}) - Has been Destroyed!");
            Engine.UnRegisterShape(this);
        }
    }
}
