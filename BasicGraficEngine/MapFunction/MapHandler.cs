using BasicGraficEngine.GameEngine;
using BasicGraficEngine.MapFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicGraficEngine
{
    internal class MapHandler
    {
        public List<List<MapGrid>> mapGridList;
        private GridData gridData;
        Thread UpdateMapThread;
        public Vector playerVector { get; set; }

        public MapObjHandler mapObjHandler;

        public MapHandler(Vector playerVector) 
        {
            mapGridList = new List<List<MapGrid>> ();
            GridData gridData = new GridData();
            mapObjHandler = new MapObjHandler();
            mapGridList = gridData.GetAsMapGrid();
            this.playerVector = playerVector;
            UpdateMapThread = new Thread(MapUpdateLoop);
            UpdateMapThread.Start();
        }
        public void AddGrid(List<MapGrid> mapGridList) 
        {
            this.mapGridList.Add(mapGridList);
        }
        ~MapHandler()
        {
            UpdateMapThread.Abort();
        }
        public void UpdateMap()
        {
            Vector Pos = new Vector();
            int nrOfGrids = 0;
            int gridstartX = 0;
            int gridstartY = 0;
            int GridXYSize = 252;
            for (int y = 0; y < mapGridList.Count; y++)
            {
                gridstartY = y * GridXYSize;
                nrOfGrids = 0;
                foreach (MapGrid Map in mapGridList[y])
                {
                    gridstartX = nrOfGrids * GridXYSize;
                    for (int i = 0; i < Map.getGrid().GetLength(0); i++)
                    {
                        for (int j = 0; j < Map.getGrid().GetLength(1); j++)
                        {
                            Pos.X = j * 36 + gridstartX;
                            Pos.Y = i * 36 + gridstartY;

                            mapObjHandler.MapBuilder(Pos, Map.getGrid()[i, j],CheckRenderDistance);
                        }
                    }
                    nrOfGrids++;
                }
            }
            for (int i = 0; i < Engine.AllSprites.Count; i++)
            {
                if (!CheckRenderDistance((int)Engine.AllSprites[i].Position.X, (int)Engine.AllSprites[i].Position.Y))
                {
                    Log.Info($"sprite removed({Engine.AllSprites[i].Tag})");
                    Engine.AllSprites.RemoveAt(i);
                    i--;
                }
            }
                mapObjHandler.BuildOtherMapObj(CheckRenderDistance);

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
        void MapUpdateLoop()
        {
            while (UpdateMapThread.IsAlive)
            {
                this.UpdateMap();
                Thread.Sleep(1);
            }
        }
    }
}
