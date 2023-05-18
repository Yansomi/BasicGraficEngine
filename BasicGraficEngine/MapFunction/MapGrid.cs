using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGraficEngine.MapFunction
{
    public class MapGrid
    {
        string[,] Grid { get; set; }

        public MapGrid(string[,] grid) 
        {
            this.Grid = grid;
        }
        public string[,] getGrid()
        {
            return this.Grid;
        }
    }
}
