using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeEscapeProject
{
    class MatrixObject
    {
        private int value;
        private int y;
        private int x;
        private String simbol;

        public MatrixObject(int value, int y, int x, String simbol) {
            this.value = value;
            this.y = y;
            this.x = x;
            this.simbol = simbol;
        }

        public int getValue() {
            return this.value;
        }

        public int getY() {
            return this.y;       
        }

        public int getX() {
            return this.x;
        }

        public String getSimbol() {
            return this.simbol;
        }

        public void setValue(int value) {
            this.value = value;
        }

        public void setY(int y) {
            this.y = y;
        }
        public void setX(int x) {
            this.x = x;
        }
        public void setSimbol(String simbol) {
            this.simbol = simbol;
        }

    }
}
