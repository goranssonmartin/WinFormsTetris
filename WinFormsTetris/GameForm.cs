using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTetris
{
    public partial class GameForm : Form
    {
        private int[][] gameBoard = new int[20][];
        private int[][][] symbols = AddPiecesToArray();
        private Color[] colorsOfSymbols = new Color[7];
        private int[] nextThreeSymbols = new int[] { -1, -1, -1 };
        private int[][] savedSymbol = GetSavedSymbol();
        private bool gameStarted = false;
        private int xCoordinate = 4;
        private int yCoordinate = 0;
        public GameForm()
        {
            InitializeComponent();
            CreateTempGameBoard();
            AddColorsToArray();
            GenerateThreePieces();
            gameArea.Image = CreateNewBitmap(201, 400);
            nextPieceOne.Image = CreateNewBitmap(80, 80);
            nextPieceTwo.Image = CreateNewBitmap(80, 80);
            savedPiece.Image = CreateNewBitmap(80, 80);
        }
        private void startGameButton_Click(object sender, EventArgs e)
        {
            if (!gameStarted)
            {
                gameStarted = true;
                GenerateThreePieces();
                StartTimer();
                PaintNextPieceOne();
                PaintNextPieceTwo();
            }
        }
        public void StartTimer()
        {
            gameTimer.Tick += new EventHandler(GameTimer_Tick);
            gameTimer.Interval = 1000; // in milliseconds
            gameTimer.Start();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            PaintNextPieceOne();
            PaintNextPieceTwo();
            PaintGameBoard();
            RemoveFirstPiece();
        }
        private void GenerateThreePieces()
        {
            Random rnd = new Random();
            for (int i = 0; i < 3; i++)
            {
                if (nextThreeSymbols[i] == -1)
                {
                    nextThreeSymbols[i] = rnd.Next(7);
                }
            }
        }
        private void RemoveFirstPiece()
        {
            Random rnd = new Random();
            for (int i = 0; i < nextThreeSymbols.Length; i++)
            {
                if (i + 1 < nextThreeSymbols.Length)
                {
                    int tempValue = nextThreeSymbols[i + 1];
                    nextThreeSymbols[i] = tempValue;
                }
                else
                {
                    nextThreeSymbols[i] = rnd.Next(7);
                }
            }
        }
        private static int[][] GetSavedSymbol()
        {
            return new int[1][];
        }

        private void PaintNextPieceOne()
        {
            nextPieceOne.Image = null;
            nextPieceOne.Image = CreateNewBitmap(80, 80);
            int[][] currentSymbol = symbols[nextThreeSymbols[1]];
            int nextLoop = currentSymbol[0].Length;
            int colorForSymbol = GetCurrentSymbol(currentSymbol) - 1;
            for (int i = 0; i < currentSymbol.Length; i++)
            {
                for (int j = 0; j < nextLoop; j++)
                {
                    if (currentSymbol[i][j] != 0)
                    {
                        using (var g = Graphics.FromImage(nextPieceOne.Image))
                        {
                            SolidBrush brush = new SolidBrush(colorsOfSymbols[colorForSymbol]);
                            Pen pen = new Pen(Color.Black);
                            g.FillRectangle(brush, new Rectangle(j * 20, i * 20, 20, 20));
                            g.DrawRectangle(pen, new Rectangle(j * 20, i * 20, 20, 20));

                            brush.Dispose();
                            pen.Dispose();
                        }
                    }
                }
            }
            nextPieceOne.Refresh();
        }

        private void PaintNextPieceTwo()
        {
            nextPieceTwo.Image = null;
            nextPieceTwo.Image = CreateNewBitmap(80, 80);
            int[][] currentSymbol = symbols[nextThreeSymbols[2]];
            int nextLoop = currentSymbol[0].Length;
            int colorForSymbol = GetCurrentSymbol(currentSymbol) - 1;
            for (int i = 0; i < currentSymbol.Length; i++)
            {
                for (int j = 0; j < nextLoop; j++)
                {
                    if (currentSymbol[i][j] != 0)
                    {
                        using (var g = Graphics.FromImage(nextPieceTwo.Image))
                        {
                            SolidBrush brush = new SolidBrush(colorsOfSymbols[colorForSymbol]);
                            Pen pen = new Pen(Color.Black);
                            g.FillRectangle(brush, new Rectangle(j * 20, i * 20, 20, 20));
                            g.DrawRectangle(pen, new Rectangle(j * 20, i * 20, 20, 20));

                            brush.Dispose();
                            pen.Dispose();
                        }
                    }
                }
            }
            nextPieceTwo.Refresh();
        }

        private static int[][][] AddPiecesToArray()
        {
            int[][][] returnArray = new int[7][][];
            //one (T)
            returnArray[0] = new int[3][];
            returnArray[0][0] = new int[3];
            returnArray[0][1] = new int[3];
            returnArray[0][2] = new int[3];
            returnArray[0][0][0] = 0;
            returnArray[0][0][1] = 0;
            returnArray[0][0][2] = 0;
            returnArray[0][1][0] = 5;
            returnArray[0][1][1] = 5;
            returnArray[0][1][2] = 5;
            returnArray[0][2][0] = 0;
            returnArray[0][2][1] = 5;
            returnArray[0][2][2] = 0;
            //two (O)
            returnArray[1] = new int[2][];
            returnArray[1][0] = new int[2];
            returnArray[1][1] = new int[2];
            returnArray[1][0][0] = 7;
            returnArray[1][0][1] = 7;
            returnArray[1][1][0] = 7;
            returnArray[1][1][1] = 7;
            //three (L)
            returnArray[2] = new int[3][];
            returnArray[2][0] = new int[3];
            returnArray[2][1] = new int[3];
            returnArray[2][2] = new int[3];
            returnArray[2][0][0] = 0;
            returnArray[2][0][1] = 4;
            returnArray[2][0][2] = 0;
            returnArray[2][1][0] = 0;
            returnArray[2][1][1] = 4;
            returnArray[2][1][2] = 0;
            returnArray[2][2][0] = 0;
            returnArray[2][2][1] = 4;
            returnArray[2][2][2] = 4;
            //four (J)
            returnArray[3] = new int[3][];
            returnArray[3][0] = new int[3];
            returnArray[3][1] = new int[3];
            returnArray[3][2] = new int[3];
            returnArray[3][0][0] = 0;
            returnArray[3][0][1] = 1;
            returnArray[3][0][2] = 0;
            returnArray[3][1][0] = 0;
            returnArray[3][1][1] = 1;
            returnArray[3][1][2] = 0;
            returnArray[3][2][0] = 1;
            returnArray[3][2][1] = 1;
            returnArray[3][2][2] = 0;
            //five (I)
            returnArray[4] = new int[4][];
            returnArray[4][0] = new int[4];
            returnArray[4][1] = new int[4];
            returnArray[4][2] = new int[4];
            returnArray[4][3] = new int[4];
            returnArray[4][0][0] = 0;
            returnArray[4][0][1] = 2;
            returnArray[4][0][2] = 0;
            returnArray[4][0][3] = 0;
            returnArray[4][1][0] = 0;
            returnArray[4][1][1] = 2;
            returnArray[4][1][2] = 0;
            returnArray[4][1][3] = 0;
            returnArray[4][2][0] = 0;
            returnArray[4][2][1] = 2;
            returnArray[4][2][2] = 0;
            returnArray[4][2][3] = 0;
            returnArray[4][3][0] = 0;
            returnArray[4][3][1] = 2;
            returnArray[4][3][2] = 0;
            returnArray[4][3][3] = 0;
            //six (S)
            returnArray[5] = new int[3][];
            returnArray[5][0] = new int[3];
            returnArray[5][1] = new int[3];
            returnArray[5][2] = new int[3];
            returnArray[5][0][0] = 0;
            returnArray[5][0][1] = 3;
            returnArray[5][0][2] = 3;
            returnArray[5][1][0] = 3;
            returnArray[5][1][1] = 3;
            returnArray[5][1][2] = 0;
            returnArray[5][2][0] = 0;
            returnArray[5][2][1] = 0;
            returnArray[5][2][2] = 0;
            //seven (Z)
            returnArray[6] = new int[3][];
            returnArray[6][0] = new int[3];
            returnArray[6][1] = new int[3];
            returnArray[6][2] = new int[3];
            returnArray[6][0][0] = 6;
            returnArray[6][0][1] = 6;
            returnArray[6][0][2] = 0;
            returnArray[6][1][0] = 0;
            returnArray[6][1][1] = 6;
            returnArray[6][1][2] = 6;
            returnArray[6][2][0] = 0;
            returnArray[6][2][1] = 0;
            returnArray[6][2][2] = 0;
            return returnArray;
        }

        private Bitmap CreateNewBitmap(int width, int height)
        {
            Bitmap gameBoard = new Bitmap(width, height);
            Color backgroundColor = Color.FromArgb(255, 206, 206, 206);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    gameBoard.SetPixel(i, j, backgroundColor);
                }
            }
            return gameBoard;
        }
        private void CreateTempGameBoard()
        {
            for (int i = 0; i < gameBoard.Length; i++)
            {
                int[] arr = new int[10];
                for (int j = 0; j < 10; j++)
                {
                    arr[j] = 0;
                }
                gameBoard[i] = arr;
            }
        }

        private void AddColorsToArray()
        {
            colorsOfSymbols[0] = Color.FromArgb(255, 3, 65, 174);   //blue
            colorsOfSymbols[1] = Color.FromArgb(255, 0, 255, 239);  //cyan
            colorsOfSymbols[2] = Color.FromArgb(255, 114, 203, 59); //green
            colorsOfSymbols[3] = Color.FromArgb(255, 255, 151, 28); //orange
            colorsOfSymbols[4] = Color.FromArgb(255, 91, 10, 145);  //purple
            colorsOfSymbols[5] = Color.FromArgb(255, 255, 50, 19);  //red
            colorsOfSymbols[6] = Color.FromArgb(255, 255, 213, 0);  //yellow
        }

        private void PaintGameBoard()
        {
            gameArea.Image = null;
            gameArea.Image = CreateNewBitmap(201, 400);
            int[][] currentSymbol = symbols[nextThreeSymbols[0]];
            int nextLoop = currentSymbol[0].Length;
            int colorForSymbol = GetCurrentSymbol(currentSymbol) - 1;
            for (int i = 0; i < currentSymbol.Length; i++)
            {
                for (int j = 0; j < nextLoop; j++)
                {
                    if (currentSymbol[i][j] != 0)
                    {
                        using (var g = Graphics.FromImage(gameArea.Image))
                        {
                            SolidBrush brush = new SolidBrush(colorsOfSymbols[colorForSymbol]);
                            Pen pen = new Pen(Color.Black);
                            g.FillRectangle(brush, new Rectangle(j * 20, i * 20, 20, 20));
                            g.DrawRectangle(pen, new Rectangle(j * 20, i * 20, 20, 20));

                            brush.Dispose();
                            pen.Dispose();
                        }
                    }
                }
            }
            gameArea.Refresh();
            CreateTempGameBoard();
        }

        private int GetCurrentSymbol(int[][] currentSymbol)
        {
            int returnValue = -1;
            foreach (int[] row in currentSymbol)
            {
                foreach (int space in row)
                {
                    if (space != 0)
                    {
                        returnValue = space;
                        break;
                    }
                }
            }
            return returnValue;
        }
    }
}
