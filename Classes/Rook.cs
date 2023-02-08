using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    class Rook : Piece
    {
        public Rook(Team color, Image img, byte number) : base(color, img, number)
        {

        }

        public override void findLegalMoves(Cell curCell, Cell[,] cellGrid, Guna2Button[,] btnGrid)
        {
            int posX = curCell.getPositionX();
            int posY = curCell.getPositionY();
            int L = 0, R = 0, U = 0, D = 0;
            int i = -1, j = 1;

            //Horizontal
            while (posX + i >= 0)
            {
                cellGrid[posX + i, posY].setIsLegalMove(true);
                if (checkHorizontalMove(i, posX, posY, cellGrid, btnGrid, L))
                {
                    break;
                }
                i--;
            }
            while(posX + j <= 7)
            {
                cellGrid[posX + j, posY].setIsLegalMove(true);
                if (checkHorizontalMove(j, posX, posY, cellGrid, btnGrid,R))
                {
                    break;
                }
                j++;
            }
            i = -1; j = 1;
            //Vertical
            while(posY + i >= 0)
            {
                cellGrid[posX, posY + i].setIsLegalMove(true);
                if (checkVerticalMove(i, posX, posY, cellGrid, btnGrid, D))
                {
                    break;
                }
                i--;
            }

            while(posY + j <= 7)
            {
                cellGrid[posX, posY + j].setIsLegalMove(true);
                if (checkVerticalMove(j, posX, posY, cellGrid, btnGrid, U))
                {
                    break;
                }
                j++;
            }
        }

        public bool checkHorizontalMove(int i, int posX, int posY, Cell[,] cellGrid, Guna2Button[,] btnGrid, int Dir)
        {
            Team opponent = getOppTeam();
            //if cell is occupied and is the first opponent encountered you may choose to take 
            if (cellGrid[posX + i, posY].getIsOcuppied() && cellGrid[posX + i, posY].getPiece().getColor() == opponent && Dir ==0)
            {
                cellGrid[posX + i, posY].setIsLegalMove(true);
                btnGrid[posX + i, posY].FillColor = Color.GreenYellow;
                return true;
            }
            else if(cellGrid[posX + i, posY].getIsOcuppied())
            {
                cellGrid[posX + i, posY].setIsLegalMove(false);
                return true;
            }
            return false;
        }

        public bool checkVerticalMove(int i, int posX, int posY, Cell[,] cellGrid, Guna2Button[,] btnGrid, int Dir)
        {
            Team opponent = getOppTeam();
            //if cell is occupied and is the first opponent encountered you may choose to take 
            if (cellGrid[posX, posY + i].getIsOcuppied() && cellGrid[posX, posY + i].getPiece().getColor() == opponent && Dir == 0)
            {
                cellGrid[posX, posY + i].setIsLegalMove(true);
                btnGrid[posX, posY + i].FillColor = Color.GreenYellow;
                return true;
            }
            else if(cellGrid[posX, posY + i].getIsOcuppied())
            {
                cellGrid[posX, posY + i].setIsLegalMove(false);
                return true;
            }
            return false;
        }

        public override Team checkForCheck(Cell curCell, Cell[,] cellGrid, Guna2Button[,] btnGrid)
        {
            return getColor();
        }
    }
}
