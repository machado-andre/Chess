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
        Team turn;
        Team inCheck;
        public Form1()
        {
            InitializeComponent();
            instBoard();
            board.setPieces();
            turn = Team.White;
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
                inCheck = pieceSelected.checkForCheck(cellClicked, board.getBoardGrid());
                promotePawn(turn);
                switchTurns();
                return;
            }
            if (cellClicked.getPiece() == null)
            {
                resetBoard();
                return;
            }
            if ((turn == Team.White && cellClicked.getPiece().getColor() != Team.White) || (turn == Team.Black && cellClicked.getPiece().getColor() != Team.Black))
            {
                return;
            }

            pieceSelected = cellClicked.getPiece();
            if(pieceSelected.getColor() == Team.White && turn == Team.White)
            {
                pieceSelected.findLegalMoves(cellClicked, board.getBoardGrid(), btnGrid);

                for (int i = 0; i < board.getSize(); i++)
                {
                    for (int j = 0; j < board.getSize(); j++)
                    {
                        colorBoard(i, j);
                        if (board.setBoardGrid(i, j).getIsLegalMove())
                        {
                            btnGrid[i, j].FillColor = Color.GreenYellow;
                            if (btnGrid[i, j].Image != null)
                            {
                                board.setBoardGrid(i, j).setIsOccupied(true);
                            }
                        }
                    }
                }
                btnPreviouslyClicked = btnClicked;
            }
            else if(pieceSelected.getColor() == Team.Black && turn == Team.Black)
            {
                pieceSelected.findLegalMoves(cellClicked, board.getBoardGrid(), btnGrid);

                for (int i = 0; i < board.getSize(); i++)
                {
                    for (int j = 0; j < board.getSize(); j++)
                    {
                        colorBoard(i, j);
                        if (board.setBoardGrid(i, j).getIsLegalMove())
                        {
                            btnGrid[i, j].FillColor = Color.GreenYellow;
                            if (btnGrid[i, j].Image != null)
                            {
                                board.setBoardGrid(i, j).setIsOccupied(true);
                            }
                        }
                    }
                }
                btnPreviouslyClicked = btnClicked;
            }
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

        private void Form1_Load(object sender, EventArgs e){}

        public Team switchTurns()
        {
            return turn == Team.White ? turn = Team.Black : turn = Team.White;
        }

        private void checkPawnPromotion(Team team, Cell curCell, Guna.UI2.WinForms.Guna2Button[,] btnGrid)
        {
            if (team == Team.White)
            {
                Piece piece = new Queen(Team.White, Properties.Resources.whiteQueen, 2);
                curCell.setPiece(piece);
                piece.setLocation(curCell);
                btnGrid[curCell.getPositionX(), curCell.getPositionY()].Image = piece.GetImage();
                return;
            }
            if (team == Team.Black)
            {
                Piece piece = new Queen(Team.Black, Properties.Resources.blackQueen, 2);
                curCell.setPiece(piece);
                piece.setLocation(curCell);
                btnGrid[curCell.getPositionX(), curCell.getPositionY()].Image = piece.GetImage();
                return;
            }
        }

        private void promotePawn(Team team)
        {
            if (pieceSelected is Pawn && (pieceSelected.getLocation().getPositionY() == 7 || pieceSelected.getLocation().getPositionY() == 0))
            {
                checkPawnPromotion(team, pieceSelected.getLocation(), btnGrid);
            }
        }

    }
}
