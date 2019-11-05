using System;
using System.Collections.Generic;
using System.Drawing;

namespace GameLibrary
{
    public class Enemy : Mortal
    {
        private const float MAX_XP_DROP = 35;
        private const float MIN_XP_DROP = 15;
        private const float WEAKEN_MIN = 1.25f;
        private const float WEAKEN_MAX = 1.85f;

        public Bitmap Img { get; private set; }
        public float XpDropped { get; private set; }

        private static readonly Random rand = new Random();
        private static readonly List<string> names = new List<string>() {
      "Wily", "Bob", "Dr. Light", "WallCrusher"
    };

        public Enemy(int level, Bitmap img, int type) : base(RandName(), level)
        {
            Img = img;

            if (type == 0)
            {
                // weaken so player has a chance
                Health /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Mana /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Str /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Def /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
            }
            else if (type == 1)
            {
                //Magic enemy
                // weaken so player has a chance
                Health /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Mana /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Mana *= 2;
                Str /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Def /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Def /= 1.2f;
            }
            else if (type == 2)
            {
                //Tank enemy
                // weaken so player has a chance
                Health /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Health *= 2;
                Mana /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Mana /= 1.5f;
                Str /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Str /= 2;
                Def /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Def *= 1.5f;
            }
            else if (type == 3)
            {
                //Damage enemy
                // weaken so player has a chance
                Health /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Health /= 2;
                Mana /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Str /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Str *= 2.5f;
                Def /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Def /= 1.5f;
            }
            else if (type == 4)
            {
                //Boss
                // weaken so player has a chance
                Health /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Health *= 3;
                Mana /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Mana *= 2;
                Str /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Str *= 2;
                Def /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Def *= 1.5f;
            }
            else
            {
                // weaken so player has a chance
                Health /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Mana /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Str /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
                Def /= (float)rand.NextDouble() * (WEAKEN_MAX - WEAKEN_MIN) + WEAKEN_MIN;
            }

            XpDropped = (float)rand.NextDouble() * (MAX_XP_DROP - MIN_XP_DROP) + MIN_XP_DROP;
        }

        public static string RandName()
        {
            return names[rand.Next(names.Count)];
        }
    }
}
