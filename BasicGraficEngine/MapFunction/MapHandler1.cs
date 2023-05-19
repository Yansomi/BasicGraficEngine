﻿using BasicGraficEngine.GameEngine;
using BasicGraficEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGraficEngine.MapFunction
{
    public class MapHandler1
    {
        public List<List<MapGrid>> mapGridList;
        private GridData gridData;

        public MapHandler1()
        {
            mapGridList = new List<List<MapGrid>>();
            GridData gridData = new GridData();
            mapGridList.Add(gridData.GetAsMapGrid());
            mapGridList.Add(gridData.GetAsMapGrid());
        }
        public void AddGrid(List<MapGrid> mapGridList)
        {
            this.mapGridList.Add(mapGridList);
        }
        public void LoadMap(Dictionary<string, Sprite2D> mapSprites)
        {
            int nrOfGrids = 0;
            int gridstartX = 0;
            int gridstartY = 0;
            for (int y = 0; y < mapGridList.Count; y++)
            {
                gridstartY = y * 252;
                nrOfGrids = 0;
                Log.Info($"Y axist render level: {gridstartY}");
                foreach (MapGrid Map in mapGridList[y])
                {
                    gridstartX = nrOfGrids * 252;
                    for (int i = 0; i < Map.getGrid().GetLength(0); i++)
                    {
                        for (int j = 0; j < Map.getGrid().GetLength(1); j++)
                        {
                            mapSprites[Map.getGrid()[i, j]].Position = j * 36 + gridstartX, i * 36 + gridstartY;
                            mapSprites[Map.getGrid()[i, j]].Scale = new Vector(36, 36);
                        }
                    }
                    nrOfGrids++;
                }
            }
        }
    }
}

