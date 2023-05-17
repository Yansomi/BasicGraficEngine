using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGraficEngine.GameEngine
{
    public class Vector
    {
        public float X { get; set; } 
        public float Y { get; set; }

        public Vector()
        {
            X = Zero().X; 
            Y = Zero().Y;
        }
        public Vector(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Returns X & Y as 0
        /// </summary>
        /// <returns></returns>
        public static Vector Zero()
        {
            return new Vector(0,0);
        }
    }
}
