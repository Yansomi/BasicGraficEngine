using BasicGraficEngine.GameEngine;
using BasicGraficEngine.MapFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGraficEngine
{
    internal class MapHandler
    {
        public List<List<MapGrid>> mapGridList;
        private GridData gridData;
        public Vector playerVector { get; set; }

        public MapHandler(Vector playerVector) 
        {
            mapGridList = new List<List<MapGrid>> ();
            GridData gridData = new GridData();
            mapGridList = gridData.GetAsMapGrid();
            this.playerVector = playerVector;
        }
        public void AddGrid(List<MapGrid> mapGridList) 
        {
            this.mapGridList.Add(mapGridList);
        }
        public void LoadMap()
        {
            int nrOfGrids = 0;
            int gridstartX = 0;
            int gridstartY = 0;
            for (int y = 0; y < mapGridList.Count; y++)
            {
                gridstartY = y * 252;
                nrOfGrids = 0;
                foreach (MapGrid Map in mapGridList[y])
                {
                    gridstartX = nrOfGrids * 252;
                    for (int i = 0; i < Map.getGrid().GetLength(0); i++)
                    {
                        for (int j = 0; j < Map.getGrid().GetLength(1); j++)
                        {
                            if (Map.getGrid()[i, j] == "g" && CheckRenderDistance(j * 36 + gridstartX, i * 36 + gridstartY))
                            {
                                new Sprite2D(new Vector(j * 36 + gridstartX, i * 36 + gridstartY), new Vector(36, 36), "Tiles/Grass", "Ground");
                            }
                            if (Map.getGrid()[i, j] == "w" && CheckRenderDistance(j * 36 + gridstartX, i * 36 + gridstartY))
                            {
                                new Sprite2D(new Vector(j * 36 + gridstartX, i * 36 + gridstartY), new Vector(36, 36), "Tiles/Water", "Water");
                            }
                            //if (Map.getGrid()[i, j] == "h")
                            //{
                            //    new Sprite2D(new Vector(j * 36 + gridstartX, i * 36 + gridstartY), new Vector(36, 36), "Houses/House", "House");
                            //}
                            //if (Map.getGrid()[i, j] == "t")
                            //{
                            //    new Sprite2D(new Vector(j * 36 + gridstartX, i * 36 + gridstartY), new Vector(36, 36), "Trees/TreeGrass", "Tree");
                            //}
                        }
                    }
                    nrOfGrids++;
                }
            }
        }
        public void UpdateMap()
        {
            Vector Pos = new Vector();
            int nrOfGrids = 0;
            int gridstartX = 0;
            int gridstartY = 0;
            for (int y = 0; y < mapGridList.Count; y++)
            {
                gridstartY = y * 252;
                nrOfGrids = 0;
                foreach (MapGrid Map in mapGridList[y])
                {
                    gridstartX = nrOfGrids * 252;
                    for (int i = 0; i < Map.getGrid().GetLength(0); i++)
                    {
                        for (int j = 0; j < Map.getGrid().GetLength(1); j++)
                        {
                            Pos.X = j * 36 + gridstartX;
                            Pos.Y = i * 36 + gridstartY;
                            if (Map.getGrid()[i, j] == "g" && CheckRenderDistance(j * 36 + gridstartX, i * 36 + gridstartY) && Engine.CheckObjByPos(Pos))
                            {
                                new Sprite2D(new Vector(j * 36 + gridstartX, i * 36 + gridstartY), new Vector(36, 36), "Tiles/Grass", "Ground");
                            }
                            if (Map.getGrid()[i, j] == "w" && CheckRenderDistance(j * 36 + gridstartX, i * 36 + gridstartY) && Engine.CheckObjByPos(Pos))
                            {
                                new Sprite2D(new Vector(j * 36 + gridstartX, i * 36 + gridstartY), new Vector(36, 36), "Tiles/Water", "Water");
                            }
                            //if (Map.getGrid()[i, j] == "h")
                            //{
                            //    new Sprite2D(new Vector(j * 36 + gridstartX, i * 36 + gridstartY), new Vector(36, 36), "Houses/House", "House");
                            //}
                            //if (Map.getGrid()[i, j] == "t")
                            //{
                            //    new Sprite2D(new Vector(j * 36 + gridstartX, i * 36 + gridstartY), new Vector(36, 36), "Trees/TreeGrass", "Tree");
                            //}
                        }
                    }
                    nrOfGrids++;
                }
            }
            for (int i = 0; i < Engine.AllSprites.Count; i++)
            {
                if (!CheckRenderDistance((int)Engine.AllSprites[i].Position.X, (int)Engine.AllSprites[i].Position.Y))
                {
                    Engine.AllSprites.RemoveAt(i);
                    i--;
                    Log.Info("sprite removed");
                }
            }
        }
        private bool CheckRenderDistance(int X, int Y)
        {
            int XDif = X - (int)playerVector.X;
            int YDif = Y - (int)playerVector.Y;
            if(XDif < 504 && XDif > -504 && YDif < 504 && YDif > -504)
            {
                return true;
            }
            return false;
        }
    }
}
