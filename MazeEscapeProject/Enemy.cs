using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEscapeProject
{
    class Enemy : MatrixObject
    {
        public Enemy(int value, int y, int x, string simbol) : base(value, y, x, simbol)
        {
        }
    }
}
