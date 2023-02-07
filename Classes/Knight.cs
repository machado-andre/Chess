using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    class Knight : Piece
    {
        public Knight(Team color, Image img, byte number) : base(color, img, number)
        {

        }

        public override void findLegalMoves(Cell curCell, Cell[,] cellGrid, Guna2Button[,] btnGrid)
        {
            int posX = curCell.getPositionX();
            int posY = curCell.getPositionY();
            int M = 0;
            if (posX - 1 >= 0)
            {
                if (posY + 2 <= 7)
                {
                    cellGrid[posX - 1, posY + 2].setIsLegalMove(true);
                    checkMove(posX, posY, cellGrid, btnGrid, M, -1, 2);
                }
                if (posY - 2 >= 0)
                {
                    cellGrid[posX - 1, posY - 2].setIsLegalMove(true);
                    checkMove(posX, posY, cellGrid, btnGrid, M, -1, -2);
                }
                if (posX - 2 >= 0)
                {
                    if (posY + 1 <= 7)
                    {
                        cellGrid[posX - 2, posY + 1].setIsLegalMove(true);
                        checkMove(posX, posY, cellGrid, btnGrid, M, -2, 1);
                    }
                    if (posY - 1 >= 0)
                    {
                        cellGrid[posX - 2, posY - 1].setIsLegalMove(true);
                        checkMove(posX, posY, cellGrid, btnGrid, M, -2, -1);
                    }
                }
            }
            if (posX + 1 <=7)
            {
                if (posY + 2 <= 7)
                {
                    cellGrid[posX + 1, posY + 2].setIsLegalMove(true);
                    checkMove(posX, posY, cellGrid, btnGrid, M, 1, 2);
                }
                if (posY - 2 >= 0)
                {
                    cellGrid[posX + 1, posY - 2].setIsLegalMove(true);
                    checkMove(posX, posY, cellGrid, btnGrid, M, 1, -2);
                }

                if (posX + 2 <= 7)
                {
                    if (posY + 1 <= 7)
                    {
                        cellGrid[posX + 2, posY + 1].setIsLegalMove(true);
                        checkMove(posX, posY, cellGrid, btnGrid, M, 2, 1);
                    }
                    if (posY - 1 >= 0)
                    {
                        cellGrid[posX + 2, posY - 1].setIsLegalMove(true);
                        checkMove(posX, posY, cellGrid, btnGrid, M, 2, -1);
                    }
                }
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
                cellGrid[posX + i, posY + j].setIsLegalMove(false);
                return true;
            }
            return false;
        }

    }
}
