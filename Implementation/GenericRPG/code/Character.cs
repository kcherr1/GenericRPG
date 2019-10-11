using System.Windows.Forms;

namespace GenericRPG.code {
  public struct Position {
    public int row;
    public int col;

    public Position(int row, int col) {
      this.row = row;
      this.col = col;
    }
  }

  public class Character {
    public PictureBox Pic { get; private set; }
    private Position pos;
    private Map map;

    public Character(PictureBox pb, Position pos, Map map) {
      Pic = pb;
      this.pos = pos;
      this.map = map;
    }

    public void Move(MoveDir dir) {
      Position newPos = pos;
      switch (dir) {
        case MoveDir.UP:
          newPos.row--;
          break;
        case MoveDir.DOWN:
          newPos.row++;
          break;
        case MoveDir.LEFT:
          newPos.col--;
          break;
        case MoveDir.RIGHT:
          newPos.col++;
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
