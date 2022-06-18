using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class GameOver : Form
    {
        public GameOver(bool whiteWon)
        {
            InitializeComponent();
            if (whiteWon)
            {
                lblWin.Text = "White Player Won!";
            } else
            {
                lblWin.Text = "Black Player Won!";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Form1 mainGame = new Form1();
            mainGame.Activate();
            mainGame.Show();
            Close();
        }
    }
}
