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
        public List<MapGrid> mapGridList;
        private GridData gridData;

        public MapHandler() 
        {
            mapGridList = new List<MapGrid>();
            GridData gridData = new GridData();
            mapGridList = gridData.GetAsMapGrid();
        }
        public void AddGrid(List<MapGrid> mapGridList) 
        {
            this.mapGridList = mapGridList;
        }
        public void LoadMap()
        {
            int nrOfGrids = 0;
            int gridstart = 0;
            foreach (MapGrid Map in mapGridList)
            {
                gridstart = nrOfGrids * 252;
                for (int i = 0; i < Map.getGrid().GetLength(0); i++)
                {
                    for (int j = 0; j < Map.getGrid().GetLength(1); j++)
                    {
                        if (Map.getGrid()[i, j] == "g")
                        {
                            new Sprite2D(new Vector(j * 36 + gridstart, i * 36), new Vector(36, 36), "Tiles/Grass", "Ground");
                        }
                        if (Map.getGrid()[i, j] == "w")
                        {
                            new Sprite2D(new Vector(j  * 36 + gridstart, i * 36), new Vector(36, 36), "Tiles/Water", "Water");
                        }
                    }
                }
                nrOfGrids++;
            }
        }
    }
}
