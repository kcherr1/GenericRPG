using GameLibrary;
using GenericRPG.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GenericRPG
{
    public partial class FrmMap : Form
    {
        private Character character;
        private Map map;
        private Game game;

        public FrmMap()
        {
            InitializeComponent();
        }

        private void FrmMap_Load(object sender, EventArgs e)
        {
            game = Game.GetGame();

            map = new Map();
            character = map.LoadMap("Resources/level1.txt", grpMap,
              str => Resources.ResourceManager.GetObject(str) as Bitmap
            );
            Width = grpMap.Width + 25;
            Height = grpMap.Height + 50;
            game.SetCharacter(character);
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            MoveDir dir = MoveDir.NO_MOVE;
            switch (keyData)
            {
                case Keys.Left:
                    dir = MoveDir.LEFT;
                    break;
                case Keys.Right:
                    dir = MoveDir.RIGHT;
                    break;
                case Keys.Up:
                    dir = MoveDir.UP;
                    break;
                case Keys.Down:
                    dir = MoveDir.DOWN;
                    break;
            }

            if (dir != MoveDir.NO_MOVE)
            {
                if(game.State == GameState.ON_MAP)
                {
                    character.Move(dir);
                }

                if (game.State == GameState.FIGHTING)
                {
                    FrmArena frmArena = new FrmArena();
                    frmArena.Show();
                }
            }
            return base.ProcessDialogKey(keyData);
        }
        /*private void FrmMap_KeyDown(object sender, KeyEventArgs e)
        {
            MoveDir dir = MoveDir.NO_MOVE;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    dir = MoveDir.LEFT;
                    break;
                case Keys.Right:
                    dir = MoveDir.RIGHT;
                    break;
                case Keys.Up:
                    dir = MoveDir.UP;
                    break;
                case Keys.Down:
                    dir = MoveDir.DOWN;
                    break;
            }
            if (game.State == GameState.ON_MAP && dir != MoveDir.NO_MOVE)
            {
                character.Move(dir);
                if (game.State == GameState.FIGHTING)
                {
                    FrmArena frmArena = new FrmArena();
                    frmArena.Show();
                }
            }
        }
        */

        private void PauseBtn_Click(object sender, EventArgs e)
        {
            game.ChangeState(GameState.PAUSED);

            // show the pause menu
            pauseBox.Location = new Point(
                this.Width / 2 - pauseBox.Width / 2,
                this.Height / 2 - pauseBox.Height / 2
                );
            pauseBox.Show();

            pauseBox.Enabled = true;
            PauseBtn.Hide();
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            if (game.State == GameState.PAUSED)
            {
                // hide the pause menu
                pauseBox.Hide();
                pauseBox.Enabled = false;

                PauseBtn.Show();

                game.ChangeState(GameState.ON_MAP);
            }
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            Game.GetGame().ChangeState(GameState.MAIN_MENU);

            this.Close();
        }
    }
}
