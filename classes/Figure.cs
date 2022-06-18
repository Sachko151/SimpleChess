using System.Windows.Forms;

namespace Chess.classes
{
    abstract class Figure
    {

        private bool isWhite;
        public bool IsWhite { get => isWhite; set => isWhite = value; }
        public abstract void Move(Grid[,] board, int startX, int startY, int endX, int endY);
        public Figure(bool isW)
        {
            isWhite = isW;
        }
        public abstract void SetImageToGrid(Panel panel);
    }
}
