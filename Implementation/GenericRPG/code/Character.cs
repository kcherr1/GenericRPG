using GenericRPG.Properties;
using System.Drawing;

namespace GenericRPG.code {
  public class Character {
    public  Bitmap Img { get; private set; }

    public Character() {
      Img = Resources.character;
    }
  }
}
