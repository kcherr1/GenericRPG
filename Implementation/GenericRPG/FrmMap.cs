using GameLibrary;
using GenericRPG.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace GenericRPG {
  public partial class FrmMap : Form {
    private Character character;
    private Map map;
    private Game game;
    public bool inCombat = false;
    private bool load;

    public FrmMap(bool l) {
      load = l;
      InitializeComponent();
    }

    private void FrmMap_Load( object sender, EventArgs e) {
      game = Game.GetGame();

      map = new Map();
      if(this.load){
        if (Directory.Exists("Resources")){
          if(File.Exists("Resources/savedmap.txt")&&File.Exists("Resources/savedcharacter.txt")){
            character = map.LoadMap("Resources/savedmap.txt", grpMap, 
              str => Resources.ResourceManager.GetObject(str) as Bitmap
            );
            character.SetStats("Resources/savedcharacter.txt");
          } else {
            character = map.LoadMap("Resources/level.txt", grpMap, 
              str => Resources.ResourceManager.GetObject(str) as Bitmap
            );
          }
        }
      } else {
        character = map.LoadMap("Resources/level.txt", grpMap, 
          str => Resources.ResourceManager.GetObject(str) as Bitmap
        );
      }
      Width = grpMap.Width + 25;
      Height = grpMap.Height + 50;
      game.SetCharacter(character);
    }
    private void FrmMap_KeyDown(object sender, KeyEventArgs e) {
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
      if (dir != MoveDir.NO_MOVE && inCombat == false) {
        character.Move(dir);
        if (game.State == GameState.FIGHTING) {
          FrmArena frmArena = new FrmArena();
          frmArena.parentForm(this);
          inCombat = true;
          frmArena.Show();
        }
      }
    }
  }
}
