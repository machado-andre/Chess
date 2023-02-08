using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    class King : Piece
    {
        public King(Team color, Image img, byte number) : base(color, img, number)
        {

        }

        public override void findLegalMoves(Cell curCell, Cell[,] cellGrid, Guna2Button[,] btnGrid)
        {
            int posX = curCell.getPositionX();
            int posY = curCell.getPositionY();
            int M = 0;

            if(posX - 1 >= 0)
            {
                cellGrid[posX - 1, posY].setIsLegalMove(true);
                checkMove(posX, posY, cellGrid, btnGrid, M, -1, 0);
                if (posY - 1 >= 0)
                {
                    cellGrid[posX - 1, posY - 1].setIsLegalMove(true);
                    checkMove(posX, posY, cellGrid, btnGrid, M, -1, -1);
                }
                if(posY + 1 <= 7)
                {
                    cellGrid[posX - 1, posY + 1].setIsLegalMove(true);
                    checkMove(posX, posY, cellGrid, btnGrid, M, -1, 1);
                }
            }
            if(posX + 1 <= 7)
            {
                cellGrid[posX + 1, posY].setIsLegalMove(true);
                checkMove(posX, posY, cellGrid, btnGrid, M, 1, 0);
                if (posY - 1 >= 0)
                {
                    cellGrid[posX + 1, posY - 1].setIsLegalMove(true);
                    checkMove(posX, posY, cellGrid, btnGrid, M, 1, -1);
                }
                if (posY + 1 <= 7)
                {
                    cellGrid[posX + 1, posY + 1].setIsLegalMove(true);
                    checkMove(posX, posY, cellGrid, btnGrid, M, 1, 1);
                }
            }

            if (posY - 1 >= 0)
            {
                cellGrid[posX, posY - 1].setIsLegalMove(true);
                checkMove(posX, posY, cellGrid, btnGrid, M, 0, -1);
            }
            if(posY + 1 <= 7)
            {
                cellGrid[posX, posY + 1].setIsLegalMove(true);
                checkMove(posX, posY, cellGrid, btnGrid, M, 0, 1);
            }

        }
        public bool checkMove(int posX, int posY, Cell[,] cellGrid, Guna2Button[,] btnGrid, int M, int i, int j)
        {
            Team opponent = getOppTeam();
            //if cell is occupied and is the first opponent encountered you may choose to take 
            if (cellGrid[posX + i, posY + j].getIsOcuppied() && cellGrid[posX + i, posY + j].getPiece().getColor() == opponent)
            {
                if (M == 0)
                {
                    cellGrid[posX + i, posY + j].setIsLegalMove(true);
                    btnGrid[posX + i, posY + j].FillColor = Color.GreenYellow;
                    return true;
                }
            }
            else if (cellGrid[posX + i, posY + j].getIsOcuppied())
            {
                cellGrid[posX + i , posY + j].setIsLegalMove(false);
                return true;
            }
            return false;
        }

        public override Team checkForCheck(Cell curCell, Cell[,] cellGrid, Guna2Button[,] btnGrid)
        {
            throw new NotImplementedException();
        }
    }

}
