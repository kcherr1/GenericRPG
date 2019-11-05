using System;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GameLibrary
{
    public struct Position
    {
        public int row;
        public int col;

        /// <summary>
        /// Construct a new 2D position
        /// </summary>
        /// <param name="row">Given row or y value</param>
        /// <param name="col">Given col or x value</param>
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
    /// <summary>
    /// This represents our player in our game
    /// </summary>
    public class Character : Mortal
    {
        public PictureBox Pic { get; private set; }
        [JsonProperty] public Position pos;
        private Map map;
        public float XP { get; private set; }
        public bool ShouldLevelUp { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="pos"></param>
        /// <param name="map"></param>
        public Character(PictureBox pb, Position pos, Map map) : base("Player 1", 1)
        {
            Pic = pb;
            this.pos = pos;
            this.map = map;
            ShouldLevelUp = false;
        }

        // character constructor overload to feed it saved data
        // this function loads teh character from saved data
        public void LoadCharacter(string data)
        {
            Console.WriteLine(data);
            JObject obj = JObject.Parse(data);

            //this.Pic = current.Pic;
            this.pos = new Position(
                Convert.ToInt32(obj["Character"]["pos"]["row"]),
                Convert.ToInt32(obj["Character"]["pos"]["col"])
                );

            this.ShouldLevelUp = Convert.ToBoolean(obj["Character"]["ShouldLevelUp"]);
            this.SetLevel((int)obj["Character"]["Level"]);
            this.XP = (float)(obj["Character"]["XP"]);
            this.Name = obj["Character"]["Name"].ToString();
            this.MaxHealth = (int)obj["Character"]["MaxHealth"];
            this.Health = (int)obj["Character"]["Health"];
            this.MaxMana = (int)obj["Character"]["MaxMana"];
            this.Mana = (int)obj["Character"]["Mana"];
            this.Str = (float)obj["Character"]["Str"];
            this.Def = (float)obj["Character"]["Def"];
            this.Luck = (float)obj["Character"]["Luck"];
            this.Speed = (float)obj["Character"]["Speed"];

            // update sprite location
            Position topleft = map.RowColToTopLeft(pos);
            Pic.Left = topleft.col;
            Pic.Top = topleft.row;
        }
            
        public bool ShouldSerializePic()
        {
            // tell JSON serlializer to ignore this value 
            return false;
        }

        public string SaveToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        public void GainXP(float amount)
        {
            XP += amount;

            // every 100 experience points you gain a level
            if ((int)XP / 100 >= Level)
            {
                ShouldLevelUp = true;
            }
        }

        public override void LevelUp()
        {
            base.LevelUp();
            ShouldLevelUp = false;
        }

        public void BackToStart()
        {
            pos.row = map.CharacterStartRow;
            pos.col = map.CharacterStartCol;
            Position topleft = map.RowColToTopLeft(pos);
            Pic.Left = topleft.col;
            Pic.Top = topleft.row;
        }

        public override void ResetStats()
        {
            base.ResetStats();
            XP = 0;
        }

        public void Move(MoveDir dir)
        {
            Position newPos = pos;
            switch (dir)
            {
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
            if (map.IsValidPos(newPos))
            {
                pos = newPos;
                Position topleft = map.RowColToTopLeft(pos);
                Pic.Left = topleft.col;
                Pic.Top = topleft.row;
            }
        }

    }
}
