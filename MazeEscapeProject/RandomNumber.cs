using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEscapeProject
{
    class RandomNumber
    {
        

        public int generateRandomX(int board) {
            Random random = new Random((int)DateTime.Now.Ticks);
           // var seed = Environment.TickCount;
            //var random = new Random(seed);
            switch (board) {
                case 1:
                    return random.Next(0, 5);        
                case 2:
                    return random.Next(0 , 6);
                case 3:
                    return random.Next(0, 8);
            }
            return 0;
        }

        public int generateRandomY(int board)
        {
            Random random = new Random((int)DateTime.Now.Ticks);

            switch (board)
            {
                case 1:
                    return random.Next(0,4);
                case 2:
                    return random.Next(0, 5);
                case 3:
                    return random.Next(0, 7);
            }
            return 0;
        }

    }
}
