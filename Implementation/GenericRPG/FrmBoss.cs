using GameLibrary;
using GenericRPG.Properties;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GenericRPG {
  public partial class FrmBoss : Form {
    private Game game;
    private Character character;
    private Boss boss;

    public FrmBoss() {
      InitializeComponent();
    }
    private void btnEndFight_Click(object sender, EventArgs e) {
      EndFight();
    }
    private void EndFight() {
      Game.GetGame().ChangeState(GameState.ON_MAP);
      Close();
    }
    private void FrmBoss_Load(object sender, EventArgs e) {

      game = Game.GetGame();
      character = game.Character;
      boss = new Boss(character.Level, Resources.boss);

      // stats
      UpdateStats();

      // pictures
      picCharacter.BackgroundImage = character.Pic.BackgroundImage;
      picBoss.BackgroundImage = boss.Img;

      // names
      lblPlayerName.Text = character.Name;
      lblBossName.Text = boss.Name;
    }
    public void UpdateStats() {
      lblPlayerLevel.Text = character.Level.ToString();
      lblPlayerHealth.Text = Math.Round(character.Health).ToString();
      lblPlayerStr.Text = Math.Round(character.Str).ToString();
      lblPlayerDef.Text = Math.Round(character.Def).ToString();
      lblPlayerMana.Text = Math.Round(character.Mana).ToString();
      lblPlayerXp.Text = Math.Round(character.XP).ToString();

      lblBossLevel.Text = boss.Level.ToString();
      lblBossHealth.Text = Math.Round(boss.Health).ToString();
      lblBossStr.Text = Math.Round(boss.Str).ToString();
      lblBossDef.Text = Math.Round(boss.Def).ToString();
      lblBossMana.Text = Math.Round(boss.Mana).ToString();

      lblPlayerHealth.Text = Math.Round(character.Health).ToString();
      lblBossHealth.Text = Math.Round(boss.Health).ToString();
    }
    private void btnSimpleAttack_Click(object sender, EventArgs e) {
      float prevBossHealth = boss.Health;
      character.SimpleAttack(boss);
      float bossDamage = (float)Math.Round(prevBossHealth - boss.Health);
      lblBossDamage.Text = bossDamage.ToString();
      lblBossDamage.Visible = true;
      tmrBossDamage.Enabled = true;
      if (boss.Health <= 0) {
        character.GainXP(boss.XpDropped);
        lblEndFightMessage.Text = "You Gained " + Math.Round(boss.XpDropped) + " xp!";
        lblEndFightMessage.Visible = true;
        Refresh();
        Thread.Sleep(1200);
        EndFight();
        if (character.ShouldLevelUp) {
          FrmLevelUp frmLevelUp = new FrmLevelUp();
          frmLevelUp.Show();
        }
      }
      else {
        float prevPlayerHealth = character.Health;
        boss.SimpleAttack(character);
        float playerDamage = (float)Math.Round(prevPlayerHealth - character.Health);
        lblPlayerDamage.Text = playerDamage.ToString();
        lblPlayerDamage.Visible = true;
        tmrPlayerDamage.Enabled = true;
        if (character.Health <= 0) {
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
        else {
          UpdateStats();
        }
      }
    }
    private void btnRun_Click(object sender, EventArgs e) {
      if (rand.NextDouble() < 0.25) {
        lblEndFightMessage.Text = "You Ran Like a Coward!";
        lblEndFightMessage.Visible = true;
        Refresh();
        Thread.Sleep(1200);
        EndFight();
      }
      else {
        boss.SimpleAttack(character);
        UpdateStats();
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

    private void tmrBossDamage_Tick(object sender, EventArgs e) {
      lblBossDamage.Top -= 2;
      if (lblBossDamage.Top < 10) {
        lblBossDamage.Visible = false;
        tmrBossDamage.Enabled = false;
        lblBossDamage.Top = 52;
      }
    }
  }
}
