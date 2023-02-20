

namespace GameSnake.InConsole
{
    public class Apple
    {
        public Position Position { get; set; }

        public ConsoleColor Color { get; set; } = ConsoleColor.Red;

        public string CharacterRepresentative = "Ó";

        public Apple(Board board)
        {
            Position = InitializerPosition.Initializer(board.Width,board.Height);
        }
        public Apple(Position position)
        {
            Position = position;
        }
    }
}
