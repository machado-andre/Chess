using Chess.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        static Board board = new Board(8);
        public Guna.UI2.WinForms.Guna2Button[,] btnGrid = new Guna.UI2.WinForms.Guna2Button[board.getSize(), board.getSize()];
        Piece pieceSelected = null;
        Guna.UI2.WinForms.Guna2Button btnPreviouslyClicked;
        public Form1()
        {
            InitializeComponent();
            instBoard();
            board.setPieces();
        }

        private void instBoard()
        {
            int cellSize = panel.Width / board.getSize();

            for(int i = 0; i < board.getSize(); i++)
            {
                for (int j = 0; j < board.getSize(); j++)
                {
                    Cell cell = board.setBoardGrid(i, j);
                    btnGrid[i, j] = new Guna.UI2.WinForms.Guna2Button();
                    btnGrid[i, j].Width = cellSize;
                    btnGrid[i, j].Height = cellSize;
                    btnGrid[i, j].Click += btnClick;
                    btnGrid[i, j].BorderThickness = 1;
                    btnGrid[i, j].BorderColor = Color.Gainsboro;
                    if(cell.getPiece() != null)
                    {
                        btnGrid[i, j].Image = cell.getPiece().GetImage();
                    }
                    panel.Controls.Add(btnGrid[i, j]);

                    //Where to place new btn
                    btnGrid[i, j].Location = new Point(i * cellSize, j * cellSize);
                    //Identify Cell
                    btnGrid[i, j].Tag = new Point(i, j);

                    //Color board
                    colorBoard(i, j);
                }
            }
        }

        private void btnClick(object sender, EventArgs e)
        {
            board.clearLegalMoves();
            Guna.UI2.WinForms.Guna2Button btnClicked = (Guna.UI2.WinForms.Guna2Button) sender;
            Point btnPos = (Point)btnClicked.Tag;
            Cell cellClicked = board.setBoardGrid(btnPos.X, btnPos.Y);

            if (btnClicked.FillColor == Color.GreenYellow)
            {
                btnPreviouslyClicked.Image = null;
                btnGrid[cellClicked.getPositionX(), cellClicked.getPositionY()].Image = pieceSelected.GetImage();
                pieceSelected.move(cellClicked);
                resetBoard();
                return;
            }

            pieceSelected = cellClicked.getPiece();
            if (pieceSelected != null)
                pieceSelected.findLegalMoves(cellClicked, board.getBoardGrid(), btnGrid);


            for (int i = 0; i < board.getSize(); i++)
            {
                for (int j = 0; j < board.getSize(); j++)
                {
                    colorBoard(i, j);
                    if (board.setBoardGrid(i, j).getIsLegalMove())
                    {
                        btnGrid[i, j].FillColor = Color.GreenYellow;
                        if (btnGrid[i, j].Image != null) {
                            board.setBoardGrid(i, j).setIsOccupied(true);
                        }
                    }
                }
            }

            //if (pieceSelected != null)
                //pieceSelected.findLegalMoves(cellClicked, board.getBoardGrid(), btnGrid);
            btnPreviouslyClicked = btnClicked;
        }

        private void resetBoard()
        {
            for (int i = 0; i < board.getSize(); i++)
            {
                for (int j = 0; j < board.getSize(); j++)
                {
                    colorBoard(i, j);
                }
            }
        }

        private void colorBoard(int i, int j)
        {
            if ((i % 2 == 0 && j % 2 == 0) || (i % 2 != 0 && j % 2 != 0))
            {
                btnGrid[i, j].FillColor = Color.White;
            }
            else
            {
                btnGrid[i, j].FillColor = Color.DarkGray;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
