using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    class Queen : Piece
    {
        public Queen(Team color, Image img, byte number) : base(color, img, number)
        {

        }

        public override void findLegalMoves(Cell curCell, Cell[,] cellGrid, Guna2Button[,] btnGrid)
        {
            int posX = curCell.getPositionX();
            int posY = curCell.getPositionY();
            int M = 0;
            int i = -1;

            // esquerda
            while(posX + i >= 0)
            {
                cellGrid[posX + i, posY].setIsLegalMove(true);
                if (checkHorizontalMove(i, posX, posY, cellGrid, btnGrid, M))
                {
                    break;
                }
                i--;
            }
            // direita
            i = 1;
            while (posX + i <= 7)
            {
                cellGrid[posX + i, posY].setIsLegalMove(true);
                if (checkHorizontalMove(i, posX, posY, cellGrid, btnGrid, M))
                {
                    break;
                }
                i++;
            }
            //cima
            i = -1;
            while (posY + i >= 0)
            {
                cellGrid[posX, posY + i].setIsLegalMove(true);
                if (checkVerticalMove(posX, posY, cellGrid, btnGrid, M, i))
                {
                    break;
                }
                i--;
            }
            //baixo
            i = 1;
            while (posY + i <= 7)
            {
                cellGrid[posX, posY + i].setIsLegalMove(true);
                if(checkVerticalMove(posX, posY, cellGrid, btnGrid, M, i))
                {
                    break;
                }
                i++;
            }

            i = 1;
            while (posX + i <= 7 && posY + i <= 7)
            {
                cellGrid[posX + i, posY + i].setIsLegalMove(true);
                if (checkRightMove(i, posX, posY, cellGrid, btnGrid, M))
                {
                    break;
                }
                i++;
            }

            i = -1;
            while (posX + i >= 0 && posY + i >= 0)
            {
                cellGrid[posX + i, posY + i].setIsLegalMove(true);
                if (checkRightMove(i, posX, posY, cellGrid, btnGrid, M))
                {
                    break;
                }
                i--;
            }

            i = 1;
            while (posX + i <= 7 && posY - i >= 0)
            {
                cellGrid[posX + i, posY - i].setIsLegalMove(true);
                if (checkLeftMove(i, posX, posY, cellGrid, btnGrid, M))
                {
                    break;
                }
                i++;
            }

            i = -1;
            while (posX + i >= 0 && posY - i <= 7)
            {
                cellGrid[posX + i, posY - i].setIsLegalMove(true);
                if (checkLeftMove(i, posX, posY, cellGrid, btnGrid, M))
                {
                    break;
                }
                i--;
            }
        }


        public bool checkHorizontalMove(int i, int posX, int posY, Cell[,] cellGrid, Guna2Button[,] btnGrid, int Dir)
        {
            Team opponent = getOppTeam();
            //if cell is occupied and is the first opponent encountered you may choose to take 
            if (cellGrid[posX + i, posY].getIsOcuppied() && cellGrid[posX + i, posY].getPiece().getColor() == opponent)
            {
                if (Dir == 0)
                {
                    cellGrid[posX + i, posY].setIsLegalMove(true);
                    btnGrid[posX + i, posY].FillColor = Color.GreenYellow;
                    return true;
                }
            }
            else if (cellGrid[posX + i, posY].getIsOcuppied())
            {
                cellGrid[posX + i, posY].setIsLegalMove(false);
                return true;
            }
            return false;
        }

        public bool checkVerticalMove(int posX, int posY, Cell[,] cellGrid, Guna2Button[,] btnGrid, int Dir, int i)
        {
            Team opponent = getOppTeam();
            //if cell is occupied and is the first opponent encountered you may choose to take 
            if (cellGrid[posX, posY + i].getIsOcuppied() && cellGrid[posX, posY + i].getPiece().getColor() == opponent)
            {
                if (Dir == 0)
                {
                    cellGrid[posX, posY + i].setIsLegalMove(true);
                    btnGrid[posX, posY + i].FillColor = Color.GreenYellow;
                    return true;
                }
            }
            else if (cellGrid[posX, posY + i].getIsOcuppied())
            {
                cellGrid[posX, posY + i].setIsLegalMove(false);
                return true;
            }
            return false;
        }


        public bool checkRightMove(int i, int posX, int posY, Cell[,] cellGrid, Guna2Button[,] btnGrid, int R)
        {
            Team opponent = getOppTeam();
            if (cellGrid[posX + i, posY + i].getIsOcuppied() && cellGrid[posX + i, posY + i].getPiece().getColor() == opponent)
            {
                if (R == 0)
                {
                    cellGrid[posX + i, posY + i].setIsLegalMove(true);
                    btnGrid[posX + i, posY + i].FillColor = Color.GreenYellow;
                    return true;
                }

            }
            else if (cellGrid[posX + i, posY + i].getIsOcuppied())
            {
                cellGrid[posX + i, posY + i].setIsLegalMove(false);
                return true;
            }
            return false;
        }

        public bool checkLeftMove(int i, int posX, int posY, Cell[,] cellGrid, Guna2Button[,] btnGrid, int L)
        {
            Team opponent = getOppTeam();
            if (cellGrid[posX + i, posY - i].getIsOcuppied() && cellGrid[posX + i, posY - i].getPiece().getColor() == opponent)
            {
                if (L == 0)
                {
                    cellGrid[posX + i, posY - i].setIsLegalMove(true);
                    btnGrid[posX + i, posY - i].FillColor = Color.GreenYellow;
                    return true;
                }

            }
            else if (cellGrid[posX + i, posY - i].getIsOcuppied())
            {
                cellGrid[posX + i, posY - i].setIsLegalMove(false);
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
