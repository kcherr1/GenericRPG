using GameLibrary;
using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

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

        // only one game save for now.
        private void btnLoadGame_Click(object sender, EventArgs e)
        {
            // load json string from file
            string gameSave = File.ReadAllText(@"save1.txt");

            // create blank game
            FrmMap frmMap = new FrmMap();
            frmMap.FormClosing += delegate { this.Show(); };

            //load game into blank
            frmMap.LoadGame(gameSave);


            // play
            Game.GetGame().ChangeState(GameState.ON_MAP);
            frmMap.Show();
            Hide();
        }
    }
}
