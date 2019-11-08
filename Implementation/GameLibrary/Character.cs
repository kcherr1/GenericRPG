using System.Windows.Forms;
using System.Media;

namespace GameLibrary {
  public struct Position {
    public int row;
    public int col;

    /// <summary>
    /// Construct a new 2D position
    /// </summary>
    /// <param name="row">Given row or y value</param>
    /// <param name="col">Given col or x value</param>
    public Position(int row, int col) {
      this.row = row;
      this.col = col;
    }
  }

  /// <summary>
  /// This represents our player in our game
  /// </summary>
  public class Character : Mortal {
    public PictureBox Pic { get; private set; }
    private Position pos;
    private Map map;
    public float XP { get; private set; }
    public bool ShouldLevelUp { get; private set; }
    public string currentAtt {get; protected set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pb"></param>
    /// <param name="pos"></param>
    /// <param name="map"></param>
    public Character(PictureBox pb, Position pos, Map map) : base("Player 1", 1) {
      Pic = pb;
      this.pos = pos;
      this.map = map;
      ShouldLevelUp = false;
    }

    public void GainXP(float amount) {
      XP += amount;

      // every 100 experience points you gain a level
      if ((int)XP / 100 >= Level) {
        ShouldLevelUp = true;
      }
    }

    public override void LevelUp() {
      base.LevelUp();
      ShouldLevelUp = false;

    }

    public void BackToStart() {
      pos.row = map.CharacterStartRow;
      pos.col = map.CharacterStartCol;
      Position topleft = map.RowColToTopLeft(pos);
      Pic.Left = topleft.col;
      Pic.Top = topleft.row;
    }
    
    public override void ResetStats() {
      base.ResetStats();
      XP = 0;
      LevelExp = 0;
    }
        public void ResetStats2()
        {
            base.ResetStats();
            XP = this.LevelExp;
        }

        public void Move(MoveDir dir) {
            SoundPlayer sp = new SoundPlayer(@"C:\Users\Layne\Desktop\GenericRPG_TeamMagenta-master\GenericRPG_TeamMagenta-master\Implementation\GenericRPG\Resources\step.wav");
            Position newPos = pos;
      switch (dir) {
        case MoveDir.UP:
          newPos.row--;
                    sp.Play();
                    break;
        case MoveDir.DOWN:
          newPos.row++;
                    sp.Play();
                    break;
        case MoveDir.LEFT:
          newPos.col--;
                    sp.Play();
                    break;
        case MoveDir.RIGHT:
          newPos.col++;
                    sp.Play();
                    break;
      }
      if (map.IsValidPos(newPos)) {
        pos = newPos;
        Position topleft = map.RowColToTopLeft(pos);
        Pic.Left = topleft.col;
        Pic.Top = topleft.row;
      }
    }
  }
}
