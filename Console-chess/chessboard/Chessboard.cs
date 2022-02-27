
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

        public Piece piece(Position pos)
        {
            return pieces[pos.row, pos.col];
        }


        public bool hasPiece (Position pos)
        {
            positionValidate(pos);

            return piece(pos) != null;
        }

        public void putPiece(Piece p, Position pos)
        {
            if (hasPiece(pos))
            {
                throw new ChessboradExceptions("There is already a piece in this position!");
            }
            pieces[pos.row, pos.col] = p;
            p.position = pos;
        }

        public bool validPos (Position pos)
        {
            if ((pos.row < 0 ) || (pos.row >=  rows) || (pos.col < 0) || (pos.col >= columns))
            {
                return false;
            }
            return true;
        }

        public void positionValidate (Position pos)
        {
            if (!validPos(pos))
            {
                throw new ChessboradExceptions("Invalid Pisition!");
            }
        }
    }
}
