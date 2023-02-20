

namespace GameSnake.InConsole
{
    public static class InitializerPosition
    {
        public static Position Initializer(int limitX,int limitY)
        {
            Random random = new Random();
            int PInitialX = random.Next(1,limitX - 1);
            int PInitialY = random.Next(1,limitY - 1);

            return new Position(PInitialX,PInitialY);
        }
    }
}
