using System.Windows.Forms;

namespace Chess.classes
{
    class Grid
    {
        private Figure figure;
        private bool isWhite;
        private Panel panel;
        public Panel PlayableGrid { get => panel; }
        public bool IsWhite { get => isWhite; set => isWhite = value; }
        public Figure OccupyingFigure
        {
            get => figure;
            set
            {
                figure = value;
                if (figure == null)
                {
                    panel.BackgroundImage = null;
                    return;
                }
                figure.SetImageToGrid(panel);
            }
        }
        public Grid(bool iW, Figure f, Panel p)
        {
            isWhite = iW;
            figure = f;
            panel = p;
        }
        public Grid(Panel p) : this(false, null, p)
        {

        }
    }
}
