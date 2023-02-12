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
            int i = -1;

            //Horizontal
            while (posX + i >= 0)
            {
                cellGrid[posX + i, posY].setIsLegalMove(true);
                if (checkHorizontalMove(i, posX, posY, cellGrid, btnGrid))
                {
                    break;
                }
                i--;
            }
            i = 1;
            while(posX + i <= 7)
            {
                cellGrid[posX + i, posY].setIsLegalMove(true);
                if (checkHorizontalMove(i, posX, posY, cellGrid, btnGrid))
                {
                    break;
                }
                i++;
            }
            i = -1;

            //Vertical
            while(posY + i >= 0)
            {
                cellGrid[posX, posY + i].setIsLegalMove(true);
                if (checkVerticalMove(i, posX, posY, cellGrid, btnGrid))
                {
                    break;
                }
                i--;
            }
            i = 1;
            while(posY + i <= 7)
            {
                cellGrid[posX, posY + i].setIsLegalMove(true);
                if (checkVerticalMove(i, posX, posY, cellGrid, btnGrid))
                {
                    break;
                }
                i++;
            }
        }

        public bool checkHorizontalMove(int i, int posX, int posY, Cell[,] cellGrid, Guna2Button[,] btnGrid)
        {
            Team opponent = getOppTeam();
            //if cell is occupied and is the first opponent encountered you may choose to take 
            if (cellGrid[posX + i, posY].getIsOcuppied() && cellGrid[posX + i, posY].getPiece().getColor() == opponent)
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

        public bool checkVerticalMove(int i, int posX, int posY, Cell[,] cellGrid, Guna2Button[,] btnGrid)
        {
            Team opponent = getOppTeam();
            //if cell is occupied and is the first opponent encountered you may choose to take 
            if (cellGrid[posX, posY + i].getIsOcuppied() && cellGrid[posX, posY + i].getPiece().getColor() == opponent)
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

        public override Team checkForCheck(Cell curCell, Cell[,] cellGrid)
        {
            Team opp = getOppTeam();
            int posX = curCell.getPositionX();
            int posY = curCell.getPositionY();
            int i = -1;

            //Horizontal
            while (posX + i >= 0)
            {
                if (horizontalCheck(i, posX, posY, cellGrid) == 1)
                {
                    return opp;
                }
                else if (horizontalCheck(i, posX, posY, cellGrid) == 2)
                {
                    break;
                }
                i--;
            }
            i = 1;
            while (posX + i <= 7)
            {
                if (horizontalCheck(i, posX, posY, cellGrid) == 1)
                {
                    return opp;
                }
                else if (horizontalCheck(i, posX, posY, cellGrid) == 2)
                {
                    break;
                }
                i++;
            }
            i = -1;

            //Vertical
            while (posY + i >= 0)
            {
                if (verticalCheck(i, posX, posY, cellGrid) == 1)
                {
                    return opp;
                }
                else if (verticalCheck(i, posX, posY, cellGrid) == 2)
                {
                    break;
                }
                i--;
            }
            i = 1;
            while (posY + i <= 7)
            {
                if (verticalCheck(i, posX, posY, cellGrid) == 1)
                {
                    return opp;
                }
                else if(verticalCheck(i, posX, posY, cellGrid) == 2)
                {
                    break;
                }
                i++;
            }
            return Team.None;
        }


        public int horizontalCheck(int i, int posX, int posY, Cell[,] cellGrid)
        {
            Team opp = getOppTeam();
            if (cellGrid[posX + i, posY].getIsOcuppied() && cellGrid[posX + i, posY].getPiece().getColor() == opp && !(cellGrid[posX + i, posY].getPiece() is King))
            {
                return 2;
            }
            //if cell is occupied and is the first opponent encountered you may choose to take 
            else if (cellGrid[posX + i, posY].getIsOcuppied() && cellGrid[posX + i, posY].getPiece().getColor() == opp && cellGrid[posX + i, posY].getPiece() is King)
            {
                MessageDialog.Show(opp.ToString() + " in Check!");
                return 1;
            }
            return 0;
        }

        public int verticalCheck(int i, int posX, int posY, Cell[,] cellGrid)
        {
            Team opp = getOppTeam();
            if (cellGrid[posX, posY + i].getIsOcuppied() && cellGrid[posX, posY + i].getPiece().getColor() == opp && !(cellGrid[posX, posY + i].getPiece() is King))
            {
                return 2;
            }else if (cellGrid[posX, posY + i].getIsOcuppied() && cellGrid[posX, posY + i].getPiece().getColor() == opp && cellGrid[posX, posY + i].getPiece() is King)
            {
                MessageDialog.Show(opp.ToString() + " in Check!");
                return 1;
            } 
            return 0;
        }
    }
}
