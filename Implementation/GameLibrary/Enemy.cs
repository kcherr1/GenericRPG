using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameLibrary {
  // Each enemy has a certain type
  public enum EnemyType {
    ThiccBoi,
    GlassCannon,
    ArmorBoy
  }

  public class Enemy : Mortal {
    private const float MAX_XP_DROP = 35;
    private const float MIN_XP_DROP = 15;
    private const float WEAKEN_MIN = 1.25f;
    private const float WEAKEN_MAX = 1.85f;

    public Bitmap Img { get; private set; }
    public EnemyType Type {get; private set; }
    public float XpDropped { get; private set; }

    private static readonly Random rand = new Random();
    private static readonly List<string> names = new List<string>() {
      "Wily", "Bob", "Dr. Light", "WallCrusher"
    };

    public Enemy(int level, Bitmap img, EnemyType type) : base(RandName(), level) {
      Img = img;
      Type = type;

      // weaken so player has a chance
      setHealth(type);
      setStr(type);
      setDef(type);

      XpDropped = (float)rand.NextDouble() * (MAX_XP_DROP - MIN_XP_DROP) + MIN_XP_DROP;
    }

    // weaken the health of enemy.  Raise slightly if Thicc Boi, further weaken if Armor Boy 
    private void setHealth(EnemyType type) {
      Health /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
      if (type == EnemyType.ThiccBoi)
         Health += Health * .5f;
      else if (type == EnemyType.ArmorBoy)
        Health -= Health * .25f;
    }

    // weaken the strength of enemy.  Raise slightly if Glass cannon, further weaken if Thicc Boi 
    private void setStr(EnemyType type) {
      Str /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
      if (type == EnemyType.GlassCannon)
         Str += Str * .5f;
      else if (type == EnemyType.ThiccBoi)
        Str -= Str * .25f;
    }

    // weaken the defence of enemy.  Raise slightly if Armor Boi, further weaken if Glass Cannon 
    private void setDef(EnemyType type) {
      Def /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
      if (type == EnemyType.ArmorBoy)
         Def += Def * .5f;
      else if (type == EnemyType.GlassCannon)
        Def -= Def * .25f;
    }

    public static string RandName() {
      return names[rand.Next(names.Count)];
    }
  }
}
