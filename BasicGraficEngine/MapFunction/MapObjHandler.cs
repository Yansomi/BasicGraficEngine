using BasicGraficEngine.GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGraficEngine.MapFunction
{
    internal class MapObjHandler
    {
        public List<Vector> ObjPosition { get; set; }
        
        public MapObjHandler()
        {
            ObjPosition = new List<Vector>();
        }
        public void AddObjPositions(Vector obj)
        {
            ObjPosition.Add(obj);
        }
        public Sprite2D BuildHouse(int i)
        {
            return new Sprite2D(ObjPosition[i], new Vector(51, 80), "Houses/House", "House");
        }

    }
}
