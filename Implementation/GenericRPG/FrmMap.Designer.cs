namespace GenericRPG {
  partial class FrmMap {
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
            this.grpMap = new System.Windows.Forms.GroupBox();
            this.pauseBox = new System.Windows.Forms.GroupBox();
            this.BtnQuit = new System.Windows.Forms.Button();
            this.BtnStats = new System.Windows.Forms.Button();
            this.BtnSaveGame = new System.Windows.Forms.Button();
            this.BtnContinue = new System.Windows.Forms.Button();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.pauseBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMap
            // 
            this.grpMap.Location = new System.Drawing.Point(66, 98);
            this.grpMap.Margin = new System.Windows.Forms.Padding(6);
            this.grpMap.Name = "grpMap";
            this.grpMap.Padding = new System.Windows.Forms.Padding(6);
            this.grpMap.Size = new System.Drawing.Size(778, 554);
            this.grpMap.TabIndex = 0;
            this.grpMap.TabStop = false;
            // 
            // pauseBox
            // 
            this.pauseBox.BackColor = System.Drawing.SystemColors.Menu;
            this.pauseBox.Controls.Add(this.BtnQuit);
            this.pauseBox.Controls.Add(this.BtnStats);
            this.pauseBox.Controls.Add(this.BtnSaveGame);
            this.pauseBox.Controls.Add(this.BtnContinue);
            this.pauseBox.Enabled = false;
            this.pauseBox.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseBox.Location = new System.Drawing.Point(1245, 209);
            this.pauseBox.Name = "pauseBox";
            this.pauseBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pauseBox.Size = new System.Drawing.Size(398, 412);
            this.pauseBox.TabIndex = 2;
            this.pauseBox.TabStop = false;
            this.pauseBox.Text = "Game Paused";
            // 
            // BtnQuit
            // 
            this.BtnQuit.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuit.Location = new System.Drawing.Point(26, 314);
            this.BtnQuit.Name = "BtnQuit";
            this.BtnQuit.Size = new System.Drawing.Size(325, 71);
            this.BtnQuit.TabIndex = 6;
            this.BtnQuit.Text = "Quit";
            this.BtnQuit.UseVisualStyleBackColor = true;
            this.BtnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
            // 
            // BtnStats
            // 
            this.BtnStats.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStats.Location = new System.Drawing.Point(26, 237);
            this.BtnStats.Name = "BtnStats";
            this.BtnStats.Size = new System.Drawing.Size(325, 71);
            this.BtnStats.TabIndex = 5;
            this.BtnStats.Text = "Show Stats";
            this.BtnStats.UseVisualStyleBackColor = true;
            // 
            // BtnSaveGame
            // 
            this.BtnSaveGame.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveGame.Location = new System.Drawing.Point(26, 160);
            this.BtnSaveGame.Name = "BtnSaveGame";
            this.BtnSaveGame.Size = new System.Drawing.Size(325, 71);
            this.BtnSaveGame.TabIndex = 4;
            this.BtnSaveGame.Text = "Save Game";
            this.BtnSaveGame.UseVisualStyleBackColor = true;
            this.BtnSaveGame.Click += new System.EventHandler(this.BtnSaveGame_Click);
            // 
            // BtnContinue
            // 
            this.BtnContinue.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnContinue.Location = new System.Drawing.Point(26, 83);
            this.BtnContinue.Name = "BtnContinue";
            this.BtnContinue.Size = new System.Drawing.Size(325, 71);
            this.BtnContinue.TabIndex = 3;
            this.BtnContinue.Text = "Continue";
            this.BtnContinue.UseVisualStyleBackColor = true;
            this.BtnContinue.Click += new System.EventHandler(this.BtnContinue_Click);
            // 
            // PauseBtn
            // 
            this.PauseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PauseBtn.Location = new System.Drawing.Point(12, 12);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(134, 52);
            this.PauseBtn.TabIndex = 4;
            this.PauseBtn.Text = "Pause";
            this.PauseBtn.UseVisualStyleBackColor = true;
            this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // FrmMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1996, 1017);
            this.Controls.Add(this.PauseBtn);
            this.Controls.Add(this.pauseBox);
            this.Controls.Add(this.grpMap);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FrmMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map";
            this.Load += new System.EventHandler(this.FrmMap_Load);
            this.pauseBox.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.GroupBox grpMap;
        private System.Windows.Forms.GroupBox pauseBox;
        private System.Windows.Forms.Button BtnStats;
        private System.Windows.Forms.Button BtnSaveGame;
        private System.Windows.Forms.Button BtnContinue;
        private System.Windows.Forms.Button BtnQuit;
        private System.Windows.Forms.Button PauseBtn;
    }
}

