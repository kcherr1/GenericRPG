using GenericRPG.code;
using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericRPG {
  public partial class FrmMap : Form {
    private Character character;
    private Map map = null;

    public FrmMap() {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e) {
      //player = new Character();\
      map = new Map();
      character = map.LoadMap("Resources/level.txt", grpMap);
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e) {
      MoveDir dir = MoveDir.NO_MOVE;
      switch (e.KeyCode) {
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
        character.Move(dir);
    }
  }
}

