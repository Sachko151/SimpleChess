using Chess.classes;
using Chess.logic;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    public partial class Form1 : Form
    {
        private string firstClickedGrid = null, secondClickedGrid = null;
        private Grid[,] board = new Grid[8, 8];
        private bool IsWhiteTurn = true;
        private int whiteKingX = -1, whiteKingY = -1;
        private int blackKingX = -1, blackKingY = -1;
        private Panel previousPanel;
        private Color previousPanelColor;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

            GeneratePlayablePanels();         
            PopulateTheBoard();
        }
        public void GeneratePlayablePanels()
        {
            bool previousIsBlack = true;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {


                    int cubeSize = 109;
                    Panel temp = new Panel();
                    temp.Visible = true;
                    temp.Location = new Point((cubeSize * (j)) + 5, (cubeSize * i));
                    if (previousIsBlack)
                    {
                        temp.BackColor = Color.White;
                        previousIsBlack = false;
                    }
                    else
                    {
                        temp.BackColor = Color.Black;
                        previousIsBlack = true;
                    }
                    temp.Parent = panel1;
                    temp.BorderStyle = BorderStyle.FixedSingle;
                    temp.Width = cubeSize;
                    temp.Height = cubeSize;
                    temp.Click += new System.EventHandler(clickedPanel);
                    temp.AccessibleName = $"{i} {j}";

                    Grid grid = new Grid(temp);
                    board[i, j] = grid;
                }
                if (previousIsBlack)
                {
                    previousIsBlack = false;
                }
                else
                {
                    previousIsBlack = true;
                }

            }
        }
        void clickedPanel(object sender, System.EventArgs e)
        {

            Panel currentPanel = (Panel)sender;
            int firstX = -1, firstY = -1, secondX = -1, secondY = -1;
            if (firstClickedGrid == null)
            {
                FirstClickCode(currentPanel, firstX, firstY);
            }
            else
            {
                SecondClickCode(currentPanel, firstX, firstY, secondX, secondY);
            }
        }
        void PopulateTheBoard()
        {
            SpawnBlackFigures();
            SpawnWhiteFigures();
        }
        void SpawnBlackFigures()
        {
            Rook BlackRookLeft = new Rook(false);
            Rook BlackRookRight = new Rook(false);
            board[0, 0].OccupyingFigure = BlackRookLeft;
            board[0, 7].OccupyingFigure = BlackRookRight;
            Knight BlackKnightLeft = new Knight(false);
            Knight BlackKnightRight = new Knight(false);
            board[0, 1].OccupyingFigure = BlackKnightLeft;
            board[0, 6].OccupyingFigure = BlackKnightRight;
            Bishop BlackBishopLeft = new Bishop(false);
            Bishop BlackBishopRight = new Bishop(false);
            board[0, 2].OccupyingFigure = BlackBishopLeft;
            board[0, 5].OccupyingFigure = BlackBishopRight;
            Queen BlackQueen = new Queen(false);
            board[0, 3].OccupyingFigure = BlackQueen;
            King BlackKing = new King(false);
            board[0, 4].OccupyingFigure = BlackKing;
            blackKingX = 0; blackKingY = 4;
            //Spawn the Pawns
            for (int i = 0; i < 8; i++)
            {
                Pawn BlackPawn = new Pawn(false);
                board[1, i].OccupyingFigure = BlackPawn;
            }

        }
        void SpawnWhiteFigures()
        {
            Rook WhiteRookLeft = new Rook(true);
            Rook WhiteRookRight = new Rook(true);
            board[7, 0].OccupyingFigure = WhiteRookLeft;
            board[7, 7].OccupyingFigure = WhiteRookRight;
            Knight WhiteKnightLeft = new Knight(true);
            Knight WhiteKnightRight = new Knight(true);
            board[7, 1].OccupyingFigure = WhiteKnightLeft;
            board[7, 6].OccupyingFigure = WhiteKnightRight;
            Bishop WhiteBishopLeft = new Bishop(true);
            Bishop WhiteBishopRight = new Bishop(true);
            board[7, 2].OccupyingFigure = WhiteBishopLeft;
            board[7, 5].OccupyingFigure = WhiteBishopRight;
            Queen WhiteQueen = new Queen(true);
            board[7, 3].OccupyingFigure = WhiteQueen;
            King WhiteKing = new King(true);
            board[7, 4].OccupyingFigure = WhiteKing;
            whiteKingX = 7;
            whiteKingY = 4;
            //Spawn the Pawns
            for (int i = 0; i < 8; i++)
            {
                Pawn WhitePawn = new Pawn(true);
                board[6, i].OccupyingFigure = WhitePawn;
            }
        }
        bool CheckIfTheFigureUnintentionallyCapturesTheKing(Grid[,] board, int endX, int endY)
        {
            try
            {
                if (board[endX, endY].OccupyingFigure is King)
                {
                    return true;
                }
            }
            catch (System.Exception)
            { }
            return false;
        }
        void AlertIfTheEnemyKingCouldBeCaptured(Figure f, Grid[,] board, int endX, int endY, Label lbl)
        {
            int capturePosX, capturePosY;
            if (Check.DetermineTheFigureAndCheckIfItEndangersTheEnemyKing(f, board, endX, endY, out capturePosX, out capturePosY))
            {
                lbl.Text = (board[capturePosX, capturePosY].OccupyingFigure.IsWhite) ? "White King Could Be Captured!" : "Black King Could Be Captured!";
                return;
            }
            lbl.Text = "";


        }
        bool UnselectIfThePlayerMadeAMistake(int startX, int startY, int secondX, int secondY)
        {
            if (startX == secondX && startY == secondY)
            {
                previousPanel.BackColor = previousPanelColor;
                previousPanel = null;
                previousPanelColor = Color.Empty;
                firstClickedGrid = null;
                secondClickedGrid = null;

                return true;
            }
            return false;
        }
        bool CheckIfTheMoveWasNotPerformed(Figure figure, Grid[,] board, int startX, int startY, int endX, int endY)
        {
            if (board[startX, startY].OccupyingFigure != null && board[endX, endY].OccupyingFigure != figure)
            {
                return true;
            }
            return false;
        }
        bool ImplementTheTurns(Figure f, Grid[,] board, int startX, int startY, int endX, int endY)
        {

            Figure potentialEnemyFigure = null;
            if (board[endX, endY].OccupyingFigure != null)
            {
                potentialEnemyFigure = board[endX, endY].OccupyingFigure;
            }
            f.Move(board, startX, startY, endX, endY);
            if (board[endX, endY].OccupyingFigure != f)
            {
                lblOutput.Text = "Invalid Move!";
                return false;
            }
            board[endX, endY].OccupyingFigure = potentialEnemyFigure;
            board[startX, startY].OccupyingFigure = f;
            if (f is Pawn)
            {
                Pawn pawn = (Pawn)f;
                if ((pawn.IsWhite == true && startX == 6) || (pawn.IsWhite == false && startX == 1))
                {
                    pawn.FirstMove = true;
                }
            }
            if (IsWhiteTurn)
            {
                if (!f.IsWhite)
                {
                    lblOutput.Text = "Not Your Turn!";
                    return false;
                }
                IsWhiteTurn = false;
                lblTurn.Text = "Current Turn: Black";
                return true;
            }
            else
            {
                if (f.IsWhite)
                {
                    lblOutput.Text = "Not Your Turn!";
                    return false;
                }
                IsWhiteTurn = true;
                lblTurn.Text = "Current Turn: White";
                return true;
            }
        }

        void updateTheKingCoordinates(King king, int endX, int endY)
        {
            if (king.IsWhite)
            {
                whiteKingX = endX;
                whiteKingY = endY;
                return;
            }
            blackKingX = endX;
            blackKingY = endY;
        }
        void DisplayEndScreen(bool whitePlayerWon)
        {
            GameOver endScreen = new GameOver(whitePlayerWon);
            Hide(); //bad                         
            endScreen.Activate();
            endScreen.Show();
        }
        void FirstClickCode(Panel currentPanel, int firstX, int firstY)
        {
            firstClickedGrid = currentPanel.AccessibleName;
            firstX = (int)firstClickedGrid[0] - '0';
            firstY = (int)firstClickedGrid[2] - '0';
            if (board[firstX, firstY].OccupyingFigure == null)
            {
                lblOutput.Text = "No selected figure!";
                firstClickedGrid = null;
                return;
            }
            previousPanelColor = currentPanel.BackColor;
            currentPanel.BackColor = Color.GreenYellow;
            previousPanel = currentPanel;
        }
        void SecondClickCode(Panel currentPanel, int firstX, int firstY, int secondX, int secondY)
        {
            secondClickedGrid = currentPanel.AccessibleName;
            firstX = (int)firstClickedGrid[0] - '0';
            firstY = (int)firstClickedGrid[2] - '0';
            secondX = (int)secondClickedGrid[0] - '0';
            secondY = (int)secondClickedGrid[2] - '0';
            if (UnselectIfThePlayerMadeAMistake(firstX, firstY, secondX, secondY)) return;
            Figure figure = board[firstX, firstY].OccupyingFigure;
            if (ImplementTheTurns(figure, board, firstX, firstY, secondX, secondY))
            {
                if (!CheckIfTheFigureUnintentionallyCapturesTheKing(board, secondX, secondY))
                {
                    figure.Move(board, firstX, firstY, secondX, secondY);
                    if (CheckIfTheMoveWasNotPerformed(figure, board, firstX, firstY, secondX, secondY)) return;
                    if (figure is King)
                    {
                        updateTheKingCoordinates((King)figure, secondX, secondY);
                    }
                    AlertIfTheEnemyKingCouldBeCaptured(figure, board, secondX, secondY, lblOutput);
                    if (Mate.checkIfTheGameIsOver(board, blackKingX, blackKingY)) //Not optimal at all!!!
                    {
                        DisplayEndScreen(true);
                    } else if(Mate.checkIfTheGameIsOver(board, whiteKingX, whiteKingY))
                    {
                        DisplayEndScreen(false);
                    }

                }
            }
            previousPanel.BackColor = previousPanelColor;
            previousPanel = null;
            previousPanelColor = Color.Empty;
            firstClickedGrid = null;
            secondClickedGrid = null;

        }
    }
}
