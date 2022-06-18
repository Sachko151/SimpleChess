using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chess.classes
{
    class King : Figure
    {
        private Image imageWhite = Image.FromFile(@"..\..\figures\white\white_king.png");
        private Image imageBlack = Image.FromFile(@"..\..\figures\black\black_king.png");

        public Image WhiteFigureImage { get => imageWhite; }
        public Image BlackFigureImage { get => imageBlack; }
        //x == i y == j
        public override void Move(Grid[,] board, int startX, int startY, int endX, int endY)
        {
            if (startX < 0 || endY < 0 || endX < 0 || endY < 0)
            {
                return;
            }
            bool moveCondition = false;
            for (int i = startX - 1; i < startX + 2; i++)
            {
                for (int j = startY - 1; j < startY + 2; j++)
                {
                    if (i == endX && j == endY && board[i, j].OccupyingFigure == null)
                    {
                        moveCondition = true;
                        break;
                    }
                    else if (i == endX && j == endY && board[i, j].OccupyingFigure != null)
                    {
                        if (board[i, j].OccupyingFigure.IsWhite == true && this.IsWhite == false ||
                            board[i, j].OccupyingFigure.IsWhite == false && this.IsWhite == true)
                        {
                            moveCondition = true;
                            break;
                        }
                    }
                }
            }
            if (moveCondition)
            {
                PutTheFigureImageOnThePanelAndTheFigureObjectInTheGrid(board, startX, startY, endX, endY);
            }
        }
        public King(bool isWhite) : base(isWhite)
        {

        }
        public void Captured()
        {
            string color = (IsWhite) ? "White" : "Black";
            throw new Exception($"The {color} king has been captured!");
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
    }
}
