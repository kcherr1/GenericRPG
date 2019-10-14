using System.IO;
using System.Windows.Forms;
using System;
using System.Drawing;

namespace GameLibrary {
  public class Map {
    private int[,] layout;
    private const int NUM_ROWS = 4;
    private const int NUM_COLS = 4;
    private const int TOP_PAD = 10;
    private const int BOUNDARY_PAD = 5;
    private const int BLOCK_SIZE = 50;

    public Character LoadMap(string mapFile, GroupBox grpMap, Func<string, Bitmap> LoadImg) {
      int top = TOP_PAD;
      int left = BOUNDARY_PAD;
      layout = new int[NUM_ROWS, NUM_COLS];
      Character character = null;
      using (FileStream fs = new FileStream(mapFile, FileMode.Open)) {
        using (StreamReader sr = new StreamReader(fs)) {
          for (int r = 0; r < NUM_ROWS; r++) {
            for (int c = 0; c < NUM_COLS; c++) {
              int val = sr.Read() - '0';
              layout[r, c] = val;
              PictureBox pb = CreateMapCell(val, LoadImg);
              if (pb != null) {
                pb.Top = top;
                pb.Left = left;
                grpMap.Controls.Add(pb);
              }
              if (val == 2) {
                character = new Character(pb, new Position(r, c), this);
              }
              left += 50;
            }
            left = BOUNDARY_PAD;
            top += 50;
            sr.ReadLine();
          }
        }
      }
      grpMap.Width = NUM_COLS * BLOCK_SIZE + BOUNDARY_PAD * 2;
      grpMap.Height = NUM_ROWS * BLOCK_SIZE + TOP_PAD + BOUNDARY_PAD;
      return character;
    }

    private PictureBox CreateMapCell(int legendValue, Func<string, Bitmap> LoadImg) {
      PictureBox result = null;
      switch (legendValue) {
        // walkable
        case 0:
          break;

        // wall
        case 1:
          result = new PictureBox() {
            BackgroundImage = LoadImg("wall"),
            BackgroundImageLayout = ImageLayout.Stretch,
            Width = BLOCK_SIZE,
            Height = BLOCK_SIZE
          };
          break;

        case 2:
          result = new PictureBox() {
            BackgroundImage = LoadImg("character"),
            BackgroundImageLayout = ImageLayout.Stretch,
            Width = BLOCK_SIZE,
            Height = BLOCK_SIZE
          };
          break;
      }
      return result;
    }

    public bool IsValidPos(Position pos) {
      if (pos.row < 0 || pos.row >= NUM_ROWS ||
          pos.col < 0 || pos.col >= NUM_COLS ||
          layout[pos.row, pos.col] == 1) {
        return false;
      }
      return true;
    }

    public Position RowColToTopLeft(Position p) {
      return new Position(p.row * BLOCK_SIZE + TOP_PAD, p.col * BLOCK_SIZE + BOUNDARY_PAD);
    }
  }
}
