using GameLibrary;
using GenericRPG.Properties;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GenericRPG {
  public partial class FrmArena : Form {
    private Game game;
    private Character character;
    private Enemy enemy;
    private Random rand;
    private string enemyAtt = "";

    public FrmArena() {
      InitializeComponent();
    }
    private void btnEndFight_Click(object sender, EventArgs e) {
      EndFight();
    }
    private void EndFight() {
      Game.GetGame().ChangeState(GameState.ON_MAP);
      Close();
    }
    private void FrmArena_Load(object sender, EventArgs e) {
      rand = new Random();

      game = Game.GetGame();
      character = game.Character;
      enemy = new Enemy(rand.Next(character.Level + 1), Resources.enemy);

      // stats
      UpdateStats();

      // pictures
      picCharacter.BackgroundImage = character.Pic.BackgroundImage;
      picEnemy.BackgroundImage = enemy.Img;

      // names
      lblPlayerName.Text = character.Name;
      lblEnemyName.Text = enemy.Name;
    }
    public void UpdateStats() {
      lblPlayerLevel.Text = character.Level.ToString();
      lblPlayerHealth.Text = Math.Round(character.Health).ToString();
      lblPlayerStr.Text = Math.Round(character.Str).ToString();
      lblPlayerDef.Text = Math.Round(character.Def).ToString();
      lblPlayerMana.Text = Math.Round(character.Mana).ToString();
      lblPlayerXp.Text = Math.Round(character.XP).ToString();

      lblEnemyLevel.Text = enemy.Level.ToString();
      lblEnemyHealth.Text = Math.Round(enemy.Health).ToString();
      lblEnemyStr.Text = Math.Round(enemy.Str).ToString();
      lblEnemyDef.Text = Math.Round(enemy.Def).ToString();
      //lblEnemyMana.Text = Math.Round(enemy.Mana).ToString();

      lblPlayerHealth.Text = Math.Round(character.Health).ToString();
      lblEnemyHealth.Text = Math.Round(enemy.Health).ToString();
    }
    private string randomAtt() {
      int attNum  = this.rand.Next(1, 4);
      string att = "";
      if (attNum == 1) {
        att = "LA";
        lblEnemyMana.Text = "Light Attack";
      }
      else if (attNum == 2) {
        att = "HA";
        lblEnemyMana.Text = "Heavy Attack";
      }
      else if (attNum == 3) {
        att = "P";
        lblEnemyMana.Text = "Parry";
      }
      else return "oops";
      return att;
    }
    private void lose() {
      float prevPlayerHealth = character.Health;
        enemy.SimpleAttack(character);
        float playerDamage = (float)Math.Round(prevPlayerHealth - character.Health);
        // display the damage
        lblPlayerDamage.Text = playerDamage.ToString();
        lblPlayerDamage.Visible = true;
        tmrPlayerDamage.Enabled = true;
    }
    private void win() {
      float prevEnemyHealth = enemy.Health;
        character.SimpleAttack(enemy);
        float enemyDamage = (float)Math.Round(prevEnemyHealth - enemy.Health);
        // display the damage
        lblEnemyDamage.Text = enemyDamage.ToString();
        lblEnemyDamage.Visible = true;
        tmrEnemyDamage.Enabled = true;
    }
    private void enemyDies() {
      character.GainXP(enemy.XpDropped);
        lblEndFightMessage.Text = "You Gained " + Math.Round(enemy.XpDropped) + " xp!";
        lblEndFightMessage.Visible = true;
        Refresh();
        Thread.Sleep(1200);
        EndFight();
        if (character.ShouldLevelUp) {
          FrmLevelUp frmLevelUp = new FrmLevelUp();
          frmLevelUp.Show();
        }
    }
    private void playerDies() {
      UpdateStats();
        game.ChangeState(GameState.DEAD);
        lblEndFightMessage.Text = "You Were Defeated!";
        lblEndFightMessage.Visible = true;
        Refresh();
        Thread.Sleep(1200);
        EndFight();
        FrmGameOver frmGameOver = new FrmGameOver();
        frmGameOver.Show();
    } 
    private void btnLightAttack_Click(object sender, EventArgs e) {
      this.btnLightAttack.Click -= btnLightAttack_Click;
      this.enemyAtt = randomAtt();
      if (this.enemyAtt == "LA") {
        //tie() <-- nothing happens
      }
      else if (this.enemyAtt == "HA") {
        lose();
      }
      else { //(this.enemyAtt == "P")
        win();
      }
      if (enemy.Health <= 0) {
        enemyDies();
      }
      else if (character.Health <= 0) {
        playerDies();
      }
      //nobody dead
      else {
        UpdateStats();
      }
      this.btnLightAttack.Click += btnLightAttack_Click;
    }

    private void btnHeavyAttack_Click(object sender, EventArgs e) {
      this.btnHeavyAttack.Click -= btnHeavyAttack_Click;
      this.enemyAtt = randomAtt();
      if (this.enemyAtt == "LA") {
        win();
      }
      else if (this.enemyAtt == "HA") {
        //tie() <-- nothing happens
      }
      else { //(this.enemyAtt == "P")
        lose();
      }
      if (enemy.Health <= 0) {
        enemyDies();
      }
      else if (character.Health <= 0) {
        playerDies();
      }
      //nobody dead
      else {
        UpdateStats();
      }
      this.btnHeavyAttack.Click += btnHeavyAttack_Click;
    }

    private void btnParry_Click(object sender, EventArgs e) {
      this.btnParry.Click -= btnParry_Click;
      this.enemyAtt = randomAtt();
      if (this.enemyAtt == "LA") {
        lose();
      }
      else if (this.enemyAtt == "HA") {
        win();
      }
      else { //(this.enemyAtt == "P")
        //tie() <-- nothing happens
      }
      if (enemy.Health <= 0) {
        enemyDies();
      }
      else if (character.Health <= 0) {
        playerDies();
      }
      //nobody dead
      else {
        UpdateStats();
      }
      this.btnParry.Click += btnParry_Click;
    }

    private void tmrEnemyDamage_Tick(object sender, EventArgs e) {
      lblEnemyDamage.Top -= 2;
      if (lblEnemyDamage.Top < 10) {
        lblEnemyDamage.Visible = false;
        tmrEnemyDamage.Enabled = false;
        lblEnemyDamage.Top = 52;
      }
    }
    private void tmrPlayerDamage_Tick(object sender, EventArgs e) {
      lblPlayerDamage.Top -= 2;
      if (lblPlayerDamage.Top < 10) {
        lblPlayerDamage.Visible = false;
        tmrPlayerDamage.Enabled = false;
        lblPlayerDamage.Top = 52;
      }
    }
  }
}
