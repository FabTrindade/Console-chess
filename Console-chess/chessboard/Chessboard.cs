
using chessboard;

namespace chessboard
{
    class Chessboard
    {
        public int rows { get; set; }
        public int columns { get; set; }

        private Piece[,] pieces;

        public Chessboard(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.pieces = new Piece [rows, columns];
        }

        public Piece piece (int row, int col)
        {
            return pieces[row, col];
        }

        public void putPiece(Piece p, Position pos)
        {
            pieces[pos.row, pos.col] = p;
            p.position = pos;
        }
    }
}
