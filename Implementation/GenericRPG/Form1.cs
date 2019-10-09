using GenericRPG.code;
using GenericRPG.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericRPG {
  public partial class Form1 : Form {
    private Character player;

    public Form1() {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e) {
      player = new Character();
      picCharacter.BackgroundImageLayout = ImageLayout.Stretch;
      picCharacter.BackgroundImage = Resources.character;
    }
  }
}
