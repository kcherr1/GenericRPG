using GameLibrary;
using System;
using System.Windows.Forms;

namespace GenericRPG
{
    public partial class FrmMainMenu : Form
    {

        public FrmMainMenu()
        {
            InitializeComponent();
        }

        private void FrmMainMenu_Load(object sender, EventArgs e)
        {
            Game.GetGame().ChangeState(GameState.MAIN_MENU);
        }

        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            Game.GetGame().ChangeState(GameState.ON_MAP);

            FrmMap frmMap = new FrmMap();
            frmMap.FormClosing += delegate { this.Show(); };

            frmMap.Show();
            Hide();
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
