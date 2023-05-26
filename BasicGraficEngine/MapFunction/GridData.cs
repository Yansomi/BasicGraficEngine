using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGraficEngine.MapFunction
{
    internal class GridData
    {
        public List<string[,]> Data;
        int NrOfYGrids;

        public GridData()
        {
            NrOfYGrids = 3;
            Data = new List<string[,]>();
            string[,] grid1 =
            {
             {"w","w","w","g","w","w","w"},
             {"w","g","g","g","g","g","w"},
             {"w","g","g","g","g","g","w"},
             {"w","g","g","gh","g","g","g"},
             {"w","g","g","g","g","g","w"},
             {"w","g","g","g","g","g","w"},
             {"w","w","w","g","w","w","w"},
            };
            string[,] grid2 =
{
             {"w","w","w","g","w","w","w"},
             {"w","g","g","g","g","g","w"},
             {"w","g","g","g","g","g","w"},
             {"g","g","g","g","g","g","g"},
             {"w","g","g","g","g","g","w"},
             {"w","g","g","g","g","g","w"},
             {"w","w","w","g","w","w","w"},
            };
            string[,] grid3 =
{
                         {"w","w","w","g","w","w","w"},
                         {"w","g","g","g","g","g","w"},
                         {"w","g","g","g","g","g","w"},
                         {"g","g","g","gt","g","g","g"},
                         {"w","g","g","g","g","g","w"},
                         {"w","g","g","g","g","g","w"},
                         {"w","w","w","g","w","w","w"},
                        };
            string[,] grid4 =
{
                         {"w","w","w","g","w","w","w"},
                         {"w","g","g","g","g","g","w"},
                         {"w","g","g","g","g","g","w"},
                         {"g","g","g","g","g","g","g"},
                         {"w","g","g","g","g","g","w"},
                         {"w","g","g","g","g","g","w"},
                         {"w","w","w","g","w","w","w"},
                        };
            //            string[,] grid5 =
            //{
            //             {"w","w","w","w","w","w","W"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","w","w","w","w","w","W"},
            //            };
            //            string[,] grid6 =
            //{
            //             {"w","w","w","w","w","w","W"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","w","w","w","w","w","W"},
            //            };
            //            string[,] grid7 
            //            =
            //{               
            //             {"w","w","w","w","w","w","W"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","w","w","w","w","w","W"},
            //            };
            //            string[,] grid8 =
            //{
            //             {"w","w","w","w","w","w","W"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","w","w","w","w","w","W"},
            //            };
            Data.Add(grid1);
            Data.Add(grid2);
            Data.Add(grid3);
            Data.Add(grid4);
            //Data.Add(grid5);
            //Data.Add(grid6);
            //Data.Add(grid7);
            //Data.Add(grid8);

        }
        public List<List<MapGrid>> GetAsMapGrid()
        {
            List<List<MapGrid>> DataList = new List<List<MapGrid>>();
            for (int i = 0; i < NrOfYGrids; i++)
            {
                DataList.Add(new List<MapGrid>());

                foreach (string[,] data in Data)
                {
                    DataList[i].Add(new MapGrid(data));
                }
            }
            return DataList;
        }
    }
}
