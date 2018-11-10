using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEscapeProject
{
    class Character : MatrixObject
    {
        private String name;
        private int life;

        public Character(String name, int life, int value, int y, int x, string simbol) : base(value, y, x, simbol)
        {
            this.name = name;
            this.life = life;
        }

        public String getName() {
            return this.name;
        }

        public int getLife() {
            return this.life;
        }

        public void setName(String name) {
            this.name = name;
        }
        public void setLife(int life) {
            this.life = life;
        }

    }
}
