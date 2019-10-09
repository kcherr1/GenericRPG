namespace GenericRPG {
  partial class Form1 {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.picCharacter = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.picCharacter)).BeginInit();
      this.SuspendLayout();
      // 
      // picCharacter
      // 
      this.picCharacter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
      this.picCharacter.Location = new System.Drawing.Point(33, 211);
      this.picCharacter.Name = "picCharacter";
      this.picCharacter.Size = new System.Drawing.Size(114, 110);
      this.picCharacter.TabIndex = 0;
      this.picCharacter.TabStop = false;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(998, 529);
      this.Controls.Add(this.picCharacter);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.picCharacter)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox picCharacter;
  }
}

