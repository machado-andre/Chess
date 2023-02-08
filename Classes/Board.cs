using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Classes
{
    class Board
    {
        private int size;
        
        private Cell[,] boardGrid;
        public List<Piece> pieces = new List<Piece>();

        public Board(int Size)
        {
            size = Size;

            boardGrid = new Cell[size, size];

            for(int i = 0; i < size; i++)
            {
                for(int j = 0; j<size; j++)
                {
                    boardGrid[i, j] = new Cell(i, j);
                }
            }

            setPieces();
        }

        public int getSize()
        {
            return size;
        }


        public void clearLegalMoves()
        {
            for(int i=0; i < size; i++)
            {
                for(int j=0; j < size; j++)
                {
                    boardGrid[i, j].setIsLegalMove(false);
                }
            }
        }

        public Cell[,] getBoardGrid()
        {
            return boardGrid;
        }

        public Cell setBoardGrid(int x, int y)
        {
            return boardGrid[x,y];
        }

        public void setPieces()
        {
            pieceInst();
            Piece piece;
            //blacks
            piece = pieces[28];
            boardGrid[0, 0].setPiece(piece);
            piece.setLocation(boardGrid[0, 0]);

            piece = pieces[20];
            boardGrid[1, 0].setPiece(piece);
            piece.setLocation(boardGrid[1, 0]);

            piece = pieces[24];
            boardGrid[2, 0].setPiece(piece);
            piece.setLocation(boardGrid[2, 0]);

            piece = pieces[18];
            boardGrid[3, 0].setPiece(piece);
            piece.setLocation(boardGrid[3, 0]);

            piece = pieces[16];
            boardGrid[4, 0].setPiece(piece);
            piece.setLocation(boardGrid[4, 0]);

            piece = pieces[25];
            boardGrid[5, 0].setPiece(piece);
            piece.setLocation(boardGrid[5, 0]);

            piece = pieces[21];
            boardGrid[6, 0].setPiece(piece);
            piece.setLocation(boardGrid[6, 0]);

            piece = pieces[29];
            boardGrid[7, 0].setPiece(piece);
            piece.setLocation(boardGrid[7, 0]);

            //Black Pawns
            piece = pieces[0];
            boardGrid[0, 1].setPiece(piece);
            piece.setLocation(boardGrid[0, 1]);

            piece = pieces[1];
            boardGrid[1, 1].setPiece(piece);
            piece.setLocation(boardGrid[1, 1]);

            piece = pieces[2];
            boardGrid[2, 1].setPiece(piece);
            piece.setLocation(boardGrid[2, 1]);

            piece = pieces[3];
            boardGrid[3, 1].setPiece(piece);
            piece.setLocation(boardGrid[3, 1]);

            piece = pieces[4];
            boardGrid[4, 1].setPiece(piece);
            piece.setLocation(boardGrid[4, 1]);

            piece = pieces[5];
            boardGrid[5, 1].setPiece(piece);
            piece.setLocation(boardGrid[5, 1]);

            piece = pieces[6];
            boardGrid[6, 1].setPiece(piece);
            piece.setLocation(boardGrid[6, 1]);

            piece = pieces[7];
            boardGrid[7, 1].setPiece(piece);
            piece.setLocation(boardGrid[7, 1]);



            //whites
            piece = pieces[30];
            boardGrid[0, 7].setPiece(piece);
            piece.setLocation(boardGrid[0, 7]);

            piece = pieces[22];
            boardGrid[1, 7].setPiece(piece);
            piece.setLocation(boardGrid[1, 7]);

            piece = pieces[26];
            boardGrid[2, 7].setPiece(piece);
            piece.setLocation(boardGrid[2, 7]);

            piece = pieces[17];
            boardGrid[3, 7].setPiece(piece);
            piece.setLocation(boardGrid[3, 7]);

            piece = pieces[19];
            boardGrid[4, 7].setPiece(piece);
            piece.setLocation(boardGrid[4, 7]);

            piece = pieces[27];
            boardGrid[5, 7].setPiece(piece);
            piece.setLocation(boardGrid[5, 7]);

            piece = pieces[23];
            boardGrid[6, 7].setPiece(piece);
            piece.setLocation(boardGrid[6, 7]);

            piece = pieces[31];
            boardGrid[7, 7].setPiece(piece);
            piece.setLocation(boardGrid[7, 7]);


            //White Pawns
            piece = pieces[8];
            boardGrid[0, 6].setPiece(piece);
            piece.setLocation(boardGrid[0, 6]);

            piece = pieces[9];
            boardGrid[1, 6].setPiece(piece);
            piece.setLocation(boardGrid[1, 6]);

            piece = pieces[10];
            boardGrid[2, 6].setPiece(piece);
            piece.setLocation(boardGrid[2, 6]);

            piece = pieces[11];
            boardGrid[3, 6].setPiece(piece);
            piece.setLocation(boardGrid[3, 6]);

            piece = pieces[12];
            boardGrid[4, 6].setPiece(piece);
            piece.setLocation(boardGrid[4, 6]);

            piece = pieces[13];
            boardGrid[5, 6].setPiece(piece);
            piece.setLocation(boardGrid[5, 6]);

            piece = pieces[14];
            boardGrid[6, 6].setPiece(piece);
            piece.setLocation(boardGrid[6, 6]);

            piece = pieces[15];
            boardGrid[7, 6].setPiece(piece);
            piece.setLocation(boardGrid[7, 6]);
        }

        #region pieceInst
        public void pieceInst()
        {
            Pawn blackPawn1 = new Pawn(Team.Black, Properties.Resources.blackPawn, 1);
            pieces.Add(blackPawn1);
            Pawn blackPawn2 = new Pawn(Team.Black, Properties.Resources.blackPawn, 2);
            pieces.Add(blackPawn2);
            Pawn blackPawn3 = new Pawn(Team.Black, Properties.Resources.blackPawn, 3);
            pieces.Add(blackPawn3);
            Pawn blackPawn4 = new Pawn(Team.Black, Properties.Resources.blackPawn, 4);
            pieces.Add(blackPawn4);
            Pawn blackPawn5 = new Pawn(Team.Black, Properties.Resources.blackPawn, 5);
            pieces.Add(blackPawn5);
            Pawn blackPawn6 = new Pawn(Team.Black, Properties.Resources.blackPawn, 6);
            pieces.Add(blackPawn6);
            Pawn blackPawn7 = new Pawn(Team.Black, Properties.Resources.blackPawn, 7);
            pieces.Add(blackPawn7);
            Pawn blackPawn8 = new Pawn(Team.Black, Properties.Resources.blackPawn, 8);
            pieces.Add(blackPawn8);

            Pawn whitePawn1 = new Pawn(Team.White, Properties.Resources.whitePawn, 1);
            pieces.Add(whitePawn1);
            Pawn whitePawn2 = new Pawn(Team.White, Properties.Resources.whitePawn, 2);
            pieces.Add(whitePawn2);
            Pawn whitePawn3 = new Pawn(Team.White, Properties.Resources.whitePawn, 3);
            pieces.Add(whitePawn3);
            Pawn whitePawn4 = new Pawn(Team.White, Properties.Resources.whitePawn, 4);
            pieces.Add(whitePawn4);
            Pawn whitePawn5 = new Pawn(Team.White, Properties.Resources.whitePawn, 5);
            pieces.Add(whitePawn5);
            Pawn whitePawn6 = new Pawn(Team.White, Properties.Resources.whitePawn, 6);
            pieces.Add(whitePawn6);
            Pawn whitePawn7 = new Pawn(Team.White, Properties.Resources.whitePawn, 7);
            pieces.Add(whitePawn7);
            Pawn whitePawn8 = new Pawn(Team.White, Properties.Resources.whitePawn, 8);
            pieces.Add(whitePawn8);

            Piece blacKing = new King(Team.Black, Properties.Resources.blacKing, 1);
            pieces.Add(blacKing);
            Piece whiteKing = new King(Team.White, Properties.Resources.whiteKing, 1);
            pieces.Add(whiteKing);

            Piece blackQueen = new Queen(Team.Black, Properties.Resources.blackQueen, 1);
            pieces.Add(blackQueen);
            Piece whiteQueen = new Queen(Team.White, Properties.Resources.whiteQueen, 1);
            pieces.Add(whiteQueen);

            Piece blackKnight1 = new Knight(Team.Black, Properties.Resources.blackKnight, 1);
            pieces.Add(blackKnight1);
            Piece blackKnight2 = new Knight(Team.Black, Properties.Resources.blackKnight, 2);
            pieces.Add(blackKnight2);
            Piece whiteKnight1 = new Knight(Team.White, Properties.Resources.whiteKnight, 1);
            pieces.Add(whiteKnight1);
            Piece whiteKnight2 = new Knight(Team.White, Properties.Resources.whiteKnight, 1);
            pieces.Add(whiteKnight2);

            Piece blackBishop1 = new Bishop(Team.Black, Properties.Resources.blackBishop, 1);
            pieces.Add(blackBishop1);
            Piece blackBishop2 = new Bishop(Team.Black, Properties.Resources.blackBishop, 2);
            pieces.Add(blackBishop2);
            Piece whiteBishop1 = new Bishop(Team.White, Properties.Resources.whiteBishop, 1);
            pieces.Add(whiteBishop1);
            Piece whiteBishop2 = new Bishop(Team.White, Properties.Resources.whiteBishop, 2);
            pieces.Add(whiteBishop2);

            Piece blackRook1 = new Rook(Team.Black, Properties.Resources.blackRook, 1);
            pieces.Add(blackRook1);
            Piece blackRook2 = new Rook(Team.Black, Properties.Resources.blackRook, 2);
            pieces.Add(blackRook2);
            Piece whiteRook1 = new Rook(Team.White, Properties.Resources.whiteRook, 1);
            pieces.Add(whiteRook1);
            Piece whiteRook2 = new Rook(Team.White, Properties.Resources.whiteRook, 2);
            pieces.Add(whiteRook2);
        }
        #endregion
    }
}
