using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    abstract class Piece
    {
        private Team color;
        private Image img;
        private Cell location;
        private byte number;

        public Piece(Team color, Image img, byte number)
        {
            this.color = color;
            this.img = img;
            this.number = number;
        }

        public Team getColor()
        {
            return color;
        }

        public Image GetImage()
        {
            return img;
        }

        public Cell getLocation()
        {
            return location;
        }

        public void setLocation(Cell location)
        {
            this.location = location;
        }

        public abstract void findLegalMoves(Cell curCell, Cell[,] cellGrid, Guna2Button[,] btnGrid);


        public void move(Cell targetCell)
        {
            Cell currCell = getLocation();

            targetCell.setPiece(this);
            targetCell.setIsOccupied(true);

            currCell.setPiece(null);
            currCell.setIsOccupied(false);

            setLocation(targetCell);
        }

        public Team getOppTeam()
        {
            if (getColor() == Team.Black)
            {
                return Team.White;
            }
            else
            {
                return Team.Black;
            }
        }

        public abstract Team checkForCheck(Cell curCell, Cell[,] cellGrid);
    }
}
