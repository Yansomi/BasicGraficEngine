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

        public GridData()
        {
            Data = new List<string[,]>();
            string[,] grid1 =
            {
             {"w","w","w","w","w","w","w"},
             {"w","g","g","g","g","g","w"},
             {"w","g","g","g","g","g","w"},
             {"w","g","g","g","g","g","g"},
             {"w","g","g","h","g","g","w"},
             {"w","g","g","g","g","g","w"},
             {"w","w","w","w","w","w","w"},
            };
            string[,] grid2 =
{
             {"w","w","w","w","w","w","w"},
             {"w","g","g","g","g","g","w"},
             {"w","g","g","g","g","g","w"},
             {"g","g","g","g","t","g","w"},
             {"w","g","g","g","g","g","w"},
             {"w","g","g","g","g","g","w"},
             {"w","w","w","w","w","w","w"},
            };
            string[,] grid3 =
{
                         {"w","w","w","w","w","w","w"},
                         {"w","g","g","g","g","g","w"},
                         {"w","g","g","g","g","g","w"},
                         {"w","g","g","g","g","g","w"},
                         {"w","g","g","g","g","g","w"},
                         {"w","g","g","g","g","g","w"},
                         {"w","w","w","w","w","w","w"},
                        };
            //            string[,] grid4 =
            //{
            //             {"w","w","w","w","w","w","W"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","g","g","g","g","g","w"},
            //             {"w","w","w","w","w","w","W"},
            //            };
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
            //Data.Add(grid4);
            //Data.Add(grid5);
            //Data.Add(grid6);
            //Data.Add(grid7);
            //Data.Add(grid8);

        }
        public List<MapGrid> GetAsMapGrid()
        {
            List<MapGrid> DataList = new List<MapGrid>();
            foreach (string[,] data in Data)
            {
                DataList.Add(new MapGrid(data));
            }
            return DataList;
        }
    }
}
