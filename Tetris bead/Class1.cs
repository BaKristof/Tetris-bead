using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_bead
{
    internal class Game
    {
        private Board board;
        private Piece currentPiece;
        private int currentPieceX, currentPieceY;
        private int gameSpeed = 500;
        private PieceGenerator pc= new PieceGenerator();
        private Graphics graphics;
        private string irany;
        private bool volt= false;

        public Game(Graphics gp)
        {
            this.board = new Board();
            this.currentPiece = pc.GeneratePiece();
            currentPieceX = (Board.Width / 2) - (currentPiece.Width / 2);
            currentPieceY = 0;
            graphics = gp;
        }
        public void mozg(string valami) {
            irany = valami;
            volt = true;
        }

        public void Run()
        {
            while (true)
            {
                if (volt)
                {
                    HandleInput(irany);
                    volt = false;
                }

                if (board.IsColliding(currentPieceX, currentPieceY + 1, currentPiece))
                {
                    Piece pci = currentPiece;
                    board.LockPiece(currentPieceX, currentPieceY, pci);
                    board.CheckForCompletedRows();
                    currentPiece = pc.GeneratePiece();

                    currentPieceX = (Board.Width / 2) - (currentPiece.Width / 2);
                    currentPieceY = 0;
                    gameSpeed = 500;

                    if (board.IsColliding(currentPieceX, currentPieceY, currentPiece))
                    {
                        GameOver();
                        return;
                    }
                }
                else
                {   
                    currentPieceY++;
                }

                Draw();
                System.Threading.Thread.Sleep(gameSpeed);
            }
        }

        private void HandleInput(string e)
        {
            switch (e)
            {
                case "bal":
                    if (!board.IsColliding(currentPieceX - 1, currentPieceY, currentPiece))
                    {
                        currentPieceX--;
                    }
                    break;
                case "jobb":
                    if (!board.IsColliding(currentPieceX + 1, currentPieceY, currentPiece))
                    {
                        currentPieceX++;
                    }
                    break;
                case "fel":
                    currentPiece.Rotate();
                    if (board.IsColliding(currentPieceX, currentPieceY, currentPiece))
                    {
                        currentPiece.RotateBack();
                    }
                    break;
                case "le":
                    gameSpeed = 5;
                    break;
            }
        }

        private void Draw()
        {
            graphics.Clear(Color.White);
            board.Draw(graphics);
            currentPiece.Draw(currentPieceX, currentPieceY, graphics);
        }

        private void GameOver()
        {
            graphics.Clear(Color.White);
            Console.WriteLine("Game over!");
        }
    }
    internal class Board
    {
        public const int Width = 10;
        public const int Height = 20;

        private int[,] board;

        public Board()
        {
            board = new int[Width, Height];
        }

        public bool IsColliding(int x, int y, Piece piece)
        {
            
            for (int i = 0; i < piece.Width; i++)
            {
                for (int j = 0; j < piece.Height; j++)
                {
                    if (piece.Shape[i,j] != 0)
                    {
                        int boardX = x + i;
                        int boardY = y + j;

                        if (boardX < 0 || boardX >= Width || boardY >= Height)
                        {
                            return true;
                        }

                        if (boardY >= 0 && board[boardX, boardY] != 0)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public void LockPiece(int x, int y, Piece piece)
        {
            for (int i = 0; i < piece.Width; i++)
            {
                for (int j = 0; j < piece.Height; j++)
                {
                    if (piece.Shape[i, j] != 0)
                    {
                        int boardX = x + i;
                        int boardY = y + j;

                        board[boardX, boardY] = piece.Shape[i, j];
                    }
                }
            }
        }

        public void CheckForCompletedRows()
        {
            for (int y = 0; y < Height; y++)
            {
                bool rowCompleted = true;

                for (int x = 0; x < Width; x++)
                {
                    if (board[x, y] == 0)
                    {
                        rowCompleted = false;
                        break;
                    }
                }

                if (rowCompleted)
                {
                    for (int i = y; i > 0; i--)
                    {
                        for (int x = 0; x < Width; x++)
                        {
                            board[x, i] = board[x, i - 1];
                        }
                    }

                    for (int x = 0; x < Width; x++)
                    {
                        board[x, 0] = 0;
                    }
                }
            }
        }

        public void Draw(Graphics graphics)
        {
            int cellSize = 30;
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    int cellValue = board[x, y];
                    Brush brush = cellValue == 0 ? Brushes.Black : new SolidBrush(Color.Blue);
                    graphics.FillRectangle(brush, x * cellSize, y * cellSize, cellSize, cellSize);


                }
            }
        }
    }

    internal class Piece
    {
        public int[,] Shape { get; set; }
        public Color Color { get; set; }

        private int x;
        private int y;
        private int rotation;

        public Piece(int[,] shape, Color color)
        {
            Shape = shape;
            Color = color;
            this.Color = color;
            this.x = 0;
            this.y = 0;
            this.rotation = 0;
        }

        public int Width
        {
            get { return Shape.GetLength(0); }
        }

        public int Height
        {
            get { return Shape.GetLength(1); }
        }

        public void Rotate()
        {
            int[,] newShape = new int[Height, Width];

            for (int row = 0; row < Height; row++)
            {
                for (int col = 0; col < Width; col++)
                {
                    newShape[row, Width - col - 1] = Shape[col, row];
                }
            }

            Shape = newShape;
        }

        public void Draw(int x, int y, Graphics graphics)
        {
            int cellSize = 30;


            for (int i = 0; i < Shape.GetLength(0); i++)
            {
                for (int j = 0; j < Shape.GetLength(1); j++)
                {
                    if (Shape[i, j] == 1)
                    {
                        Brush brush = new SolidBrush(Color);
                        graphics.FillRectangle(brush, (x + i) * cellSize, (y + j) * cellSize, cellSize, cellSize);
                        ;
                    }
                }
            }

        }

        public void RotateBack()
        {
            rotation--;
            if (rotation < 0)
            {
                rotation = 3;
            }

            int[,] newShape = new int[Shape.GetLength(1), Shape.GetLength(0)];
            for (int i = 0; i < Shape.GetLength(0); i++)
            {
                for (int j = 0; j < Shape.GetLength(1); j++)
                {
                    newShape[j, Shape.GetLength(0) - i - 1] = Shape[i, j];
                }
            }

            Shape = newShape;
        }
    }


    internal class PieceGenerator
    {
        private readonly Random random = new Random();

        private readonly Piece[] pieces = {
        new Piece(new[,] { { 1, 1 }, { 1, 1 } }, Color.Yellow),
        new Piece(new[,] { { 1, 1, 1, 1 } }, Color.Cyan),
        new Piece(new[,] { { 1, 1, 0 }, { 0, 1, 1 } }, Color.Green),
        new Piece(new[,] { { 0, 1, 1 }, { 1, 1, 0 } }, Color.Red),
        new Piece(new[,] { { 1, 0, 0 }, { 1, 1, 1 } }, Color.Blue),
        new Piece(new[,] { { 0, 0, 1 }, { 1, 1, 1 } }, Color.Orange),
        new Piece(new[,] { { 1, 1, 1 }, { 0, 1, 0 } }, Color.Purple)
    };

        public Piece GeneratePiece()
        {
            return pieces[random.Next(pieces.Length)];
        }
    }
}