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
        public delegate bool CheckRenderDistance(int x,int y);

        private List<Vector> ObjPosition;
        private List<string> ObjTag;
        int nrOfObj;
        
        public MapObjHandler()
        {
            ObjPosition = new List<Vector>();
            ObjTag = new List<string>();
            nrOfObj = 0;
        }
        public void AddObjPositions(Vector position,string Tag)
        {
            ObjPosition.Add(position);
            ObjTag.Add(Tag);
            nrOfObj++;
        }
        public void MapBuilder(Vector position, string gridDesignaiton)
        {
            if(gridDesignaiton == "g" && Engine.CheckObjByPos(position,"ground"))
            {
                new Sprite2D(new Vector(position.X,position.Y), new Vector(36, 36), "Tiles/Grass", "Ground");
            }
            if (gridDesignaiton == "w" && Engine.CheckObjByPos(position, "water"))
            {
                new Sprite2D(new Vector(position.X, position.Y), new Vector(36, 36), "Tiles/Water", "Water");
            }
            if (gridDesignaiton == "gh" && Engine.CheckObjByPos(position, "ground"))
            {
                ObjPosition.Add(new Vector(position.X,position.Y));
                ObjTag.Add("gh");
                nrOfObj++;
                new Sprite2D(new Vector(position.X, position.Y), new Vector(36, 36), "Tiles/Grass", "Ground");
            }

        }
        public void BuildOtherMapObj(CheckRenderDistance check)
        {
            for(int i = 0; i < ObjPosition.Count; i++)
            {
                if (ObjTag[i].ToLower() == "gh" && Engine.CheckObjByPos(ObjPosition[i],"house") && check((int)ObjPosition[i].X, (int)ObjPosition[i].Y))
                {
                    new Sprite2D(new Vector(ObjPosition[i].X, ObjPosition[i].Y), new Vector(51, 80), "Houses/House", "House");
                }
            }
        }

    }
}
