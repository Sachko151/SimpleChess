using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Chess.classes
{
    class Rook : Figure
    {
        private Image imageWhite = Image.FromFile(@"..\..\figures\white\white_rook.png");
        private Image imageBlack = Image.FromFile(@"..\..\figures\black\black_rook.png");
        public Image WhiteFigureImage { get => imageWhite; }
        public Image BlackFigureImage { get => imageBlack; }

        public override void Move(Grid[,] board, int startX, int startY, int endX, int endY)
        {
            List<int> possibleXCoords = new List<int>();
            List<int> possibleYCoords = new List<int>();
            CheckForwardGrids(board, startX, startY, possibleXCoords);
            CheckBackwardGrids(board, startX, startY, possibleXCoords);
            CheckLeftGrids(board, startX, startY, possibleYCoords);
            CheckRightGrids(board, startX, startY, possibleYCoords);
            if (CheckIfItContainsValueAndDeleteIfNot(possibleXCoords, endX) && startY == endY)
            {
                PutTheFigureImageOnThePanelAndTheFigureObjectInTheGrid(board, startX, startY, endX, endY);

            }
            else if (CheckIfItContainsValueAndDeleteIfNot(possibleYCoords, endY) && startX == endX)
            {
                PutTheFigureImageOnThePanelAndTheFigureObjectInTheGrid(board, startX, startY, endX, endY);
            }



        }
        private void CheckForwardGrids(Grid[,] board, int startX, int startY, List<int> possibleXCoords)
        {

            for (int i = startX; i > -1; i--)
            {
                if (board[i, startY].OccupyingFigure == null)
                {
                    possibleXCoords.Add(i);
                    continue;
                }
                bool captureCondition = (board[i, startY].OccupyingFigure.IsWhite == true && this.IsWhite == false) ||
                    (board[i, startY].OccupyingFigure.IsWhite == false && this.IsWhite == true);
                if (captureCondition)
                {
                    possibleXCoords.Add(i);
                    return;
                }

            }
            return;
        }
        private bool CheckIfItContainsValueAndDeleteIfNot(List<int> listOfCoords, int coord)
        {
            if (!listOfCoords.Contains(coord))
            {
                listOfCoords.Clear();
                return false;
            }
            return true;
        }
        private void CheckBackwardGrids(Grid[,] board, int startX, int startY, List<int> possibleXCoords)
        {
            for (int i = startX; i < 8; i++)
            {
                if (board[i, startY].OccupyingFigure == null)
                {
                    possibleXCoords.Add(i);
                    continue;
                }
                bool captureCondition = (board[i, startY].OccupyingFigure.IsWhite == true && this.IsWhite == false) ||
                    (board[i, startY].OccupyingFigure.IsWhite == false && this.IsWhite == true);
                if (captureCondition)
                {
                    possibleXCoords.Add(i);
                    return;
                }

            }
            return;
        }
        private void CheckLeftGrids(Grid[,] board, int startX, int startY, List<int> possibleYCoords)
        {

            for (int i = startY; i > -1; i--)
            {
                if (board[startX, i].OccupyingFigure == null)
                {
                    possibleYCoords.Add(i);
                    continue;
                }
                bool captureCondition = (board[startX, i].OccupyingFigure.IsWhite == true && this.IsWhite == false) ||
                    (board[startX, i].OccupyingFigure.IsWhite == false && this.IsWhite == true);
                if (captureCondition)
                {
                    possibleYCoords.Add(i);
                    return;
                }

            }
            return;
        }
        private void CheckRightGrids(Grid[,] board, int startX, int startY, List<int> possibleYCoords)
        {
            for (int i = startY; i < 8; i++)
            {
                if (board[startX, i].OccupyingFigure == null)
                {
                    possibleYCoords.Add(i);
                    continue;
                }
                bool captureCondition = (board[startX, i].OccupyingFigure.IsWhite == true && this.IsWhite == false) ||
                    (board[startX, i].OccupyingFigure.IsWhite == false && this.IsWhite == true);
                if (captureCondition)
                {
                    possibleYCoords.Add(i);
                    return;
                }

            }
            return;
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
        private void PutTheFigureImageOnThePanelAndTheFigureObjectInTheGrid(Grid[,] board, int startX, int startY, int endX, int endY)
        {
            board[startX, startY].OccupyingFigure = null;
            board[endX, endY].OccupyingFigure = this;

        }
        public Rook(bool isWhite) : base(isWhite)
        {

        }
    }
}
