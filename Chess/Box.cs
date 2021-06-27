using System;

namespace Chess
{
    public class Box
    {

        public int row;
        public int col;
        private int originalRow;
        private int originalCol;
        private string box;

        public Box(string s)
        {
            box = s;
            row = getRow(s);
            col = getCol(s);
            originalRow = row;
            originalCol = col;
        }
        public void reset(string s)
        {
            row = getRow(s);
            col = getCol(s);
        }
        public void reset()
        {
            row = originalRow;
            col = originalCol;
        }
        public string top()
        {
            if (row + 1 > 7)
            {
                return null;
            }
            else
            {
                return getBox(row + 1, col);
            }
        }
        public string doubleTop()
        {
            //If condition isn't necessary becuase this function will not be called when row is greater than 1 index(exactly 2)
            //But use it for good practice
            if (row + 1 > 7)
            {
                return null;
            }
            else
            {
                return getBox(row + 2, col);
            }
        }
        public string top(int i)
        {
            if (row + i > 7)
            {
                return null;
            }
            else
            {
                return getBox(row + i, col);
            }
        }
        public string bottom()
        {
            if (row - 1 < 0)
            {
                return null;
            }
            else
            {
                return getBox(row - 1, col);
            }
        }
        public string bottom(int i)
        {
            if (row - i < 0)
            {
                return null;
            }
            else
            {
                return getBox(row - i, col);
            }
        }
        public string left()
        {
            if (col - 1 < 0)
            {
                return null;
            }
            else
            {
                return getBox(row, col - 1);
            }
        }
        public string left(int i)
        {
            if (col - i < 0)
            {
                return null;
            }
            else
            {
                return getBox(row, col - i);
            }
        }
        public string right()
        {
            if (col + 1 > 7)
            {
                return null;
            }
            else
            {
                return getBox(row, col + 1);
            }
        }
        public string right(int i)
        {
            if (col + i > 7)
            {
                return null;
            }
            else
            {
                return getBox(row, col + i);
            }
        }
        public string topLeft()
        {
            string box = this.top();
            if (box == null)
            {
                return null;
            }
            reset(box);

            box = this.left();
            reset();
            return box;
        }
        public string topRight()
        {
            string box = this.top();

            if (box == null)
            {
                return null;
            }
            reset(box);

            box = this.right();
            reset();
            return box;
        }
        public string bottomLeft()
        {
            string box = this.bottom();
            if (box == null)
            {
                return null;
            }
            reset(box);
            box = this.left();

            reset();
            return box;
        }
        public string bottomRight()
        {
            string box = this.bottom();
            if (box == null)
            {
                return null;
            }
            reset(box);
            box = this.right();

            reset();
            return box;
        }
        public string getBox(int r, int c)
        {
            String box = "";

            switch (c)
            {
                case 0:
                    box += "a";
                    break;
                case 1:
                    box += "b";
                    break;
                case 2:
                    box += "c";
                    break;
                case 3:
                    box += "d";
                    break;
                case 4:
                    box += "e";
                    break;
                case 5:
                    box += "f";
                    break;
                case 6:
                    box += "g";
                    break;
                case 7:
                    box += "h";
                    break;
            }

            switch (r)
            {
                case 0:
                    box += "1";
                    break;
                case 1:
                    box += "2";
                    break;
                case 2:
                    box += "3";
                    break;
                case 3:
                    box += "4";
                    break;
                case 4:
                    box += "5";
                    break;
                case 5:
                    box += "6";
                    break;
                case 6:
                    box += "7";
                    break;
                case 7:
                    box += "8";
                    break;

            }
            return box;
        }
        public int getRow()
        {
            return getRow(box);
        }
        private int getCol()
        {
            return getCol(box);
        }
        private int getRow(string n)
        {
            return n[1] - 48 - 1;
        }
        private int getCol(string n)
        {
            int col = 0;
            switch (n[0])
            {
                case 'a':
                    col = 0;
                    break;
                case 'b':
                    col = 1;
                    break;
                case 'c':
                    col = 2;
                    break;
                case 'd':
                    col = 3;
                    break;
                case 'e':
                    col = 4;
                    break;
                case 'f':
                    col = 5;
                    break;
                case 'g':
                    col = 6;
                    break;
                case 'h':
                    col = 7;
                    break;

            }

            return col;
        }

    }
}
