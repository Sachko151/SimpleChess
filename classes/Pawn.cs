using System.Drawing;
using System.Windows.Forms;

namespace Chess.classes
{
    class Pawn : Figure
    {
        private bool firstMove = true;
        private Image imageWhite = Image.FromFile(@"..\..\figures\white\white_pawn.png");
        private Image imageBlack = Image.FromFile(@"..\..\figures\black\black_pawn.png");
        public bool FirstMove { get => firstMove; set => firstMove = value; }
        public Image WhiteFigureImage { get => imageWhite; }
        public Image BlackFigureImage { get => imageBlack; }
        public override void Move(Grid[,] board, int startX, int startY, int endX, int endY)
        {
            if (IsWhite)
            {
                if (HasFirstMovedByTwoSquaresWhite(board, startX, startY, endX, endY))
                {
                    PutTheFigureImageOnThePanelAndTheFigureObjectInTheGrid(board, startX, startY, endX, endY);

                    return;
                }
                if (StandardMoveWhite(board, startX, startY, endX, endY))
                {
                    PutTheFigureImageOnThePanelAndTheFigureObjectInTheGrid(board, startX, startY, endX, endY);


                    return;
                }
                if (CaptureWhite(board, startX, startY, endX, endY))
                {
                    PutTheFigureImageOnThePanelAndTheFigureObjectInTheGrid(board, startX, startY, endX, endY);

                    return;
                }
                return;
            }
            //Black Pawn Logic
            if (HasFirstMovedByTwoSquaresBlack(board, startX, startY, endX, endY))
            {
                PutTheFigureImageOnThePanelAndTheFigureObjectInTheGrid(board, startX, startY, endX, endY);

                return;
            }
            if (StandardMoveBlack(board, startX, startY, endX, endY))
            {
                PutTheFigureImageOnThePanelAndTheFigureObjectInTheGrid(board, startX, startY, endX, endY);

                return;
            }
            if (CaptureBlack(board, startX, startY, endX, endY))
            {
                PutTheFigureImageOnThePanelAndTheFigureObjectInTheGrid(board, startX, startY, endX, endY);

                return;
            }


            return;

        }


        private bool HasFirstMovedByTwoSquaresWhite(Grid[,] board, int startX, int startY, int endX, int endY)
        {

            bool condition = endX == startX - 2 && startY == endY && board[startX - 1, startY].OccupyingFigure == null && board[startX - 2, startY].OccupyingFigure == null;
            if (!firstMove)
            {
                return false;
            }
            return condition;
        }
        private bool StandardMoveWhite(Grid[,] board, int startX, int startY, int endX, int endY)
        {
            bool condition = endX == startX - 1 && startY == endY && board[startX - 1, startY].OccupyingFigure == null;

            return condition;
        }
        private bool CaptureWhite(Grid[,] board, int startX, int startY, int endX, int endY)
        {

            if (board[endX, endY].OccupyingFigure == null)
            {
                return false;
            }
            bool condition = endX == startX - 1 && (startY + 1 == endY || startY - 1 == endY) && board[endX, endY].OccupyingFigure.IsWhite == false;

            return condition;
        }

        private bool HasFirstMovedByTwoSquaresBlack(Grid[,] board, int startX, int startY, int endX, int endY)
        {

            bool condition = endX == startX + 2 && startY == endY && board[startX + 1, startY].OccupyingFigure == null && board[startX + 2, startY].OccupyingFigure == null;
            if (!firstMove)
            {
                return false;
            }

            return condition;
        }
        private bool StandardMoveBlack(Grid[,] board, int startX, int startY, int endX, int endY)
        {
            bool condition = endX == startX + 1 && startY == endY && board[startX + 1, startY].OccupyingFigure == null;

            return condition;
        }
        private bool CaptureBlack(Grid[,] board, int startX, int startY, int endX, int endY)
        {
            if (board[endX, endY].OccupyingFigure == null)
            {
                return false;
            }
            bool condition = endX == startX + 1 && (startY + 1 == endY || startY - 1 == endY) && board[endX, endY].OccupyingFigure.IsWhite == true;

            return condition;
        }

        private void PutTheFigureImageOnThePanelAndTheFigureObjectInTheGrid(Grid[,] board, int startX, int startY, int endX, int endY)
        {
            board[startX, startY].OccupyingFigure = null;
            board[endX, endY].OccupyingFigure = this;
            TransformThePawnIntoAQueenIfItReachesTheEndOfTheBoard(board, endX, endY);
            firstMove = false;

        }

        public override void SetImageToGrid(Panel panel)
        {
            if (IsWhite)
            {
                panel.BackgroundImage = WhiteFigureImage;
                return;
            }
            panel.BackgroundImage = BlackFigureImage;
        }

        public Pawn(bool isW) : base(isW)
        {

        }
        private void TransformThePawnIntoAQueenIfItReachesTheEndOfTheBoard(Grid[,] board, int endX, int endY)
        {
            if (IsWhite)
            {
                if (endX == 0)
                {
                    board[endX, endY].OccupyingFigure = new Queen(true);
                }
                return;
            }
            if (endX == 7)
            {
                board[endX, endY].OccupyingFigure = new Queen(false);
            }
        }
    }
}
