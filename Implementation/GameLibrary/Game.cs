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
