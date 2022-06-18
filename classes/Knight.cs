using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Chess.classes
{
    class Knight : Figure
    {
        private Image imageWhite = Image.FromFile(@"..\..\figures\white\white_knight.png");
        private Image imageBlack = Image.FromFile(@"..\..\figures\black\black_knight.png");
        public Image WhiteFigureImage { get => imageWhite; }
        public Image BlackFigureImage { get => imageBlack; }
        public override void Move(Grid[,] board, int startX, int startY, int endX, int endY)
        {
            List<int> possiblCoordsX = new List<int>();
            List<int> possibleCoordsY = new List<int>();

            MoveUpAndCheckLeftAndRightPositions(board, startX, startY, endX, endY, possiblCoordsX, possibleCoordsY);
            MoveDownAndCheckLeftAndRightPositions(board, startX, startY, endX, endY, possiblCoordsX, possibleCoordsY);
            MoveLeftAndCheckUpAndDownPositions(board, startX, startY, endX, endY, possiblCoordsX, possibleCoordsY);
            MoveRightAndCheckUpAndDownPositions(board, startX, startY, endX, endY, possiblCoordsX, possibleCoordsY);

            if (possiblCoordsX.Contains(endX) && possibleCoordsY.Contains(endY))
            {
                PutTheFigureImageOnThePanelAndTheFigureObjectInTheGrid(board, startX, startY, endX, endY);
            }
        }

        private void MoveDownAndCheckLeftAndRightPositions(Grid[,] board, int startX, int startY, int endX, int endY, List<int> possibleCoordsX, List<int> PossibleCoordsY)
        {
            bool buggedCondition1 = (startX + 1 == endX && startY + 1 == endY) || (startX - 1 == endX && startY - 1 == endY) || (startX + 1 == endX && startY - 1 == endY) || (startX - 1 == endX && startY + 1 == endY);
            bool buggedCondition2 = (startX + 2 == endX && startY + 2 == endY) || (startX - 2 == endX && startY - 2 == endY) || (startX + 2 == endX && startY - 2 == endY) || (startX - 2 == endX && startY + 2 == endY);
            if (buggedCondition1 || buggedCondition2)
            {
                return;
            }
            try
            {
                if (board[startX + 2, startY - 1].OccupyingFigure == null)
                {


                    possibleCoordsX.Add(startX + 2);
                    PossibleCoordsY.Add(startY - 1);
                }
                else
                {
                    bool captureConditionLeft = board[startX + 2, startY - 1].OccupyingFigure.IsWhite == true && this.IsWhite == false || board[startX + 2, startY - 1].OccupyingFigure.IsWhite == false && this.IsWhite == true;
                    if (captureConditionLeft)
                    {

                        possibleCoordsX.Add(startX + 2);
                        PossibleCoordsY.Add(startY - 1);
                    }
                }
                if (board[startX + 2, startY + 1].OccupyingFigure == null)
                {

                    possibleCoordsX.Add(startX + 2);
                    PossibleCoordsY.Add(startY + 1);
                }
                else
                {
                    bool captureConditionRight = board[startX + 2, startY + 1].OccupyingFigure.IsWhite == true && this.IsWhite == false || board[startX + 2, startY + 1].OccupyingFigure.IsWhite == false && this.IsWhite == true;
                    if (captureConditionRight)
                    {
                        possibleCoordsX.Add(startX + 2);
                        PossibleCoordsY.Add(startY + 1);
                    }
                }


            }
            catch (System.Exception)
            {

                return;
            }

        }
        private void MoveUpAndCheckLeftAndRightPositions(Grid[,] board, int startX, int startY, int endX, int endY, List<int> possibleCoordsX, List<int> PossibleCoordsY)
        {
            bool buggedCondition1 = (startX + 1 == endX && startY + 1 == endY) || (startX - 1 == endX && startY - 1 == endY) || (startX + 1 == endX && startY - 1 == endY) || (startX - 1 == endX && startY + 1 == endY);
            bool buggedCondition2 = (startX + 2 == endX && startY + 2 == endY) || (startX - 2 == endX && startY - 2 == endY) || (startX + 2 == endX && startY - 2 == endY) || (startX - 2 == endX && startY + 2 == endY);
            if (buggedCondition1 || buggedCondition2)
            {
                return;
            }
            try
            {
                if (board[startX - 2, startY - 1].OccupyingFigure == null)
                {


                    possibleCoordsX.Add(startX - 2);
                    PossibleCoordsY.Add(startY - 1);
                }
                else
                {
                    bool captureConditionLeft = board[startX - 2, startY - 1].OccupyingFigure.IsWhite == true && this.IsWhite == false || board[startX - 2, startY - 1].OccupyingFigure.IsWhite == false && this.IsWhite == true;
                    if (captureConditionLeft)
                    {

                        possibleCoordsX.Add(startX - 2);
                        PossibleCoordsY.Add(startY - 1);
                    }
                }
                if (board[startX - 2, startY + 1].OccupyingFigure == null)
                {


                    possibleCoordsX.Add(startX - 2);
                    PossibleCoordsY.Add(startY + 1);
                }
                else
                {
                    bool captureConditionRight = board[startX - 2, startY + 1].OccupyingFigure.IsWhite == true && this.IsWhite == false || board[startX - 2, startY + 1].OccupyingFigure.IsWhite == false && this.IsWhite == true;
                    if (captureConditionRight)
                    {
                        possibleCoordsX.Add(startX - 2);
                        PossibleCoordsY.Add(startY + 1);
                    }


                }

            }
            catch (System.Exception)
            {

                return;
            }

        }
        private void MoveLeftAndCheckUpAndDownPositions(Grid[,] board, int startX, int startY, int endX, int endY, List<int> possibleCoordsX, List<int> PossibleCoordsY)
        {
            bool buggedCondition1 = (startX + 1 == endX && startY + 1 == endY) || (startX - 1 == endX && startY - 1 == endY) || (startX + 1 == endX && startY - 1 == endY) || (startX - 1 == endX && startY + 1 == endY);
            bool buggedCondition2 = (startX + 2 == endX && startY + 2 == endY) || (startX - 2 == endX && startY - 2 == endY) || (startX + 2 == endX && startY - 2 == endY) || (startX - 2 == endX && startY + 2 == endY);
            if (buggedCondition1 || buggedCondition2)
            {
                return;
            }
            try
            {
                if (board[startX - 1, startY - 2].OccupyingFigure == null)
                {


                    possibleCoordsX.Add(startX - 1);
                    PossibleCoordsY.Add(startY - 2);
                }
                else
                {
                    bool captureConditionUp = board[startX - 1, startY - 2].OccupyingFigure.IsWhite == true && this.IsWhite == false || board[startX - 1, startY - 2].OccupyingFigure.IsWhite == false && this.IsWhite == true;

                    if (captureConditionUp)
                    {

                        possibleCoordsX.Add(startX - 1);
                        PossibleCoordsY.Add(startY - 2);
                    }
                }

                if (board[startX + 1, startY - 2].OccupyingFigure == null)
                {

                    possibleCoordsX.Add(startX + 1);
                    PossibleCoordsY.Add(startY - 2);
                }
                else
                {
                    bool captureConditionDown = board[startX + 1, startY - 2].OccupyingFigure.IsWhite == true && this.IsWhite == false || board[startX + 1, startY - 2].OccupyingFigure.IsWhite == false && this.IsWhite == true;

                    if (captureConditionDown)
                    {
                        possibleCoordsX.Add(startX + 1);
                        PossibleCoordsY.Add(startY - 2);
                    }
                }

            }
            catch (System.Exception)
            {

                return;
            }

        }
        private void MoveRightAndCheckUpAndDownPositions(Grid[,] board, int startX, int startY, int endX, int endY, List<int> possibleCoordsX, List<int> PossibleCoordsY)
        {

            bool buggedCondition1 = (startX + 1 == endX && startY + 1 == endY) || (startX - 1 == endX && startY - 1 == endY) || (startX + 1 == endX && startY - 1 == endY) || (startX - 1 == endX && startY + 1 == endY);
            bool buggedCondition2 = (startX + 2 == endX && startY + 2 == endY) || (startX - 2 == endX && startY - 2 == endY) || (startX + 2 == endX && startY - 2 == endY) || (startX - 2 == endX && startY + 2 == endY);
            if (buggedCondition1 || buggedCondition2)
            {
                return;
            }
            try
            {
                if (board[startX - 1, startY + 2].OccupyingFigure == null)
                {


                    possibleCoordsX.Add(startX - 1);
                    PossibleCoordsY.Add(startY + 2);
                }
                else
                {
                    bool captureConditionUp = board[startX - 1, startY + 2].OccupyingFigure.IsWhite == true && this.IsWhite == false || board[startX - 1, startY + 2].OccupyingFigure.IsWhite == false && this.IsWhite == true;
                    if (captureConditionUp)
                    {

                        possibleCoordsX.Add(startX - 1);
                        PossibleCoordsY.Add(startY + 2);
                    }
                }
                if (board[startX + 1, startY + 2].OccupyingFigure == null)
                {

                    possibleCoordsX.Add(startX + 1);
                    PossibleCoordsY.Add(startY + 2);
                }
                else
                {
                    bool captureConditionDown = board[startX + 1, startY + 2].OccupyingFigure.IsWhite == true && this.IsWhite == false || board[startX + 1, startY + 2].OccupyingFigure.IsWhite == false && this.IsWhite == true;

                    if (captureConditionDown)
                    {
                        possibleCoordsX.Add(startX + 1);
                        PossibleCoordsY.Add(startY + 2);
                    }
                }

            }
            catch (System.Exception)
            {
                return;
            }

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
        public Knight(bool isWhite) : base(isWhite)
        {

        }

    }
}
