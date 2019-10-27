using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GameLibrary
{
    public enum GameState
    {
        LOADING,
        MAIN_MENU,
        ON_MAP,
        PAUSED,
        FIGHTING,
        DEAD,
    }

    public class Game
    {
        private static Game game;

        public Map map;  // have the game keep track of the map so make saving the game state easier
        public Character Character { get; private set; }
        public GameState State { get; private set; }

        private Game()
        {
            State = GameState.LOADING;
        }

        public static Game GetGame()
        {
            if (game == null)
                game = new Game();
            return game;
        }

        public void ChangeState(GameState newState)
        {
            State = newState;
        }

        public void SetCharacter(Character character)
        {
            Character = character;
        }
    }
}
