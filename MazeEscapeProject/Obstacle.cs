using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEscapeProject
{
    class Obstacle : MatrixObject
    {
        public Obstacle(int value, int y, int x, string simbol) : base(value, y, x, simbol)
        {
        }
    }
}
