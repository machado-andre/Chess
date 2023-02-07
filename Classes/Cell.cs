using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    class Cell
    {
        private int positionX;
        private int positionY;
        private bool isOccupied;
        private bool isLegalMove;
        private Piece piece;

        public Cell(int x, int y)
        {
            setPositionX(x);
            setPositionY(y);
        }

        public int getPositionX()
        {
            return positionX;
        }

        public int getPositionY()
        {
            return positionY;
        }

        public void setPositionX(int x)
        {
            positionX = x;
        }

        public void setPositionY(int y)
        {
            positionY = y;
        }

        public void setIsLegalMove(bool cond)
        {
            isLegalMove = cond;
        }

        public bool getIsLegalMove()
        {
            return isLegalMove;
        }

        public void setIsOccupied(bool cond)
        {
            isOccupied = cond;
        }

        public bool getIsOcuppied()
        {
            return isOccupied;
        }

        public void setPiece(Piece piece)
        {
            this.piece = piece;
            setIsOccupied(true);
        }

        public Piece getPiece()
        {
            return piece;
        }
    }
}
