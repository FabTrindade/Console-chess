using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chessboard
{
    class Position
    {
        public int row { get; set; }
        public int col { get; set; }

        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }


        public void definePosition (int row, int col)
        {
            this.row = row;
            this.col = col;
        }
        public override string ToString()
        {
            return row + "," + col;
        }
    }
}
