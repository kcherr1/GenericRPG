using GameLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            Game.GetGame().ChangeState(GameState.ON_MAP);

            FrmMap map = new FrmMap();
            map.FormClosing += delegate { this.Show(); };
            map.Show();
            Hide();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            List<Form> openForms = new List<Form>();
            foreach (Form frm in Application.OpenForms)
            {
                openForms.Add(frm);
            }
            foreach (Form openForm in openForms)
            {
                if (openForm != this)
                    openForm.Close();
            }
            Application.Exit();
        }
    }
}
