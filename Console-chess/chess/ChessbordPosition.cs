using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chessboard;

namespace chess
{
    class ChessbordPosition
    {
        public char col { get; set; }
        public int row { get; set; }

        public ChessbordPosition(char col, int row)
        {
            this.col = col;
            this.row = row;
        }

        public Position toPosition()
        {
            return new Position(8 - row, col - 'a');
        }

        public override string ToString()
        {
            return "" + col  + row;
        }
    }
}
