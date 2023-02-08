using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    class Bishop : Piece
    {
        public Bishop(Team color, Image img, byte number) : base(color, img, number)
        {

        }

        public override void findLegalMoves(Cell curCell, Cell[,] cellGrid, Guna2Button[,] btnGrid)
        {
            int posX = curCell.getPositionX();
            int posY = curCell.getPositionY();
            int R = 0,L = 0;
            int i = 1;


            while (posX + i <= 7 && posY + i <= 7)
            {
                cellGrid[posX + i, posY + i].setIsLegalMove(true);
                if (checkRightMove(i, posX, posY, cellGrid, btnGrid, R))
                {
                    break;
                }
                i++;
            }
            i = -1;
            while (posX + i >= 0 && posY + i >= 0)
            {
                cellGrid[posX + i, posY + i].setIsLegalMove(true);
                if (checkRightMove(i, posX, posY, cellGrid, btnGrid, R))
                {
                    break;
                }
                i--;
            }

            i = 1;

            while(posX + i <= 7 && posY - i >= 0)
            {
                cellGrid[posX + i, posY - i].setIsLegalMove(true);
                if (checkLeftMove(i, posX, posY, cellGrid, btnGrid, L))
                {
                    break;
                }
                i++;
            }
            i = -1;
            while (posX + i >= 0 && posY - i <= 7)
            {
                cellGrid[posX + i, posY - i].setIsLegalMove(true);
                if (checkLeftMove(i, posX, posY, cellGrid, btnGrid, L))
                {
                    break;
                }
                i--;
            }
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
            else if(cellGrid[posX + i, posY + i].getIsOcuppied())
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

        //public override void checkForCheck(){}

        public override Team checkForCheck(Cell curCell, Cell[,] cellGrid, Guna2Button[,] btnGrid)
        {
            int posX = curCell.getPositionX();
            int posY = curCell.getPositionY();
            int i = 1;

            while (posX + i <= 7 && posY + i <= 7)
            {
                if (checkRight(i, posX, posY, cellGrid))
                {
                    return getColor();
                }
                i++;
            }
            i = -1;
            while (posX + i >= 0 && posY + i >= 0)
            {
                if (checkRight(i, posX, posY, cellGrid))
                {
                    return getColor();
                }
                i--;
            }

            i = 1;
            while (posX + i <= 7 && posY - i >= 0)
            {
                if (checkLeft(i, posX, posY, cellGrid))
                {
                    return getColor();
                }
                i++;
            }
            i = -1;
            while (posX + i >= 0 && posY - i <= 7)
            {
                if(checkLeft(i, posX, posY, cellGrid))
                {
                    return getColor();
                }
                i--;
            }

            return Team.None;
        }

        private bool checkLeft(int i, int posX, int posY, Cell[,] cellGrid)
        {
            Team opp = getOppTeam();
            if (cellGrid[posX + i, posY - i].getIsOcuppied() && cellGrid[posX + i, posY - i].getPiece().getColor() == opp && cellGrid[posX + i, posY - i].getPiece() is King)
            {
                MessageDialog.Show("Check!");
                return true;

            }
            return false;
        }

        private bool checkRight(int i, int posX, int posY, Cell[,] cellGrid)
        {
            Team opp = getOppTeam();
            if (cellGrid[posX + i, posY + i].getIsOcuppied() && cellGrid[posX + i, posY - i].getPiece().getColor() == opp &&  cellGrid[posX + i, posY + i].getPiece() is King)
            {
                MessageDialog.Show("Check!");
                return true;
            }
            return false;
        }
    }
}
