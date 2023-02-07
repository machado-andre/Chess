using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    class Pawn : Piece
    {
        public Pawn(Team color, Image img, byte number) : base(color, img, number)
        {
            
        }

        public override void findLegalMoves(Cell curCell, Cell[,] cellGrid, Guna.UI2.WinForms.Guna2Button[,] btnGrid)
        {
            int posX = curCell.getPositionX();
            int posY = curCell.getPositionY();

            if (getColor() == Team.Black)
            {
                //check (Black) attack
                findYVariation(posX, posY, curCell, cellGrid, btnGrid, 1, Team.White, 1, 7);
            }
            else
            {
                // check (White) attack
                findYVariation(posX, posY, curCell, cellGrid, btnGrid, -1, Team.Black, 6, 0);
            }
        }

        private void findYVariation(int posX, int posY ,Cell curCell, Cell[,] cellGrid, Guna.UI2.WinForms.Guna2Button[,] btnGrid, int i, Team color,int start, int end)
        {

            if (posX + 1 <= 7 && checkTeam(posY,end,i))
            {
                if (cellGrid[posX + 1, posY + i].getPiece() != null)
                {
                    if (cellGrid[posX + 1, posY + i].getPiece().getColor() == color)
                    {
                        cellGrid[posX + 1, posY + i].setIsLegalMove(true);
                        btnGrid[posX + 1, posY + i].FillColor = Color.GreenYellow;
                    }
                }
            }
            if (posX - 1 >= 0)
            {
                if (cellGrid[posX - 1, posY + i].getPiece() != null)
                {
                    if (cellGrid[posX - 1, posY + i].getPiece().getColor() == color)
                    {
                        cellGrid[posX - 1, posY + i].setIsLegalMove(true);
                        btnGrid[posX - 1, posY + i].FillColor = Color.GreenYellow;
                    }
                }
            }

            if (posY != start && checkTeam(posY, end, i))
            {
                if (cellGrid[posX, posY + i].getIsOcuppied())
                {
                    cellGrid[posX, posY + i].setIsLegalMove(false);
                    return;
                }
                else
                {
                    cellGrid[posX, posY + i].setIsLegalMove(true);
                    return;
                }
            }
            else
            {
                if (cellGrid[posX, posY + i].getIsOcuppied())
                {
                    cellGrid[posX, posY + i].setIsLegalMove(false);
                    cellGrid[posX, posY + i*2].setIsLegalMove(false);
                    return;
                }
                if (cellGrid[posX, posY + i*2].getIsOcuppied())
                {
                    cellGrid[posX, posY + i].setIsLegalMove(true);
                    cellGrid[posX, posY + i*2].setIsLegalMove(false);
                    return;
                }

                cellGrid[posX, posY + i].setIsLegalMove(true);
                cellGrid[posX, posY + i*2].setIsLegalMove(true);
            }
        }

        private bool checkTeam(int posY, int end, int i)
        {
            if (end == 0)
            {
                return posY + i >= end;
            }
            else
            {
                return posY + i <= end;
            }
        }
    }
}
