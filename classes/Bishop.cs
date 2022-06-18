using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Chess.classes
{
    class Bishop : Figure
    {
        private Image imageWhite = Image.FromFile(@"..\..\figures\white\white_bishop.png");
        private Image imageBlack = Image.FromFile(@"..\..\figures\black\black_bishop.png");
        public Image WhiteFigureImage { get => imageWhite; }
        public Image BlackFigureImage { get => imageBlack; }

        public override void Move(Grid[,] board, int startX, int startY, int endX, int endY)
        {
            List<int> possibleXCoords = new List<int>();
            List<int> possibleYCoords = new List<int>();
            if (CheckForwardLeftDiagonal(board, startX, startY, possibleXCoords, possibleYCoords, endX, endY) ||
                CheckForwardRightDiagonal(board, startX, startY, possibleXCoords, possibleYCoords, endX, endY) ||
                CheckDownwardRightDiagonal(board, startX, startY, possibleXCoords, possibleYCoords, endX, endY) ||
                 CheckDownwardLeftDiagonal(board, startX, startY, possibleXCoords, possibleYCoords, endX, endY))
            {
                PutTheFigureImageOnThePanelAndTheFigureObjectInTheGrid(board, startX, startY, endX, endY);
            }





        }
        private bool CheckForwardLeftDiagonal(Grid[,] board, int startX, int startY, List<int> possibleXCoords, List<int> possibleYCoords, int endX, int endY)
        {
            while (true)
            {
                if (startX > 0 && startY > 0 && board[startX - 1, startY - 1].OccupyingFigure == null)
                {
                    possibleXCoords.Add(--startX);
                    possibleYCoords.Add(--startY);
                    if (possibleXCoords.Contains(endX) && possibleYCoords.Contains(endY))
                    {

                        return true;
                    }
                    else
                    {
                        possibleXCoords.Clear();
                        possibleYCoords.Clear();
                    }
                    continue;
                }
                else
                {
                    if (startX <= 0 || startY <= 0)
                    {
                        break;
                    }
                    try
                    {
                        if (board[startX - 1, startY - 1].OccupyingFigure.IsWhite == true && this.IsWhite == false || board[startX - 1, startY - 1].OccupyingFigure.IsWhite == false && this.IsWhite == true)
                        {
                            possibleXCoords.Add(--startX);
                            possibleYCoords.Add(--startY);
                            if (possibleXCoords.Contains(endX) && possibleYCoords.Contains(endY))
                            {

                                return true;
                            }
                            else
                            {
                                possibleXCoords.Clear();
                                possibleYCoords.Clear();
                            }
                            break;
                        }
                        break;
                    }
                    catch (System.Exception)
                    {

                        return false;
                    }


                }
            }
            return false;
        }
        private bool CheckForwardRightDiagonal(Grid[,] board, int startX, int startY, List<int> possibleXCoords, List<int> possibleYCoords, int endX, int endY)
        {
            while (true)
            {
                if (startX > 0 && startY < 7 && board[startX - 1, startY + 1].OccupyingFigure == null)
                {
                    possibleXCoords.Add(--startX);
                    possibleYCoords.Add(++startY);
                    if (possibleXCoords.Contains(endX) && possibleYCoords.Contains(endY))
                    {

                        return true;
                    }
                    else
                    {
                        possibleXCoords.Clear();
                        possibleYCoords.Clear();
                    }
                    continue;
                }
                else
                {
                    if (startX <= 0 || startY >= 7)
                    {
                        break;
                    }
                    try
                    {
                        if (board[startX - 1, startY + 1].OccupyingFigure.IsWhite == true && this.IsWhite == false || board[startX - 1, startY + 1].OccupyingFigure.IsWhite == false && this.IsWhite == true)
                        {
                            possibleXCoords.Add(--startX);
                            possibleYCoords.Add(++startY);
                            if (possibleXCoords.Contains(endX) && possibleYCoords.Contains(endY))
                            {

                                return true;
                            }
                            else
                            {
                                possibleXCoords.Clear();
                                possibleYCoords.Clear();
                            }
                            break;
                        }
                        break;
                    }
                    catch (System.Exception)
                    {

                        return false;
                    }
                }

            }
            return false;
        }
        private bool CheckDownwardLeftDiagonal(Grid[,] board, int startX, int startY, List<int> possibleXCoords, List<int> possibleYCoords, int endX, int endY)
        {
            while (true)
            {
                if (startX < 7 && startY > 0 && board[startX + 1, startY - 1].OccupyingFigure == null)
                {
                    possibleXCoords.Add(++startX);
                    possibleYCoords.Add(--startY);
                    if (possibleXCoords.Contains(endX) && possibleYCoords.Contains(endY))
                    {

                        return true;
                    }
                    else
                    {
                        possibleXCoords.Clear();
                        possibleYCoords.Clear();
                    }
                    continue;
                }
                else
                {
                    if (startX >= 7 || startY <= 0)
                    {
                        break;
                    }
                    try
                    {
                        if (board[startX + 1, startY - 1].OccupyingFigure.IsWhite == true && this.IsWhite == false || board[startX + 1, startY - 1].OccupyingFigure.IsWhite == false && this.IsWhite == true)
                        {
                            possibleXCoords.Add(++startX);
                            possibleYCoords.Add(--startY);
                            if (possibleXCoords.Contains(endX) && possibleYCoords.Contains(endY))
                            {

                                return true;
                            }
                            else
                            {
                                possibleXCoords.Clear();
                                possibleYCoords.Clear();
                            }
                            break;
                        }
                        break;
                    }
                    catch (System.Exception)
                    {

                        return false;
                    }
                }

            }
            return false;
        }
        private bool CheckDownwardRightDiagonal(Grid[,] board, int startX, int startY, List<int> possibleXCoords, List<int> possibleYCoords, int endX, int endY)
        {
            while (true)
            {
                if (startX < 7 && startY < 7 && board[startX + 1, startY + 1].OccupyingFigure == null)
                {
                    possibleXCoords.Add(++startX);
                    possibleYCoords.Add(++startY);
                    if (possibleXCoords.Contains(endX) && possibleYCoords.Contains(endY))
                    {

                        return true;
                    }
                    else
                    {
                        possibleXCoords.Clear();
                        possibleYCoords.Clear();
                    }
                    continue;
                }
                else
                {
                    if (startX >= 7 || startY >= 7)
                    {
                        break;
                    }
                    try
                    {
                        if (board[startX + 1, startY + 1].OccupyingFigure.IsWhite == true && this.IsWhite == false || board[startX + 1, startY + 1].OccupyingFigure.IsWhite == false && this.IsWhite == true)
                        {
                            possibleXCoords.Add(++startX);
                            possibleYCoords.Add(++startY);
                            if (possibleXCoords.Contains(endX) && possibleYCoords.Contains(endY))
                            {

                                return true;
                            }
                            else
                            {
                                possibleXCoords.Clear();
                                possibleYCoords.Clear();
                            }
                            break;
                        }
                        break;
                    }
                    catch (System.Exception)
                    {

                        return false;
                    }
                }
            }

            return false;
        }
        private void PutTheFigureImageOnThePanelAndTheFigureObjectInTheGrid(Grid[,] board, int startX, int startY, int endX, int endY)
        {
            board[startX, startY].OccupyingFigure = null;
            board[endX, endY].OccupyingFigure = this;

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

        public Bishop(bool isW) : base(isW)
        {

        }
    }
}
